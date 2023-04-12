-- Drop tables in reverse order to to Foreign Key Constraints
DROP TABLE IF EXISTS renter;
DROP TABLE IF EXISTS rental_property;
DROP TABLE IF EXISTS street;
DROP TABLE IF EXISTS city;
DROP TABLE IF EXISTS state;
DROP TABLE IF EXISTS country;

CREATE TABLE IF NOT EXISTS country (
    id	    INTEGER PRIMARY KEY,
    name	VARCHAR(63) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO country(id, name) VALUES(1, 'United States');

DROP TABLE IF EXISTS state;
CREATE TABLE IF NOT EXISTS state (
    id	        INTEGER PRIMARY KEY,
    name	    VARCHAR(63) NOT NULL,
    country_id	INTEGER NOT NULL,
    created_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (country_id) 
        REFERENCES country (id)
);
INSERT INTO state(id, name, country_id) VALUES (1, 'Alabama', 1);
INSERT INTO state(id, name, country_id) VALUES (2, 'Maine', 1);
INSERT INTO state(id, name, country_id) VALUES (3, 'Massachusetts', 1);
INSERT INTO state(id, name, country_id) VALUES (4, 'Texas', 1);
INSERT INTO state(id, name, country_id) VALUES (5, 'Wyoming', 1);

CREATE TABLE city (
    id  	    INTEGER PRIMARY KEY,
    Name	    VARCHAR(63),
    state_id	INTEGER NOT NULL,
    created_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (state_id) REFERENCES state (id)
);
INSERT INTO city(id, name, state_id) VALUES (1, 'Birmingham', 1);
INSERT INTO city(id, name, state_id) VALUES (2, 'Boston', 3);
INSERT INTO city(id, name, state_id) VALUES (3, 'Dallas', 4);
INSERT INTO city(id, name, state_id) VALUES (4, 'Casper', 5);

-- Street Table Creation
CREATE TABLE street (
    id          INTEGER PRIMARY KEY,
    name        VARCHAR(63) DEFAULT NULL,
    city_id     INTEGER NOT NULL,
    zip_code	VARCHAR(10) NOT NULL,
    created_at  TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(city_id) REFERENCES city(id)
);
INSERT INTO street(id, name, city_id, zip_code) VALUES (1,'Beacon Street', 3, '02116');

-- Rental Property Table Creation
CREATE TABLE rental_property (
    id              INTEGER PRIMARY KEY,
    name	        VARCHAR(255) NOT NULL,
    street_id   	INTEGER NOT NULL,
    rent            NUMERIC NOT NULL,
    bedrooms        INTEGER NOT NULL DEFAULT 1,
    unit        	VARCHAR(63),
    FOREIGN KEY(street_id) REFERENCES street(id)
);

CREATE TABLE renter (
    renter_id           INTEGER PRIMARY KEY ,
    first_name 	        VARCHAR(63) NOT NULL,
    middle_name	        INTEGER,
    last_name	        TEXT NOT NULL,
    property_id	        INTEGER,
    current_street_id	INTEGER NOT NULL,
    FOREIGN KEY(property_id) REFERENCES rental_property(id),
    FOREIGN KEY(current_street_id) REFERENCES street(id)
);