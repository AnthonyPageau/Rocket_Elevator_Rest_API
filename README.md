# Rocket_Elevator_Rest_API
## Members of the team
- **[Loïc Rico](https://github.com/ricoloic)**

- **[Anthony Pageau](https://github.com/ricoloic)**

- **[Jean-Francois Taillefer](https://github.com/ricoloic)**

- **[Louis-Felix Beland](https://github.com/ricoloic)**

- **[Alimourana Balde](https://github.com/alimourana)**

## How to know and to mapiuplate the status of all the relevant entities of the operational database
### Here's a link to the collection of the requests in **[Postman](https://stoner224.postman.co/collections/13408509-c0efb6fa-bb19-4079-9980-32c383261a0c?version=latest&workspace=dbe9588f-2096-4c82-8e20-4d22a241cb07)**. If you prefer, you can do it manually with the walkthrough below.

1- Retrieving the current status of a specific Battery:
    https://rocketrestapi.azurewebsites.net/api/Battery/1

    GET 
    https://rocketrestapi.azurewebsites.net/api/Battery/1	[1 = battery ID]
    SEND
    
2- Changing the status of a specific Battery:

    PUT 
    https://rocketrestapi.azurewebsites.net/api/Battery/1	[1 = battery ID]
    Select:	 Body
                Raw
                JSON
    In the text field, enter: { "battery_status": "ACTIVE" or "Inactive" or "Intervention" } 
    SEND
    You can verify if it worked by retrieving the current status of the specific battery (STEP 1).
    
3- Retrieving the current status of a specific Column:

    GET 
    https://rocketrestapi.azurewebsites.net/api/Column/1 [1 = column ID]
    SEND
    
4- Changing the status of a specific Column:

    PUT 
    https://rocketrestapi.azurewebsites.net/api/Column/1 [1 = column ID]
    Select:  Body
                Raw
                JSON
    In the text field, enter: { "column_status": "ACTIVE" or "Inactive" or "Intervention" } 
    SEND
    You can verify if it worked by retrieving the current status of the specific column (STEP 3).
    
5- Retrieving the current status of a specific Elevator:

    GET 
    https://rocketrestapi.azurewebsites.net/api/Elevator/1 [1 = elevator ID]
    SEND
    
6- Changing the status of a specific Elevator:

    PUT 
    https://rocketrestapi.azurewebsites.net/api/Elevator/1 [1 = elevator ID]
    Select:  Body
                Raw
                JSON
    In the text field, enter: { "elevator_status": "ACTIVE" or "Inactive" or "Intervention" }
    SEND
    You can verify if it worked by retrieving the current status of the specific elevator (STEP 5).
    
7- Retrieving a list of Elevators that are not in operation at the time of the request:

    GET 
    https://rocketrestapi.azurewebsites.net/api/Elevator
    SEND
    
8- Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention:

    GET 
    https://rocketrestapi.azurewebsites.net/api/Building
    SEND
    
9- Retrieving a list of Leads created in the last 30 days who have not yet become customers:

    GET 
    https://rocketrestapi.azurewebsites.net/api/Lead
    SEND 


