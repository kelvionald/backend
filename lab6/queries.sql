-- 1. (#15)  Напишите SQL запросы  для решения задач ниже.
--
-- Table "PC"
--     id  cpu(MHz)  memory(Mb)  hdd(Gb)
--     1      1600          2000             500
--     2      2400          3000             800
--     3      3200          3000             1200
--     4      2400          2000             500
--
-- 1) Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб.
--   Вывод: id, cpu, memory
SELECT id, cpu, memory
FROM pc
WHERE memory = 3000;
-- 2) Минимальный объём жесткого диска, установленного в компьютере на складе.
--   Вывод: hdd
SELECT MIN(hdd)
FROM pc;
-- 3) Количество компьютеров с минимальным объемом жесткого диска, доступного на складе.
--   Вывод: count, hdd
SELECT MIN(hdd), COUNT(id)
FROM pc
WHERE hdd = (
    SELECT MIN(hdd)
    FROM pc
);


-- 2. (#30) Есть таблица следующего вида:
--       CREATE TABLE track_downloads (
--       download_id BIGINT(20) NOT NULL AUTO_INCREMENT,
--       track_id INT NOT NULL,
--       user_id BIGINT(20) NOT NULL,
--       download_time TIMESTAMP NOT NULL DEFAULT 0,
--
--       PRIMARY KEY (download_id)
--     );
INSERT INTO track_downloads (download_id, track_id, user_id, download_time)
VALUES (1, 1, 2, '2010-11-19'),
       (2, 2, 3, '2010-12-19'),
       (4, 1, 3, '2010-11-19'),
       (5, 2, 3, '2010-11-19'),
       (6, 3, 1, '2010-11-19'),
       (7, 4, 5, '2010-11-20');
--     Напишите SQL-запрос, возвращающий все пары (download_count, user_count),
--     удовлетворяющие следующему условию:
--     user_count — общее ненулевое число пользователей, сделавших
--     ровно download_count скачиваний 19 ноября 2010 года.

SELECT download_count, count(user_id) as user_count
FROM (SELECT user_id, count(download_id) as download_count
      FROM track_downloads
      WHERE date(download_time) = '2010-11-19'
      GROUP BY user_id) AS downloads
GROUP BY download_count;


-- 3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP

-- MySQL:

-- DATETIME хранит временную метку в виде целого числа, содержит дату (год, месяц, день) и
-- время (час, минуну, секунду), не имеет привязки к временной зоне (timezone). Занимает 8 байт.
-- С этим типом можно делать прямое сравнение со строковой датой в блоке WHERE.

-- TIMESTAMP занимает в памяти 4 байта. Отсчет начинается с эпохи Unix машин (1 января 1970 года).
-- Значение по умолчанию NOW(). Зависит от часового пояса.


-- 4.(#20)  Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name).
-- Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.

CREATE TABLE students
(
    id_students INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name        TEXT    NOT NULL
);

CREATE TABLE courses
(
    id_courses INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name       TEXT    NOT NULL
);

CREATE TABLE students_courses
(
    id_courses  INTEGER NOT NULL,
    id_students INTEGER NOT NULL
);

INSERT INTO students(name)
VALUES ('Сергей'),
       ('Алекс'),
       ('Борис'),
       ('Гладыш'),
       ('Том'),
       ('Гарри');

INSERT INTO courses(name)
VALUES ('Самолетостроение'),
       ('Аэродинамика');

INSERT INTO students_courses(id_courses, id_students)
VALUES (1, 1),
       (1, 2),
       (1, 3),
       (1, 4),
       (1, 5),
       (1, 6),
       (2, 6);

-- Написать SQL запросы:
--     1. отобразить количество курсов, на которые ходит более 5 студентов
SELECT COUNT(DISTINCT courses.id_courses) as "count"
FROM students_courses
         INNER JOIN students ON students_courses.id_students = students.id_students
         INNER JOIN courses ON students_courses.id_courses = courses.id_courses
GROUP BY courses.id_courses
HAVING (COUNT(courses.id_courses) >= 5);

--     2. отобразить все курсы, на которые записан определенный студент.
SELECT students.name,
       courses.name
FROM students_courses
         INNER JOIN students ON students_courses.id_students = students.id_students
         INNER JOIN courses ON students_courses.id_courses = courses.id_courses;

-- 5. (5#) Может ли значение в столбце(ах), на который наложено ограничение foreign key,
-- равняться null? Привидите пример.

-- Если ключи не имеют ограничения NOT NULL, то они могут содержать null значения.
-- Пример:
create table check_foreign_1
(
    key int
);
create table check_foreign_2
(
    key int
        constraint check_foreign_2_check_foreign_1_key_fk
            references check_foreign_1 (key)
);
insert into check_foreign_1(key)
VALUES (1);
insert into check_foreign_1(key)
VALUES (2);


-- 6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
-- Приведите пример таблиц с данными и запросы.

-- Нужно использовать DISTINCT для вывода уникальных записей по указанному столбцу

SELECT DISTINCT id_courses
FROM students_courses;


-- 7. (#10) Есть две таблицы:
--      users - таблица с пользователями (users_id, name)
--     orders - таблица с заказами (orders_id, users_id, status)
CREATE TABLE users
(
    users_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    name     TEXT    NOT NULL
);

CREATE TABLE orders
(
    orders_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    users_id  INTEGER NOT NULL,
    status    INTEGER NOT NULL
);

INSERT INTO users(name)
VALUES ('Сергей'),
       ('Алекс'),
       ('Борис'),
       ('Гладыш'),
       ('Том'),
       ('Гарри');

INSERT INTO orders(users_id, status)
VALUES (1, 0),
       (1, 1),
       (1, 1),
       (1, 1),
       (1, 1),
       (1, 1),
       (1, 1),
       (2, 0);
--     1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице
--     orders имеют status = 0
SELECT users.*
FROM orders
         LEFT JOIN users on users.users_id = orders.users_id
WHERE users.users_id NOT IN (
    SELECT users_id
    FROM orders
    WHERE status <> 0);
--     2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей в
--     таблице orders имеют status = 1
SELECT orders.users_id,
       users.name
FROM orders
         LEFT JOIN users ON users.users_id = orders.users_id
WHERE orders.status = 1
GROUP BY orders.users_id, users.name
HAVING COUNT(orders.status) > 5;

-- 8. (#10)  В чем различие между выражениями HAVING и WHERE?

-- WHERE используется для фильтрации данных до группировки GROUP BY.
-- HAVING используется для фильтрации данных уже сгруппированных,
-- в условии допустимо использование агрегатных функций (COUNT, MAX, AVG)