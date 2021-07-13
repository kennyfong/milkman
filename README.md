# milkman

# Full Stack Developer – Technical Test 

## Introduction 

The purpose of this test is to assess your knowledge and approach to software  development. The most important thing is the quality, efficiency and maintainability  of the solution.  

## Scenario 

You are required to write a Web API to support the management of Customers. You should create a solution, preferably with .NET Core, that: 
• Fulfils all the criteria laid out below 
• Shows a good understanding of modern development techniques. 
• Is structured in a in a way that a production system would be. 
• Has a set of Postman or Insomnia scripts that we can use to review/test the  solution 
• Is stored in a git repository that we could be given access to. GitHub, Azure DevOps, Bit Bucket etc. 

## Criteria 

You are required to write a Web API to support the management of Customers  Here are the minimum set of requirements for the solution: 
• A customer can only exist once within the database 
• A customer can have multiple addresses. 
• You cannot delete the last address as a customer MUST have at least one  address. 
• A secondary address can become the main address, but a customer can  have ONLY ONE main address. 
• A customer can be marked as in-active if requested by the customer.  • A customer can be deleted, and all associated addresses should also be  deleted 
• A list of ALL customers can be returned. 
• A list of ACTIVE customers can be returned

## Data Entities 
The following data entities are required. NOTE: These may not be complete for you  to finish the solution but should be the minimum set of fields as defined by the  business analyst: 

### Customer
| Field        | Mandatory           | Notes  |
| ------------- |:-------------:| -----:|
| Title      | Y | Up to 20 characters |
| Forename      | Y      |   Up to 50 characters |
| Surname | Y      |    Up to 50 characters |
| Email Address      | Y      |   Up to 75 characters |
| Mobile No | Y      |    Up to 15 characters |
 			 		


### Address
| Field        | Mandatory           | Notes  |
| ------------- |:-------------:| -----:|
| Address Line 1      | Y | Up to 80 characters |
| Address Line 2      | N      |   Up to 80 characters |
| Town | Y      |    Up to 50 characters |
| County      | N      |   Up to 50 characters |
| Postcode | Y      |    Up to 10 characters |
| Country | N      |    If not provided default to UK |

# Application Summary

A .Net 5 ASP.NET Core Web Api developed in Visual Studio 2019. Please do not use IIS or IIS Express to run and debug the application as the Postman scripts is configured to use localhost on port 5001 using HTTPS protocol.

Swagger is available and should be the default page to load when debugging
