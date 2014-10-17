IQ-Wall Screensaver
===================

The IQ-Wall Screensaver is a fullscreen web browser designed to be used as a screensaver for the [IQ-Wall](http://rt.uits.iu.edu/visualization/avl/systems/iq-wall.php) tiled displays developed at Indiana University. It runs from the Windows login screen as a sort of "attract mode" while the system is idle.

Developed by the [Advanced Visualization Lab](www.avl.iu.edu) in C#, using version 1.7.3 of the [Awesomium](http://www.awesomium.com/) web browser control.

Build Instructions
------------------

Open the solution file in Visual Studio and build in release mode. Last tested in Visual Studio 2012. It might work with MonoDevelop, but that hasn't been tested. The build will create a directory called iq-wall-screensaver\iq-wall-screensaver\bin\Release containing the binaries for distribution. 

Installation
------------

Copy the contents of iq-wall-screensaver\iq-wall-screensaver\bin\Release to another directory. We usually use C:\iq-wall-screensaver or C:\screensaver, but you should be able to put it anywhere. Launch iq-wall-screensaver.exe to make sure everything works properly. The browser should launch fullscreen on the system's primary monitor. To kill the application, you will need to right-click the icon in the taskbar or perhaps even use the task manager.

To use the browser as a login screensaver, you must edit your registry. Thus, it is recommended that you make a backup of you registry before continuing. Then right-click install_screensaver.reg and select Edit, or open the file a text editor. Set the value for SCRNSAVE.EXE to the path of the browser exe file. You can also set the delay before the screensaver launches with ScreenSaveTimeOut. When you are done editing, merge install_screensaver.reg into your registry by either double-clicking it or right-clicking and selecting Merge. Test the new registry setting by logging out and waiting for the browser to launch.

Configuration
-------------

Open iq-wall-screensaver.exe.config in a text editor. Locate the section that looks like:

```xml
<appSettings>
    <add key="url" value="http://avl.iu.edu" />
    <add key="refreshDelayInSeconds" value="30" />
    <add key="ClientSettingsProvider.ServiceUri" value="" />
</appSettings>
```

Set the url value to the URL you want the browser to display. The refreshDelayInSeconds value tells the browser how long to wait before refreshing the page. If you don't want the browser to refresh, your only option is to set the delay to be very long (or edit the code to accept a null value). 
