ALTER PROCEDURE dbo.supprimerUtilisateur(@MotdepasseMin int = 40 ) AS
BEGIN
    UPDATE dbo.Utilisateur 
        SET dateSuppression = GETDATE() 
        ,supprimePar = '1933353' 
    WHERE motpasseUTIL < @MotdepasseMin ;
END;

DECLARE @Resultat int 
EXEC @Resultat = dbo.supprimerUtilisateur 'Rohatash'
SELECT @Resultat