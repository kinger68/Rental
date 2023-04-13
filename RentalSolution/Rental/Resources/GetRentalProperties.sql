CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRentalProperties`()
BEGIN
	SELECT * from rental_property;
END