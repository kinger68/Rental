CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRentalPropertiesByCity`(streetId INTEGER)
BEGIN
SELECT * from rentalProperties rp
                  INNER JOIN streets st ON rp.streetId = st.id
                  INNER JOIN cities ct on st.cityId = ct.id
WHERE streetId = st.id;
END