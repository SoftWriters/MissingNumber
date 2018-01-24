using Microsoft.Win32;
using System.Windows;

namespace MissingNumber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        /// <summary>
        /// View Model for this window
        /// </summary>
        public MainViewModel ViewModel { get; private set; }

        private void SelectFileButtonSelected(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileSelector = new OpenFileDialog();
            if (fileSelector.ShowDialog() == true)
            {
                ViewModel.ReadFile(fileSelector.FileName);
            }
        }
    }
}
