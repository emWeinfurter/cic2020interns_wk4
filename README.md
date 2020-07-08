# cic2020interns_wk4 - Implementing COVID-19 API
## .NET Mini-Challenge
https://api.covid19api.com/

https://api.apify.com

## Scenario
Because of your extensive COVID API knowledge, you have been assigned to Scrum Team 19. This team is developing a PoC to compare different API services. The problem is that too many hours were burned on v1 and now the team is in the red. 

Version 1 is available via https://api.apify.com

Version 2 is available via https://api.covid19api.com/

Your help is needed. 

## User Story 
 > As a user, I want a v2 UI that will render a list of countries and an interactive chart showing the same information as in v1 so that I can compare both versions.

### Overview
![Overview](https://media.github.ibm.com/user/203313/files/2fcd7e80-c0ed-11ea-9a65-a1185c5486c9)

### UI - Home Page
![Home Page](https://media.github.ibm.com/user/203313/files/c8a9cd00-c0e0-11ea-9c66-2468ae6fc82e)

### UI - v1 Implementation
![Version 1](https://media.github.ibm.com/user/203313/files/a1eb9680-c0e0-11ea-8474-c58bef01db45)

## Development Tasks
**Hint:** `Ctrl+Shift+F` `//Task:`
### Back-end Tasks
- [ ] Implement Covid19ApiService
- [ ] Inject Covid19ApiService
- [ ] Implement Covid19Api API

### Front-end Tasks
- [ ] Develop JS to populate chart and table data

## Project Directory Structure 
```
|   COVID-19.sln
+---Back-end
|   |    
|   +---Configuration
|   |       
|   +---Controllers
|   |       
|   +---Data
|   |       
|   +---Models
|   |       
|   +---Properties
|   |       
|   \---Services
|           
+---Front-end
|   |           
|   +---css
|   |       
|   +---js
|   |       
|   \---statistics
```

## Project Files
```
|   COVID-19.sln
+---Back-end                      -- main application classes
|   |   Program.cs
|   |   Startup.cs
|   |    
|   +---Configuration             -- configuration classes
|   |       ApifyConfig.cs
|   |       CorsConfig.cs
|   |       Covid19ApiConfig.cs
|   |       IFileConfig.cs
|   |       IUrlConfig.cs
|   |       LocatorConfig.cs
|   |       
|   +---Controllers               -- rest layer
|   |       ApifyController.cs
|   |       Covid19ApiController.cs
|   |       IndexController.cs
|   |       
|   +---Data                      -- json data
|   |       Locations.json
|   |       
|   +---Models                    -- data models
|   |       ApifyDataModel.cs
|   |       Covid19ApiDataModel.cs
|   |       LocationDataModel.cs
|   |       
|   +---Properties
|   |       launchSettings.json
|   |       
|   \---Services                    -- service layer
|           ApifyService.cs
|           Covid19ApiService.cs
|           IApify.cs
|           ICovid19Api.cs
|           ILocator.cs
|           LocatorService.cs
|           
+---Front-end
|   |   codeblue.jpg
|   |   Index.aspx
|   |           
|   +---css
|   |       main.css
|   |       
|   +---js
|   |       apify.js
|   |       covid19api.js
|   |       
|   \---statistics
|           apify.aspx
|           covid19api.aspx
```
## Tools and Technology
Visual Studio 2019 - https://visualstudio.microsoft.com

C# - https://docs.microsoft.com/en-us/dotnet/csharp/

JavaScript/ES6 - https://developer.mozilla.org/en-US/docs/Web/JavaScript

amCharts 4: Maps - https://www.amcharts.com/javascript-maps/
## Contributers
Elise
Reginald
