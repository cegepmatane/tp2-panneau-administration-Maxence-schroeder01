using Dapper;
using System.Data;

namespace tp2_MaxenceSchroeder.accesDonnees
{
    public class UtilisateurDAO : IUtilisateurDAO
    {
        private readonly IDbConnection _connexion;
        private bool iscreate;

        public UtilisateurDAO(IDbConnection connexion)
        {
            _connexion = connexion;
        }
        public Utilisateur Obtenir(int noUtil)
        {
            string requete = @"SELECT * FROM HR.Utilisateur WHERE noUtil = @noUtil";
            return _connexion.QuerySingleOrDefault<Utilisateur>(requete, new { utilisateur = noUtil });
        }

        public int Creer(Utilisateur utilisateur)
        {
            string requete = @"INSERT INTO HR.Utilisateur (noUtil        
                                                        ,noDep       
                                                        ,noTYPEUTIL          
                                                        ,nomUtil 
                                                        ,prenomUtil       
                                                        ,courieUTIL        
                                                        ,motdepasseUTIL         
                                                        ,telUTIL           
                                                        ,nePlusAfficher         
                                                        ,dateSuppression              
                                                        ,supprimePar)
                                                OUTPUT INSERTED.[empid]
                                                VALUES (@noUtil          
                                                       ,@noDep        
                                                       ,@noTYPEUTIL            
                                                       ,@nomUtil 
                                                       ,@prenomUtil       
                                                       ,@courieUTIL        
                                                       ,@motdepasseUTIL        
                                                       ,@telUTIL           
                                                       ,@nePlusAfficher          
                                                       ,@dateSuppression               
                                                       ,@supprimePar);";
            iscreate = true;
            return _connexion.QuerySingle<int>(requete, utilisateur);
        }

        public int MettreAJour(Utilisateur utilisateur)
        {
            string requete = @"UPDATE HR.Utilisateur
                                  SET noUtil = @noUtil
                                     ,noDep = @noDep
                                     ,noTYPEUTIL = @noTYPEUTIL
                                     ,nomUtil = @nomUtil
                                     ,prenomUtil = @prenomUtil
                                     ,courieUTIL  = @courieUTIL 
                                     ,motdepasseUTIL = @motdepasseUTIL
                                     ,telUTIL  = @telUTIL 
                                     ,nePlusAfficher = @nePlusAfficher
                                     ,dateSuppression = @dateSuppression
                                     ,supprimePar = @supprimePar 
                                WHERE noUtil = @noUtil;";
            iscreate = true;
            return _connexion.Execute(requete, utilisateur);
        }
        public int Supprimer(int noUtil)
        {
            string requete = "DELETE FROM HR.Utilisateur WHERE noUtil = @noUtil;";
            iscreate = true;
            return _connexion.Execute(requete, new { empid = noUtil });
        }
        public bool Iscreate()
        {
            return iscreate;
        }
    }
}
