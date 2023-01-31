using System.Windows;
using System.Windows.Controls;

namespace LeadMeLabs_Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Reference to the main logging consoles
        public static TextBox? messageInput;
        public static TextBox? sentConsole;
        public static TextBox? receiveConsole;

        public MainWindow()
        {
            InitializeComponent();
            messageInput = this.InputBox;
            sentConsole = this.SentWindow;
            receiveConsole = this.ReceiveWindow;

            MockConsole.WriteSentLine("Program Started");
            MockConsole.WriteReceiveLine("Program Started");
        }
    }
}
