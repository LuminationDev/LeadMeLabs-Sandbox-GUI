# LeadMeLabs-Sandbox-GUI
A basic application to send and receive messages through a namedpipe server/client.

The application is using the C# leadme_api.dll. 
- The server is running the ParentPipeServer with the pipe name set to "leadme_parent_api".
- The client tries to connect to another pipe server with the name "leadme_api".

The GUI has two console screens, one for the messages sent from the Sandbox and another for the message received from an external application.
