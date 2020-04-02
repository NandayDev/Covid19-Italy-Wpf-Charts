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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CovidCharts.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AndamentoNazionaleClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangePage(CovidPage.ANDAMENTO_NAZIONALE);
        }

        private void ProvinceClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.ChangePage(CovidPage.PROVINCE);
        }
    }
}
