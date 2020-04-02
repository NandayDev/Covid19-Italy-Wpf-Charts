using CovidCharts.Data;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CovidCharts.Views
{
    /// <summary>
    /// Interaction logic for ProvincePage.xaml
    /// </summary>
    public partial class ProvincePage : UserControl
    {
        public ProvincePage()
        {
            InitializeComponent();
            var province = new List<string>();
            foreach (ItalianProvince provincia in Province.provinces)
                province.Add(provincia.ToString());
            province.Sort();
            comboBox.ItemsSource = province;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chart.Visibility = System.Windows.Visibility.Visible;
            hintText.Visibility = System.Windows.Visibility.Collapsed;

            string selectedProvincia = (string)comboBox.SelectedItem;
            ItalianProvince provincia = ItalianProvince.UNKNOWN;
            foreach (ItalianProvince prov in Province.provinces)
                if (prov.ToString() == selectedProvincia)
                    provincia = prov;
            var series = new LineSeries
            {
                Values = new ChartValues<ObservablePoint>(),
                Title = "Totale casi"
            };
            foreach (var dato in DataRepository.Instance.DatiProvince.Where(dp => dp.Province == provincia))
            {
                series.Values.Add(new ObservablePoint(dato.Date.ToOADate(), dato.TotalCases));
            }

            chart.Series.Clear();
            chart.Series.Add(series);
            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis());
            chart.AxisX[0].LabelFormatter = d => DateTime.FromOADate(d).ToShortDateString();
        }
    }
}
