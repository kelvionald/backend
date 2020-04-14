create table customer
(
    customer_id       INTEGER
        primary key autoincrement,
    first_name        TEXT,
    last_name         TEXT,
    passport_code     TEXT,
    registration_date DATETIME
);

create table dvd
(
    dvd_id          INTEGER
        primary key autoincrement,
    title           TEXT,
    production_year INTEGER
);

create table offer
(
    offer_id    INTEGER
        primary key autoincrement,
    dvd_id      INTEGER,
    customer_id INTEGER,
    offer_date  DATE,
    return_date DATE
);

