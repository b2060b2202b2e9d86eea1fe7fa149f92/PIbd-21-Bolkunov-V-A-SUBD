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
    /// Interaction logic for ViewsWindow.xaml
    /// </summary>
    public partial class ViewsWindow : Window
    {
        public ViewsWindow()
        {
            DataContext = new ViewsViewModel();
            InitializeComponent();
        }
    }
}
