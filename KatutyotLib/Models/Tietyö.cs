using System.ComponentModel;

namespace KatutyotLib.Models
{
    public class Tietyö
    {
        public long id { get; set; }  // Kohteen yksilöivä tunniste
        public string? hakemus { get; set; } // Hakemuksen tyyppi
        public string? hakemustunnus { get; set; } // Hakemuksen tunnus Allu-järjestelmässä
        public DateTime tyo_alkaa { get; set; } // Työn alkupäivä, päivämäärämuodossa
        public DateTime tyo_paattyy { get; set; }  // Työn loppupäivä, päivämäärämuodossa
        public string tyon_tarkoitus { get; set; } // Työn tarkoitus
        public string osoite { get; set; } // Hakemuksen osoite
        public string kaupunginosa { get; set; } // Hakemuksen kaupunginosa
        public string? status { get; set; } // Tieto onko hakemus voimassa parhaillaan(Käynnissä), vai tulevaisuudessa(Tuleva)
        public string hakija { get; set; } // Hakemukselle merkitty hakija, ainoastaan yritys ja yhteisöhakijoiden tiedot näytetään aineistossa
        public string? tyon_suorittaja { get; set; } // Hakemukselle merkittytyön suorittaja, ainoastaan yritys ja yhteisöhakijoiden tiedot näytetään aineistossa
        //GeometryPropertyType singlegeom;//Kohteen geometria
        public string? geometrytype { get; set; } // Geometrian tyyppi
        public string? tyo_alkaa_txt { get; set; } // Työn alkupäivä, tekstimuodossa
        public string? tyo_paattyy_txt { get; set; } //Työn loppupäivä,tekstimuodossa

        public static implicit operator List<object>(Tietyö v)
        {
            throw new NotImplementedException();
        }
    }
}