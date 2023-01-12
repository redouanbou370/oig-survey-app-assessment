# oig-survey-app-assessment
Coding assessment for new developers @ OIG

### Pre Requisites

* Visual Studio Code
* Docker

### Run PostgreSQL in Docker
*  Clone the project to your laptop or computer
* Go to the folder using ``` cd oig-survey-app-assessment ```
* In the terminal, use the command: ``` docker-compose up -d ```
* This will create a postgress image that's running on port 5432. The credentials of the user is as follows: 
  * Username: postgres
  * Password: postgres

### Run client and server
The client is build in Angular. I used the framework Bootstrap to create the 

1. To run the server, run the command from the cmd in the 'QuestionnairesServer' folder: ``` dotnet run ```
2. To run the client, run the command from the cmd in the 'QuestionnairesClient' folder: ``` ng serve -o ```
