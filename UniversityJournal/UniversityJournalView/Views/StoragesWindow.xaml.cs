using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UniversityJournalView.ViewModels;

namespace UniversityJournalView.Views
{
    /// <summary>
    /// Interaction logic for StoragesWindow.xaml
    /// </summary>
    public partial class StoragesWindow : Window
    {
        public StoragesWindow()
        {
            DataContext = new StoragesViewModel();
            InitializeComponent();
        }

        private void dataGridAutoColumnGenerationHandler
            (object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!(e.PropertyType == typeof(bool) ||
                e.PropertyType == typeof(int) ||
                e.PropertyType == typeof(short) ||
                e.PropertyType == typeof(string) ||
                e.PropertyType == typeof(DateTime)))
            {
                e.Cancel = true;
            }
        }
    }
}
