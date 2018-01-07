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
        AsynchronousStoppable stoppable = new AsynchronousStoppable();

        private void Example4_Click(object sender, RoutedEventArgs e)
        {
            stoppable = new AsynchronousStoppable();
            stoppable.LongRunningTaskCompleted += AsynchronousStoppable_LongRunningTaskCompleted;
            stoppable.LongRunningTaskAsync(5);
            Example4Started.Visibility = Visibility.Visible;
            Ex4Stop.IsEnabled = true;
            Ex4Start.IsEnabled = false;
        }

        private void Example4Stop_Click(object sender, RoutedEventArgs e)
        {
            stoppable.LongRunningTaskCancelAsync();
        }

        private void AsynchronousStoppable_LongRunningTaskCompleted(object sender, LongRunningTaskCompletedEventArgs e)
        {
            // Required, because this event will not be called inside the UI Thread, so the access to
            // UI elements is not possible.
            Application.Current.Dispatcher.Invoke(() =>
            {
                Example4Started.Content = "Finished";
                Ex4Stop.IsEnabled = false;
                Ex4Start.IsEnabled = true;
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
