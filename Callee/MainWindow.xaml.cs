using System;
using System.Windows;

namespace Callee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ILog
    {

        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => DataContext = new MainWindowViewModel(this);
            Unloaded += (sender, args) => ((IDisposable)DataContext).Dispose();
        }

        public void Log(string log)
        {
            if (LogBox.Dispatcher.CheckAccess())
            {
                LogBox.AppendText(log);
            }
            else
            {
                LogBox.Dispatcher.Invoke(new Action(() => Log(log)));
            }
        }
    }
}
