CREATE LOGIN alexis WITH PASSWORD ='Pewpew123!';

CREATE USER alexis FOR LOGIN alexis;
GO

USE SGSBD;
GRANT SELECT ON dbo.Utilisateur TO alexis;