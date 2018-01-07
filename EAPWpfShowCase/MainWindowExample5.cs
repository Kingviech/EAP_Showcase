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
        private void Example5_Click(object sender, RoutedEventArgs e)
        {
            var progress = new AsynchronousProgress();
            progress.LongRunningTaskCompleted += Progress_LongRunningTaskCompleted;
            progress.LongRunningTaskProgressChanged += Progress_LongRunningTaskProgressChanged;
            progress.LongRunningTaskAsync(5);            
        }

        private void Progress_LongRunningTaskProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Ex5Progress.Value = e.ProgressPercentage;
            });
        }

        private void Progress_LongRunningTaskCompleted(object sender, LongRunningTaskCompletedEventArgs e)
        {           
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
