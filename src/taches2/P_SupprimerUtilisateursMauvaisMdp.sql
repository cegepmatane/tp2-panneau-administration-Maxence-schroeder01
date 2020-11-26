CREATE PROCEDURE dbo.supprimerUtilisateur AS 
BEGIN 
    UPDATE dbo.Utilisateur 
        SET dateSuppression = GETDATE() 
        ,supprimePar = '1933353' 
    WHERE noUTIL = noUtil ;
END;
