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
