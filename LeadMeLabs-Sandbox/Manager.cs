using leadme_api;
using System.Threading.Tasks;

namespace LeadMeLabs_Sandbox
{
    public static class Manager
    {
        /// <summary>
        /// An instance of the PipeClient with a set timeout period.
        /// </summary>
        private static PipeClient _pipeClient = new PipeClient(MockConsole.WriteReceiveLine, 5);

        /// <summary>
        /// Start the pipe server for the local applicaiton using the leadme_api.dll, the pipe server
        /// takes in two parameters which are used to log the outputs of messages or statuses from 
        /// within the .dll
        /// </summary>
        public static void StartPipeServer()
        {
            ParentPipeServer.Run(MockConsole.WriteSentLine, MockConsole.WriteReceiveLine);
        }

        /// <summary>
        /// Send a message to an application that is running a regular PipeServer.
        /// </summary>
        /// <param name="message">A string representing the message to be sent.</param>
        public static void SendPipeMessage() {
            if(MainWindow.messageInput == null)
            {
                return;
            }

            string message = MainWindow.messageInput.Text;

            MockConsole.WriteSentLine(message);
            _pipeClient.Send(message);

            MainWindow.messageInput.Text = "";
        }

        /// <summary>
        /// Clear both the sent and receieve consoles of any information 
        /// </summary>
        public static void ClearConsole() {
            MockConsole.clearConsole();
        }

        /// <summary>
        /// Stop the current pipe server, wait for a set period and then restart the server.
        /// </summary>
        public static void RestartPipeServer() {
            ParentPipeServer.Close();

            Task.Delay(2000).Wait();

            StartPipeServer();
        }
    }
}
