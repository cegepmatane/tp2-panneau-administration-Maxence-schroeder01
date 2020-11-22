namespace tp2_MaxenceSchroeder.accesDonnees
{
    public interface IUtilisateurDAO
    {
        int Creer(Utilisateur utilisateur);
        Utilisateur Obtenir(int id);
        int MettreAJour(Utilisateur utilisateur);
        int Supprimer(int id);
        bool Iscreate();
    }
}
