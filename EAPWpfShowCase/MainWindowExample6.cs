using EAPWpfShowCase.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EAPWpfShowCase
{
    public partial class MainWindow
    {
        private void Example6_Click(object sender, RoutedEventArgs e)
        {
            var partialResult = new AsynchronousPartialResults();
            partialResult.LongRunningTaskCompleted += PartialResult_LongRunningTaskCompleted;
            partialResult.LongRunningTaskProgressChanged += PartialResult_LongRunningTaskProgressChanged;
            partialResult.LongRunningTaskAsync(5);
            Example6Started.Visibility = Visibility.Visible;
        }

        private void PartialResult_LongRunningTaskProgressChanged(object sender, PartialResultProgressChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {                
                Example6PartialResult.Content = e.PartialResult.ToString();
            });
        }

        private void PartialResult_LongRunningTaskCompleted(object sender, LongRunningTaskCompletedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Example6Started.Content = "Finished";
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
