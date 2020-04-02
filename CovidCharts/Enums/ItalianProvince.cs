using System;
using System.Collections.Generic;
using System.Linq;

namespace CovidCharts
{
    public enum ItalianProvince
    {
        UNKNOWN = 0,

        Chieti = 69,
        L_Aquila = 66,
        Pescara = 68,
        Teramo = 67,
        Matera = 77,
        Potenza = 76,
        Bolzano = 21,
        Catanzaro = 79,
        Cosenza = 78,
        Crotone = 101,
        Reggio_Calabria = 80,
        Vibo_Valentia = 102,
        Avellino = 64,
        Benevento = 62,
        Caserta = 61,
        Napoli = 63,
        Salerno = 65,
        Bologna = 37,
        Ferrara = 38,
        Forlì_Cesena = 40,
        Modena = 36,
        Parma = 34,
        Piacenza = 33,
        Ravenna = 39,
        Reggio_Emilia = 35,
        Rimini = 99,
        Gorizia = 31,
        Pordenone = 93,
        Trieste = 32,
        Udine = 30,
        Frosinone = 60,
        Latina = 59,
        Rieti = 57,
        Roma = 58,
        Viterbo = 56,
        Genova = 10,
        Imperia = 8,
        La_Spezia = 11,
        Savona = 9,
        Bergamo = 16,
        Brescia = 17,
        Como = 13,
        Cremona = 19,
        Lecco = 97,
        Lodi = 98,
        Mantova = 20,
        Milano = 15,
        Monza_Brianza = 108,
        Pavia = 18,
        Sondrio = 14,
        Varese = 12,
        Ancona = 42,
        Ascoli_Piceno = 44,
        Fermo = 109,
        Macerata = 43,
        Pesaro_Urbino = 41,
        Campobasso = 70,
        Isernia = 94,
        Alessandria = 6,
        Asti = 5,
        Biella = 96,
        Cuneo = 4,
        Novara = 3,
        Torino = 1,
        Verbano_Cusio_Ossola = 103,
        Vercelli = 2,
        Bari = 72,
        Barletta_Andria_Trani = 110,
        Brindisi = 74,
        Foggia = 71,
        Lecce = 75,
        Taranto = 73,
        Cagliari = 92,
        Nuoro = 91,
        Oristano = 95,
        Sassari = 90,
        Sud_Sardegna = 111,
        Agrigento = 84,
        Caltanissetta = 85,
        Catania = 87,
        Enna = 86,
        Messina = 83,
        Palermo = 82,
        Ragusa = 88,
        Siracusa = 89,
        Trapani = 81,
        Arezzo = 51,
        Firenze = 48,
        Grosseto = 53,
        Livorno = 49,
        Lucca = 46,
        Massa_Carrara = 45,
        Pisa = 50,
        Pistoia = 47,
        Prato = 100,
        Siena = 52,
        Trento = 22,
        Perugia = 54,
        Terni = 55,
        Aosta = 7,
        Belluno = 25,
        Padova = 28,
        Rovigo = 29,
        Treviso = 26,
        Venezia = 27,
        Verona = 23,
        Vicenza = 24,
    }

    internal static class Province
    {
        internal static readonly IEnumerable<ItalianProvince> provinces = Enum.GetValues(typeof(ItalianProvince)).Cast<ItalianProvince>();

        internal static ItalianProvince FromInt(int i)
        {
            foreach (var provincia in provinces)
            {
                if ((int)provincia == i)
                    return provincia;
            }
            return ItalianProvince.UNKNOWN;
        }
    }
}
