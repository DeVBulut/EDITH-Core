using System.Windows;
using System.Windows.Input;

namespace EdithAIAssistant
{
    public partial class MainWindow : Window
    {
        private readonly SpeechListener _speechListener = new();

        public MainWindow()
        {
            InitializeComponent();
            _speechListener.Start();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Enable dragging the window from anywhere
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
