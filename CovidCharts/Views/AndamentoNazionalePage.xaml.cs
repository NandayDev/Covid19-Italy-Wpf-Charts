using CovidCharts.Data;
using CovidCharts.Properties;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace CovidCharts.Views
{
    /// <summary>
    /// Interaction logic for AndamentoNazionalePage.xaml
    /// </summary>
    public partial class AndamentoNazionalePage : UserControl
    {
        public AndamentoNazionalePage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            chart.Visibility = System.Windows.Visibility.Visible;
            hintText.Visibility = System.Windows.Visibility.Collapsed;
            checkBoxVariazioni.Visibility = System.Windows.Visibility.Visible;

            var series = new LineSeries
            {
                Values = new ChartValues<ObservablePoint>(),
            };

            bool showIncrementsOnly = checkBoxVariazioni.IsChecked.Value;
            Func<NationalTrendDailyData, int> getDataFunction = null;

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    getDataFunction = d => d.HospitalizedWithSymptoms;
                    series.Title = Strings.HospitalizedWithSymptoms;
                    break;

                case 1:
                    getDataFunction = d => d.IntensiveCare;
                    series.Title = Strings.IntensiveCare;
                    break;

                case 2:
                    getDataFunction = d => d.TotalHospitalized;
                    series.Title = Strings.TotalHospitalized;
                    break;

                case 3:
                    getDataFunction = d => d.InHomeIsolation;
                    series.Title = Strings.InHomeIsolation;
                    break;

                case 4:
                    getDataFunction = d => d.TotalPositives;
                    series.Title = Strings.TotalPositives;
                    break;

                case 5:
                    getDataFunction = d => d.NewPositives;
                    series.Title = Strings.NewPositives;
                    break;

                case 6:
                    getDataFunction = d => d.HealedAndDischarged;
                    series.Title = Strings.HealedAndDischarged;
                    break;

                case 7:
                    getDataFunction = d => d.Deceased;
                    series.Title = Strings.Deceased;
                    break;

                case 8:
                    getDataFunction = d => d.TotalCases;
                    series.Title = Strings.TotalCases;
                    break;

                case 9:
                    getDataFunction = d => d.TotalTested;
                    series.Title = Strings.TotalTested;
                    break;
            }

            if (showIncrementsOnly)
            {
                int lastValue = 0;
                for (int i = 0; i < DataRepository.Instance.NationalTrendData.Count; i++)
                {
                    NationalTrendDailyData dailyData = DataRepository.Instance.NationalTrendData[i];
                    series.Values.Add(new ObservablePoint(dailyData.Date.ToOADate(), getDataFunction(dailyData) - lastValue));
                    lastValue = getDataFunction(dailyData);
                }
            }
            else
            {
                foreach (var dailyData in DataRepository.Instance.NationalTrendData)
                {
                    series.Values.Add(new ObservablePoint(dailyData.Date.ToOADate(), getDataFunction(dailyData)));
                }
            }

            chart.Series.Clear();
            chart.Series.Add(series);
            chart.AxisX.Clear();
            chart.AxisX.Add(new Axis());
            chart.AxisX[0].LabelFormatter = d => DateTime.FromOADate(d).ToShortDateString();
        }

        private void CheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(null, null);
        }
    }
}
