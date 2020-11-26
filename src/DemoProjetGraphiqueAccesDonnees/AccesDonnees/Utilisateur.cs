using System;

namespace DemoProjetGraphiqueAccesDonnees.AccesDonnees
{
    public class Utilisateur
    {
#pragma warning disable IDE1006 // Styles d'affectation de noms
        public int noUTIL { get; set; }
        public int noDEP { get; set; }
        public int noTYPEUTIL { get; set; }
        public string nomUTIL { get; set; }
        public string prenomUTIL { get; set; }
        public string courrielUTIL { get; set; }
        public string motpasseUTIL { get; set; }
        public string telUTIL { get; set; }
        public int nePlusAfficher { get; set; }
        public DateTime dateSuppression { get; set; }
        public int supprimePar { get; set; }
#pragma warning restore IDE1006 // Styles d'affectation de noms
    }
}