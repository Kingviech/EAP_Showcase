using EAPWpfShowCase.Examples;
using System.Windows;

namespace EAPWpfShowCase
{
    /// <summary>
    /// Reused delegate and event args from ex2
    /// </summary>
    public partial class MainWindow
    {
        private void Example3_Click(object sender, RoutedEventArgs e)
        {
            var asynchronous = new AsynchronousWithException();

            // Same event handler, exception handling is already preset at this handler
            asynchronous.LongRunningTaskCompleted += AsynchronousWithException_LongRunningTaskCompleted;
            asynchronous.LongRunningTaskAsync(5);
            Example3Started.Visibility = Visibility.Visible;
        }

        private void AsynchronousWithException_LongRunningTaskCompleted(object sender, LongRunningTaskCompletedEventArgs e)
        {
            // Required, because this event will not be called inside the UI Thread, so the access to
            // UI elements is not possible.
            Application.Current.Dispatcher.Invoke(() =>
            {
                Example3Started.Content = "Finished";
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