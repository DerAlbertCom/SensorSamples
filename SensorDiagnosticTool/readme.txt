===== Install instruction for Sensor Diagnostic Tool =====
1. Download and extract onto your computer the Sensor and Location .NET Interop Sample Library source code: 
http://code.msdn.microsoft.com/SensorsAndLocation
2. Open the Windows7.sln file with Visual Studio from the following location:
Windows7IntegrationLibrary_Sensor_and_Location\Windows7IntegrationLibrary_Sensor_and_Location\Windows7.sln
3. Compile the "Windows7.SensorsAndLocation" project.
4. Load SensorDiagnosticTool.sln.
5. Add a reference in the SensorDiagnosticTool project to  Windows7.SensorsAndLocation.dll from the following location:
Windows7IntegrationLibrary_Sensor_and_Location\Windows7IntegrationLibrary_Sensor_and_Location\Windows7.SensorAndLocation\bin
6. Build and run the SensorDiagnosticTool project.

===== Using the Sensor Diagnostic Tool =====

== General ==
From the tree view, select a sensor or location option (for example, LatLong or CivicAddress) to view specific information.

== Events menu ==
Show Events – Turned on by default. When this is enabled and events occur, the tool updates the Properties, Data, and Events boxes. Disable this to stop events from updating information in the boxes.
Log Events -- Prompts you to save an xml file that contains data of all events for all sensors if the events happen while the tool is running.

== Sensors menu ==
Refresh -- Updates the Properties, Data, and Events boxes. You can use this if Show Events is disabled.
Enable Sensors -- Prompts you to enable all sensors installed on the computer.
Launch Control Panel -- Starts the Location and Other Sensors control panel.