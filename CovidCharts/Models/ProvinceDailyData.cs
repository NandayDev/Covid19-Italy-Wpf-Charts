using System;

namespace CovidCharts
{
    public class ProvinceDailyData
    {
        public ProvinceDailyData()
        {
        }

        public ProvinceDailyData(DateTime data, ItalianProvince provincia, int totaleCasi)
        {
            Date = data;
            Province = provincia;
            TotalCases = totaleCasi;
        }

        public DateTime Date { get; set; }

        public ItalianProvince Province { get; set; }

        public int TotalCases { get; set; }
    }
}
