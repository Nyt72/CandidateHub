# Candidate Hub : This is a small web application written in .NET 8 and EF core using local sql server with swagger
# The pattern is repository and code-first approach is used to design the database 
# A NUnit test project in the controller level is implemented testing success and error scenario implementing mock .
# A generic api response is created for the seamless display in UI .
# Model is validated and response for all scenario is handled.

# Caching : This could be implemented for the fetching of all candidates with ID to avoid repetition of finding the existing query.

#Possible Improvement : Development of Stored Procedure for large filters of candidate in get/fetch requests; implementation of logging when business logic is enhanced , we could implement elastic search in UI for quick retrieval of records. 

# For small API : we could also use minimal api provided by .NET newer versions , fluent validations and mediator 
# For dynamicDBContext : For the migration , a new table can be introduced for candidates with flag isMigrated and based off switch to new context getting the connection string as done in many commercial applications.

# Total time spent : 6 hrs in development and testing.