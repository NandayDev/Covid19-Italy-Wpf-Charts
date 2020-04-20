using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CovidCharts.Data
{
    internal class DataRepository
    {
        internal static DataRepository Instance { get; } = new DataRepository();

        internal List<NationalTrendDailyData> NationalTrendData { get; private set; } = new List<NationalTrendDailyData>();

        internal List<ProvinceDailyData> DatiProvince { get; private set; } = new List<ProvinceDailyData>();

        internal async Task Initialize()
        {
            var streamAndamentoNazionaleTask = CsvStreamUtility.GetCsvStream("https://github.com/pcm-dpc/COVID-19/raw/master/dati-andamento-nazionale/dpc-covid19-ita-andamento-nazionale.csv");
            var provinceTask = CsvStreamUtility.GetCsvStream("https://github.com/pcm-dpc/COVID-19/raw/master/dati-province/dpc-covid19-ita-province.csv");

            var streamAndamentoNazionale = await streamAndamentoNazionaleTask;
            using var sr = new StreamReader(streamAndamentoNazionale);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var splits = sr.ReadLine().Split(',');
                if (DateTime.TryParse(splits[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    int ricoveratiConSintomi = int.Parse(splits[2]);
                    int terapiaIntensiva = int.Parse(splits[3]);
                    int totale_ospedalizzati = int.Parse(splits[4]);
                    int isolamento_domiciliare = int.Parse(splits[5]);
                    int totale_positivi = int.Parse(splits[6]);
                    int variazione_totale_positivi = int.Parse(splits[7]);
                    int nuovi_positivi = int.Parse(splits[8]);
                    int dimessi_guariti = int.Parse(splits[9]);
                    int deceduti = int.Parse(splits[10]);
                    int totale_casi = int.Parse(splits[11]);
                    int tamponi = int.Parse(splits[12]);
                    NationalTrendData.Add(new NationalTrendDailyData(date, ricoveratiConSintomi, terapiaIntensiva, totale_ospedalizzati, isolamento_domiciliare, totale_positivi,
                        variazione_totale_positivi, nuovi_positivi, dimessi_guariti, deceduti, totale_casi, tamponi));
                }
            }

            var province = await provinceTask;
            using var sr2 = new StreamReader(province);
            sr2.ReadLine();
            while (!sr2.EndOfStream)
            {
                var splits = sr2.ReadLine().Split(',');
                if (DateTime.TryParse(splits[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    ItalianProvince provincia = Province.FromInt(int.Parse(splits[4]));
                    if (provincia != ItalianProvince.UNKNOWN)
                    {
                        int totale_casi = int.Parse(splits[9]);
                        DatiProvince.Add(new ProvinceDailyData(date, provincia, totale_casi));
                    }
                }
            }
        }
    }
}