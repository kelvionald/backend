-- we don't know how to generate root <with-no-name> (class Root) :(
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

create table courses
(
	id_courses INTEGER not null
		primary key autoincrement,
	name TEXT not null
);

create table orders
(
	orders_id INTEGER not null
		primary key autoincrement,
	users_id INTEGER not null,
	status INTEGER not null
);

create table pc
(
	id int
		constraint pc_pk
			primary key,
	cpu int,
	memory int,
	hdd int
);

create table students
(
	id_students INTEGER not null
		primary key autoincrement,
	name TEXT not null
);

create table students_courses
(
	id_courses INTEGER not null,
	id_students INTEGER not null
);

create table track_downloads
(
	download_id BIGINT(20) not null
		primary key,
	track_id INT not null,
	user_id BIGINT(20) not null,
	download_time TIMESTAMP default 0 not null
);

create table users
(
	users_id INTEGER not null
		primary key autoincrement,
	name TEXT not null
);

