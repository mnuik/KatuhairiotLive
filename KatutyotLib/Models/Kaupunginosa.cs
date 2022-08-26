using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatutyotLib.Models
{
    public class Kaupunginosa
    {
        public int id; // Kohteen yksilöivä tunniste.Luotettava, kattavasti olemassa oleva tieto.
        public string aluejako; // Aluejaon tyyppi.Luotettava, kattavasti olemassa oleva tieto.
        public string kunta; // Kunta.Luotettava, kattavasti olemassa oleva tieto.
        public string tunnus; // Kaupunginosan tunnus. Luotettava, kattavasti olemassa oleva tieto.
        public string nimi_fi; // Kaupunginosan suomenkielinen nimi.Luotettava, kattavasti olemassa oleva tieto.
        public string nimi_se; // Kaupunginosan ruotsinkielinen nimi.Luotettava, kattavasti olemassa oleva tieto.
        public DateTime yhtluontipvm; // Kohteen luontipäivämäärä (yyyy-mm-dd). Luotettava, kattavasti olemassa oleva tieto.
        public DateTime yhtmuokkauspvm; // Kohteen edellinen muokkauspäivämäärä(yyyy-mm-dd). Luotettava, kattavasti olemassa oleva tieto.
        public string yhtdatanomistaja; // Aineiston omistaja.Luotettava, kattavasti olemassa oleva tieto.
        public DateTime paivitetty_tietopalveluun; // Tietopalvelun tallennuspäivämäärä (yyyy-mm-dd). Luotettava, kattavasti olemassa oleva tieto.
    }
}
