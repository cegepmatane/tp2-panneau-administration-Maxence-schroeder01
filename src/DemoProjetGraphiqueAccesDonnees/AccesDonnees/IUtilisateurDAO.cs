using System.Collections.Generic;

namespace DemoProjetGraphiqueAccesDonnees.AccesDonnees
{
    public interface IUtilisateurDAO
    {
        int Creer(Utilisateur utilisateur);
        Utilisateur Obtenir(int id);
        int MettreAJour(Utilisateur utilisateur);
        int Supprimer(int id);
        int Supprimerlogique(int id);
        bool Iscreate();
    }
}