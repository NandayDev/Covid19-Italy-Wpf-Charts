using System;

namespace CovidCharts
{
    public class NationalTrendDailyData
    {
        public NationalTrendDailyData()
        {
        }

        public NationalTrendDailyData(DateTime date, int hospitalizedWithSymptoms, int intensiveCare, int hospitalizedTotal, int inHomeIsolation, int positiveTotal, 
            int variazioneTotalePositivi, int newPositives, int healedAndDischarged, int deceased, int totalCases, int tested)
        {
            Date = date;
            HospitalizedWithSymptoms = hospitalizedWithSymptoms;
            IntensiveCare = intensiveCare;
            TotalHospitalized = hospitalizedTotal;
            InHomeIsolation = inHomeIsolation;
            TotalPositives = positiveTotal;
            VariazioneTotalePositivi = variazioneTotalePositivi;
            NewPositives = newPositives;
            HealedAndDischarged = healedAndDischarged;
            Deceased = deceased;
            TotalCases = totalCases;
            TotalTested = tested;
        }

        public DateTime Date { get; set; }

        public int HospitalizedWithSymptoms { get; set; }

        public int IntensiveCare { get; set; }

        public int TotalHospitalized { get; set; }

        public int InHomeIsolation { get; set; }

        public int TotalPositives { get; set; }

        public int VariazioneTotalePositivi { get; set; }
        
        public int NewPositives { get; set; }

        public int HealedAndDischarged { get; set; }
        
        public int Deceased { get; set; }
        
        public int TotalCases { get; set; }
        
        public int TotalTested { get; set; }

    }
}
