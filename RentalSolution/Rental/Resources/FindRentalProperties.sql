CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRentalPropertiesInCity`(street_id INTEGER)
BEGIN
	SELECT count(*) from rental_property rp 
	INNER JOIN street st ON rp.street_id = st.id 
	INNER JOIN city ct on st.city_id = ct.id
    WHERE street_id = st.id;
END