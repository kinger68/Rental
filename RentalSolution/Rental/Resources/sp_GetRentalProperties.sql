CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRentalProperties`()
BEGIN
    SELECT * from rentalProperties;
END