using EAPWpfShowCase.Examples;
using System.Windows;

namespace EAPWpfShowCase
{
    public partial class MainWindow
    {
        private void Example1_Click(object sender, RoutedEventArgs e)
        {
            var synchronous = new Synchronous();
            int result = synchronous.LongRunningTask(5);
            MessageBox.Show($"Result was: {result}");
        }
    }
}