using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace HomeServices.Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MusicApi _musicApi = new MusicApi();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var fd = new FolderBrowserDialog();
            fd.ShowDialog();
            lbDirectories.Items.Add(fd.SelectedPath);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lbDirectories.Items.Remove(lbDirectories.SelectedItem);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            var responses = new List<string>();

            var directories = Directory.GetDirectories(
                lbDirectories.Items[0].ToString(), "", SearchOption.AllDirectories).ToList();

            if(directories.Count > 1)
            {
                pbLoading.Maximum = directories.Count;
                foreach (var d in directories)
                {
                    responses.Add(_musicApi.AddDirectory(d));
                    pbLoading.Value++;
                }
            }
            else
            {
                pbLoading.Maximum = lbDirectories.Items.Count;
                foreach (var i in lbDirectories.Items)
                {
                    responses.Add(_musicApi.AddDirectory(i.ToString()));
                    pbLoading.Value++;
                }
            }
            
            foreach(string r in responses)
            {
                System.Windows.MessageBox.Show(r);
            }

            pbLoading.Value = 0;
        }
    }
}
