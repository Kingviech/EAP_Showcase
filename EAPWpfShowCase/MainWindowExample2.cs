using EAPWpfShowCase.Examples;
using System.Windows;

namespace EAPWpfShowCase
{
    public partial class MainWindow
    {
        private void Example2_Click(object sender, RoutedEventArgs e)
        {
            var asynchronous = new Asynchronous();
            asynchronous.LongRunningTaskCompleted += Asynchronous_LongRunningTaskCompleted;
            asynchronous.LongRunningTaskAsync(5);
            Example2Started.Visibility = Visibility.Visible;
        }

        private void Asynchronous_LongRunningTaskCompleted(object sender, LongRunningTaskCompletedEventArgs e)
        {
            // Required, because this event will not be called inside the UI Thread, so the access to
            // UI elements is not possible.
            Application.Current.Dispatcher.Invoke(() =>
            {
                Example2Started.Content = "Finished";
            });

            // Handle errors or cancelled state
            if (e.Error != null)
            {
                MessageBox.Show("Exception occurred: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Operation was cancelled!");
            }
            else
            {
                MessageBox.Show($"Result was: {e.Result}");
            }
        }        
    }
}