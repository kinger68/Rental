# Rental
Application to maintain rental properties and their Renters

Database that will store the data for the Rentals and the Renters will be SQLLite

Rest API Endpoint
- RentalPropety/api/v1/createRentalProperty - HttpPost
-- Returns - Status200Ok, Status400BadRequest
- RentalProperty/api/v1/findRentalByCity:city - HttpGet
-- Returns - Status200Ok, Status404NotFound
- RentalPrperoty/api/v1/createRenter - HttpPost
- api/vi/findRenter:id - HttpGet
-- Returns - Status200Ok, Status404NotFound

No Authorization for this application

SQL which creates RDB schema and populates static data along with stored procedures can be 
found in Rental/Resources directory

Things still do to
- Create Rental Property via API
- Create and Find Renter via API
- Stored Procedure for the add of rental property (Right now using EF with specified Domain Object)
- Stored Procedure for the modify of rental property (Right now using EF with specified Domain Object)
- Stored Procedure for the search of rental properties (Right now using EF and specific query)