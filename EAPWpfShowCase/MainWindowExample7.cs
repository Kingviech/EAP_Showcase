using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EAPWpfShowCase
{
    public partial class MainWindow
    {
        BackgroundWorker bw;

        private void Example7_Click(object sender, RoutedEventArgs e)
        {
            bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            bw.RunWorkerAsync();

            Ex7Start.IsEnabled = false;
            Ex7Stop.IsEnabled = true;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Canceled!");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error: " + e.Error.Message);
            }
            else
            {
                MessageBox.Show($"Done! Result: {(int)e.Result}");
            }
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Ex7Progress.Value = e.ProgressPercentage;
            });
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            int input = 5;
            int result = input;
            for (int i = 0; i < input; i++)
            {
                if(worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                result *= input;
                Thread.Sleep(1000);

                // Calculate progress and fire progress changed event
                int curProgress = (int)Math.Round((float)(i + 1) / input * 100, 0);
                worker.ReportProgress(curProgress);
            }
            e.Result = result;
        }

        private void Ex7Stop_Click(object sender, RoutedEventArgs e)
        {
            bw.CancelAsync();
            Ex7Start.IsEnabled = true;
            Ex7Stop.IsEnabled = false;
        }
    }
}
