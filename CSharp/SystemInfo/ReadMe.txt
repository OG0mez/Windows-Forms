In this solution contains forms to be able to view detailed information about your PC in a few different areas.

The types of information you're able to view is: 
  - Hardware Information
  - System Information
  - Memory Information
  - Storage Information
  - Network Information
  - Developer Information
  - Utility Information
  - Account and Security Information

It uses the System.management namespace so we're able to use the ManagementObjectSearcher, ManagementObject, and PropertyData classes. 

It checks for information for the given "keys" and adds its property data to a list view item if something has been found. 
The keys being searched for are from this microsoft link right here. https://msdn.microsoft.com/en-us/library/aa389273.aspx


***This project is also inside of my LoginPanel project inside of my Windows-Forms respository. It's available as a form to use inside once logged in. 
