using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace LeadMeLabs_Sandbox
{
    public static class MockConsole
    {
        private static string _sentTextStr = "";
        private static int _receiveLineCount = 0;
        private static string _receiveTextStr = "";
        private static int _sentLineCount = 0;
        private static int _lineLimit = 250;

        //The functions below handle updating the mock console that is present within the MainWindow. This
        //proccess allows other parts of the project to display information to a user.
        
        /// <summary>
        /// Log messages that are being sent to the 
        /// </summary>
        public static string SentTextstr
        {
            get
            {
                return _sentTextStr;
            }
            set
            {
                _sentTextStr = value;
            }
        }

        /// <summary>
        /// Log messages recieved from an external application running the LeadMe Client server.
        /// </summary>
        public static string ReceiveTextstr
        {
            get
            {
                return _receiveTextStr;
            }
            set
            {
                _receiveTextStr = value;
            }
        }

        /// <summary>
        /// Clear the MockConsole of all previous messages. The cleared message will be printed regardless
        /// of log level as to alert the user this is deliberate.
        /// </summary>
        public static void clearConsole()
        {
            SentTextstr = "";
            WriteSentLine("Cleared");

            ReceiveTextstr = "";
            WriteReceiveLine("Cleared");
        }

        /// <summary>
        /// Log a message to the mock console within the Station form, this does not take into account the current log level.
        /// </summary>
        /// <param name="message">A string to be printed to the console.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteSentLine(string message)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                if (MainWindow.sentConsole == null) return;

                if (message == "Cleared")
                {
                    MainWindow.sentConsole.Text = SentTextstr;
                }
                else
                {
                    SentTextstr = SentTextstr + DateStamp() + message + "\n";
                    MainWindow.sentConsole.Text = TrimSentConsole();
                    _sentLineCount++;
                }
            });
        }

        /// <summary>
        /// Log a message to the mock console within the Station form, this does not take into account the current log level.
        /// </summary>
        /// <param name="message">A string to be printed to the console.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteReceiveLine(string message)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                if (MainWindow.receiveConsole == null) return;

                if (message == "Cleared")
                {
                    MainWindow.receiveConsole.Text = ReceiveTextstr;
                }
                else
                {
                    ReceiveTextstr = ReceiveTextstr + DateStamp() + message + "\n";
                    MainWindow.receiveConsole.Text = TrimReceiveConsole();
                    _receiveLineCount++;
                }
            });
        }


        private static string DateStamp()
        {
            DateTime now = DateTime.Now;
            return "[" + now.ToString("dd/MM") + " | " + now.ToString("hh:mm:ss") + "] ";
        }

        /// <summary>
        /// Trim the earliest message from the console to stop an infinite scroll occuring.
        /// </summary>
        private static string TrimSentConsole()
        {
            if (_sentLineCount >= _lineLimit)
            {
                _sentLineCount--;
                var lines = Regex.Split(SentTextstr, "\r\n|\r|\n").Skip(1);
                return string.Join(Environment.NewLine, lines.ToArray());
            }

            return SentTextstr;
        }

        private static string TrimReceiveConsole()
        {
            if (_receiveLineCount >= _lineLimit)
            {
                _receiveLineCount--;
                var lines = Regex.Split(ReceiveTextstr, "\r\n|\r|\n").Skip(1);
                return string.Join(Environment.NewLine, lines.ToArray());
            }

            return ReceiveTextstr;
        }
    }
}
