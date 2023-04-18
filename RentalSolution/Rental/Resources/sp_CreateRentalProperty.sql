CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CreateRentalProperty`(name varchar(255), streetId integer, rent numeric, bedrooms integer, unit varchar(63))
BEGIN
    INSERT INTO rentalProperties(name, streetId, rent, bedrooms, unit) VALUES (name, streetId, rent, bedrooms, unit);
END