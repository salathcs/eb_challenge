# EB_Challenge

- I choose to take on the second challenge.   
- - Firstly because I had issues starting the provided demo project (my issue was around the frameworks, even after I installed dotnet 5 I still got the error).  
- - On the other hand, the second option gave me freedom about what tools I can use.  
- - Basically I choose to try out a pretty new addition to dotnet, the dotnet Aspire. Which is a tool to develop distributed systems. It greatly helps with local development, orchestrating the services, makes the communication between the services easy and makes it easy to add external dependencies as I did it with a sql server (the Aspire even starts the sql server in a docker container when running the application).  
- - For the challenge I used the Aspire starter template as a starting point, and with it Blazor as a frontend technology. Right now I feel more familiar with Blazor than React. So everything I do of course can be achieved also easily with React, it is just me, who needs a little bit more time to get familiar with the syntax (I didn't use React for more than a year).

- Setup information:  
- - You must have Visual studio 2022 installed, with at least version 17.10.0. This is the version, which includes the new Dotnet Aspire package.  
- - You must have a running Docker desktop.  
- - One or more videos are required to use this demo app. I attach the video I used in the mail. This video needs to be placed somewhere in your machine, I used: "C:\\temp\\videos". But you can use a custom path, just before starting the application update the VideosLocation key in the EB_Challenge.VideosService appsettings.Development.json.  
- - Set the Aspire AppHost as the startup project.  
- - When you start the application the sql server requires around 1 minute (based on the owner's machine I guess) to heat up. Until it is done the demo is not functioning.

- With Challenge two I wanted to try out some features regarding multiple Video streaming and some metadata regarding the video streaming window. A feature is to have synchronization between clients. In the end I had time to persist the data, so more clients can join at a later point of time, and still see the same result.  
- - After you start the application the Aspire dashboard can be seen. Here the list of the services, and also can check logs, metrics and traces. These things just came with using dotnet Aspire, so Open Telemetry is included in every service.  
- - I used the starter template so basically the apiservice with the weatherforecast endpoint is irrelevant.  
- - The services:    
	- - domainservice - contains EF core logic for persisting and fetching the state.    
	- - signalrservice - contains the signalR hub for synchronization between the clients    
	- - videoservice - serves the video files based on their name, but uses a static file path from the file system    
	- - webfrontend - blazor based webapp, it uses blazor server side technology.  
- - Features:    
	- - Open the url of the webfrontend and navigate to the Videos tab (just a reminder, the tab might open slowly because waiting for the sql server).     
	- - Here you can customize the width, height and video name. Clicking on Add creates a window in the preferred size, and if the video name is correct it can be played (uses the basic html video functionality). Can clear all windows by clicking the Clear button.    
	- - All windows should be presented in the same way if opening the same url in a new tab or in a new browser.    
	- - Syncing is real time between clients, and the persistence is permanent as long as the sql server lives (restarting the application starts a new instance).
		
- I think I had many questions for a customer with this feature set. I mean two hour is not enough for many things to do.  
- - What is the purpose of this software?  
- - What are the most common use-cases when using this software, or at least what should be? 
- - What are the design expectations? So is bootstrap a good styling library, or should I choose a different one, like Material.  
- - Working in an agile manner helps create software which better suits the customer. So feedback during the development cycle can be crucial. 
	
- If I had more time to work on the challenge, I should focus on making it prettier.   
- - First step should be to use more bootstrap functionalities. 
- - Probably use flexbox for the videos rather than this grid.  
- - Can be a good feature to select the video from an available pool. And also can be a good one to upload videos, or store them in a more organized manner like a storage account.  
- - Use a more advanced video playing mechanism.  
- - I originally wanted to introduce a feature about selecting a window and changing its metadata (width, height or even the video).  
- - Why these? Because I feel the app doesn't look really good. Next I imagine that there are many bugs if starting to make some QA over the UI. It also includes making the system more robust, so resiliency is already present, but not for signalR for example, a reconnect logic can be beneficial.