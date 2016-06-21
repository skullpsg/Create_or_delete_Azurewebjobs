# Create_or_delete_Azurewebjobs
In this project I have created azure webjobs sample,and added two other console project one will be used to create webjobs by reading a zip file and another one will delete the webjob by its name.

# Environments
1.vs 2015 

# How to work with

1. download the Project.

2. change the connection string of "AzureWebJobsDashboard" and "AzureWebJobsStorage" in Web.config of samplewebjob.
 
   connection string expects storage accountname and its key.To get that you have to create storage account in azure.
  
   Go here : https://portal.azure.com/
  
   Then In filter type storage account -->  Create an account --> After creating account click that storage account  --> settings  --> Access Key. you can be able to see the storage account name and key.
  
3. Build  samplewebjob project in debug mode/release mode.

4. Go to samplewebjob project(~bin\debug) if you builded your project in debug mode.
   
    step 1 : Except folders, copy remaining files and create a folder named  "Web_host" in your desktop.

    step 2 : paste all the files inside that folder.

    step 3 : Zip that folder as "Web_host.Zip" and move that zipped file into createWebjob project folder( ~\CreateWebjob\bin\Debug\Zip_File).
   
    step 4 : Replace the Zip file in the destination.
   

5. Now in your solution go to CreateWebjob Project,then in Program.cs file

   step 1 : If you have web app publishing credentials configure that in program.cs
  
   step 2 : https://{Website_Url_Name}.scm.azurewebsites.net/api/{Web_JobsType}/  fill the Website_Url_Name as well as Web_JobsType.
 
 if you have no web apps 

  i) create one in azure (https://portal.azure.com/#blade/HubsExtension/BrowseResourceBlade/resourceType/Microsoft.Web%2Fsites)

  ii) click that web app new blade will open in top you can be able to see tab list like (settings,tools,browse etc).
 
  iii) click download arrow(Get Publish) icon.
 
  iv) In that file you can get userName and userPWD.
 
6. Run CreateWebjob Project.

7. follow the step 5 to configure DeleteWebJobByName and run the project.

   
