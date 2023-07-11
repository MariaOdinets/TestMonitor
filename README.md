# TestMonitor

UI tests positive
- Creating a project
- Deleting a project
- Checking boundary values (Project name input field max length , max length - 1)
  
UI tests negative
- Login with invalid credentials
- Checking boundary values (Project name input field max length + 1)
- Failed test (trying to login without a required field)

API tests
- Get project
- Get project (nonexistent id)
- Get project (unauthorized)
- Post project
