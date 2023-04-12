# Rental
Application to maintain rental properties and their Renters

Database that will store the data for the Rentals and the Renters will be SQLLite

Rest API Endpoint
- api/v1/createRental - HttpPost
-- Returns - Status200Ok, Status400BadRequest
- api/v1/findRental:id - HttpGet
-- Returns - Status200Ok, Status404NotFound
- api/v1/createRenter - HttpPost
- api/vi/findRenter:id - HttpGet
-- Returns - Status200Ok, Status404NotFound

No Authorization for this application

RentalDataBase Schema
Property
- PropertyId
- Name -- Name of the property
- Unit -- Unit identifier at the address of the property (apartments for example)
- Street (From the street, you get the city, state, country)
- bedrooms --Number of bedrooms in the apartment
- rent -- Cost for the unit

Renter
- 

country (1 to many) state (1 to many) city (1 to many) street
Each street contains a zip-code since a city can have multiple