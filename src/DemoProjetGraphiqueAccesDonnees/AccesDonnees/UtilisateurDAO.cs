using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DemoProjetGraphiqueAccesDonnees.AccesDonnees
{
    public class UtilisateurDAO : IUtilisateurDAO
    {
        private readonly IDbConnection _connexion;
        private bool iscreate;

        public UtilisateurDAO(IDbConnection connexion)
        {
            _connexion = connexion;
        }
        public Utilisateur Obtenir(int id)
        {
            string requete = @"SELECT * FROM dbo.Utilisateur WHERE noUTIL = @noUtil;";
            return _connexion.QuerySingleOrDefault<Utilisateur>(requete, new { noUtil = id });
        }

        public int Creer(Utilisateur utilisateur)
        {
            string requete = @" SET IDENTITY_INSERT dbo.Utilisateur ON
                                INSERT INTO dbo.Utilisateur (noUTIL        
                                                        ,noDEP       
                                                        ,noTYPEUTIL          
                                                        ,nomUTIL 
                                                        ,prenomUTIL       
                                                        ,courrielUTIL        
                                                        ,motpasseUTIL         
                                                        ,telUTIL           
                                                        ,nePlusAfficher         
                                                        ,dateSuppression              
                                                        ,supprimePar)
                                                OUTPUT INSERTED.[noUTIL]
                                                VALUES (@noUTIL          
                                                       ,@noDEP        
                                                       ,@noTYPEUTIL            
                                                       ,@nomUTIL 
                                                       ,@prenomUTIL      
                                                       ,@courrielUTIL        
                                                       ,@motpasseUTIL        
                                                       ,@telUTIL           
                                                       ,@nePlusAfficher          
                                                       ,@dateSuppression               
                                                       ,@supprimePar);";
            iscreate = true;
            return _connexion.QuerySingle<int>(requete, utilisateur);
        }

        public int MettreAJour(Utilisateur utilisateur)
        {
            string requete = @"UPDATE dbo.Utilisateur
                                  SET noUTIL = @noUTIL
                                     ,noDEP = @noDEP
                                     ,noTYPEUTIL = @noTYPEUTIL
                                     ,nomUTIL = @nomUTIL
                                     ,prenomUTIL = @prenomUTIL
                                     ,courrielUTIL  = @courrielUTIL 
                                     ,motpasseUTIL = @motpasseUTIL
                                     ,telUTIL  = @telUTIL 
                                     ,nePlusAfficher = @nePlusAfficher
                                     ,dateSuppression = @dateSuppression
                                     ,supprimePar = @supprimePar 
                                WHERE noUTIL = @noUTIL;";
            iscreate = true;
            return _connexion.Execute(requete, utilisateur);
        }
        public int Supprimer(int id)
        {
            string requete = "DELETE FROM dbo.Utilisateur WHERE noUTIL = @noUtil;";
            iscreate = true;
            return _connexion.Execute(requete, new { noUtil = id });
        }
        public int Supprimerlogique(int id)
        {
            string requete = "EXEC dbo.supprimerUtilisateur @noUTIL = noUtil";
            return _connexion.Execute(requete, new { noUtil = id });
        }
        public bool Iscreate()
        {
            return iscreate;
        }
    }
}
