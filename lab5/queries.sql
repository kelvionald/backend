-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
-- #10

delete
from dvd;

delete
from customer;

delete
from offer;

INSERT INTO dvd (title, production_year)
VALUES ('1984', 1984),
       ('Океаны', 2010),
       ('Книга Илая', 2010);

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Richard', 'Gates', 'AB12012', '2020-01-21');

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (2, 1, '2020-01-21', '2030-01-25'),
       (3, 1, '2020-01-21', '2030-01-25');

-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010,
-- #10 отсортированных в алфавитном порядке по названию DVD.

SELECT *
FROM dvd
WHERE production_year = 2010
ORDER BY title ASC;

-- 5.  Подготовьте SQL запрос для получения списка DVD дисков, которые в настоящее время
-- #10 находятся у клиентов.

SELECT dvd.*
FROM offer
         LEFT JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE CURRENT_DATE BETWEEN offer.offer_date AND offer.return_date;

-- 6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD
-- #10 диски в текущем году. В результатах запроса необходимо также отразить какие диски
--     брали клиенты.

SELECT customer.*, dvd.*
FROM offer
LEFT JOIN customer ON offer.customer_id = customer.customer_id
LEFT JOIN dvd on offer.dvd_id = dvd.dvd_id
WHERE STRFTIME('%Y', DATE('now')) = STRFTIME('%Y', offer.offer_date);