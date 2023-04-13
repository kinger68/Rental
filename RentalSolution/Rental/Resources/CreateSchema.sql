-- Drop tables in reverse order to to Foreign Key Constraints
DROP TABLE IF EXISTS renter;
DROP TABLE IF EXISTS rental_property;
DROP TABLE IF EXISTS streets;
DROP TABLE IF EXISTS cities;
DROP TABLE IF EXISTS state;
DROP TABLE IF EXISTS country;

CREATE TABLE IF NOT EXISTS country (
    id	        INTEGER PRIMARY KEY,
    name	    VARCHAR(63) NOT NULL,
    createdAt   TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO country(id, name) VALUES(1, 'United States');

DROP TABLE IF EXISTS state;
CREATE TABLE IF NOT EXISTS state (
    id	        INTEGER PRIMARY KEY,
    name	    VARCHAR(63) NOT NULL,
    countryId	INTEGER NOT NULL,
    createdAt   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (countryId) 
        REFERENCES country (id)
);
INSERT INTO state(id, name, countryId) VALUES (1, 'Alabama', 1);
INSERT INTO state(id, name, countryId) VALUES (2, 'Maine', 1);
INSERT INTO state(id, name, countryId) VALUES (3, 'Massachusetts', 1);
INSERT INTO state(id, name, countryId) VALUES (4, 'Texas', 1);
INSERT INTO state(id, name, countryId) VALUES (5, 'Wyoming', 1);

CREATE TABLE cities (
    id  	    INTEGER PRIMARY KEY,
    Name	    VARCHAR(63),
    stateId 	INTEGER NOT NULL,
    createdAt   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (stateId) REFERENCES state (id)
);
INSERT INTO cities(id, name, stateId) VALUES (1, 'Birmingham', 1);
INSERT INTO cities(id, name, stateId) VALUES (2, 'Boston', 3);
INSERT INTO cities(id, name, stateId) VALUES (3, 'Dallas', 4);
INSERT INTO cities(id, name, stateId) VALUES (4, 'Casper', 5);

-- Street Table Creation
CREATE TABLE streets (
    id          INTEGER PRIMARY KEY,
    name        VARCHAR(63) DEFAULT NULL,
    cityId      INTEGER NOT NULL,
    zipcode 	VARCHAR(10) NOT NULL,
    createdAt   TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(cityId) REFERENCES cities(id)
);
INSERT INTO streets(id, name, cityId, zipcode) VALUES (1,'Beacon Street', 2, '02116');
INSERT INTO streets(id, name, cityId, zipcode) VALUES (2,'1st Lane', 4, '82609');

-- Rental Property Table Creation
CREATE TABLE rental_property (
    id              INTEGER AUTO_INCREMENT PRIMARY KEY,
    name	        VARCHAR(255) NOT NULL,
    streetId    	INTEGER NOT NULL,
    rent            NUMERIC NOT NULL,
    bedrooms        INTEGER NOT NULL DEFAULT 1,
    unit        	VARCHAR(63),
    createdAt       TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(streetId) REFERENCES streets(id)
);
INSERT INTO rental_property(name, streetId, rent, bedrooms, unit) VALUES ('ThemPlaces-Boston', 1, 2000, 3, 'Unit 5');
INSERT INTO rental_property(name, streetId, rent, bedrooms, unit) VALUES ('ThemPlaces-Casper', 2, 1000, 1, 'Unit WildWest 6');

CREATE TABLE renter (
    id                      INTEGER PRIMARY KEY ,
    firstName 	            VARCHAR(63) NOT NULL,
    middleName	            INTEGER,
    lastName	            TEXT NOT NULL,
    propertyId	            INTEGER,
    currentAddressStreetId  INTEGER NOT NULL,
    createdAt               TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(propertyId) REFERENCES rental_property(id),
    FOREIGN KEY(currentAddressStreetId) REFERENCES streets(id)
);