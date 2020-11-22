using System;

namespace tp2_MaxenceSchroeder.accesDonnees
{
    public class Utilisateur
    {
#pragma warning disable IDE1006 // Styles d'affectation de noms
        public int noUtil { get; set; }
        public int noDEP { get; set; }
        public int noTYPEUTIL { get; set; }
        public string nomUtil { get; set; }
        public string prenomUtil { get; set; }
        public string courieUTIL { get; set; }
        public char motdepasseUTIL { get; set; }
        public string telUTIL { get; set; }
        public int nePlusAfficher { get; set; }
        public DateTime dateSuppression { get; set; }
        public int supprimePar { get; set; }
#pragma warning restore IDE1006 // Styles d'affectation de noms
    }
}