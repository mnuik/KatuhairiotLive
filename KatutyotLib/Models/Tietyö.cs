using System.ComponentModel;

namespace KatutyotLib.Models
{
    public class Tietyö
    {
        public long id; // Kohteen yksilöivä tunniste
        public string? hakemus;// Hakemuksen tyyppi
        public string? hakemustunnus;// Hakemuksen tunnus Allu-järjestelmässä
        public DateTime tyo_alkaa;// Työn alkupäivä, päivämäärämuodossa
        public DateTime tyo_paattyy; // Työn loppupäivä, päivämäärämuodossa
        public string tyon_tarkoitus;// Työn tarkoitus
        public string osoite;// Hakemuksen osoite
        public string kaupunginosa;// Hakemuksen kaupunginosa
        public string status;// Tieto onko hakemus voimassa parhaillaan(Käynnissä), vai tulevaisuudessa(Tuleva)
        public string hakija;// Hakemukselle merkitty hakija, ainoastaan yritys ja yhteisöhakijoiden tiedot näytetään aineistossa
        public string? tyon_suorittaja;// Hakemukselle merkittytyön suorittaja, ainoastaan yritys ja yhteisöhakijoiden tiedot näytetään aineistossa
        //GeometryPropertyType singlegeom;//Kohteen geometria
        public string? geometrytype;// Geometrian tyyppi
        public string? tyo_alkaa_txt;// Työn alkupäivä, tekstimuodossa
        public string? tyo_paattyy_txt;//Työn loppupäivä,tekstimuodossa
    }
}