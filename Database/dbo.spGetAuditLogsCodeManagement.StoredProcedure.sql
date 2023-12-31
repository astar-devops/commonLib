USE [Dev]
GO
/****** Object:  StoredProcedure [dbo].[spGetAuditLogsCodeManagement]    Script Date: 7/19/2023 9:02:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ====================================================================
-- Author:		Diana Chandrawati
-- Create date: 19 Jun 2023
-- Description:	SP to get Document Management AuditLog details by LogID
-- ====================================================================
CREATE PROCEDURE [dbo].[spGetAuditLogsCodeManagement]
	@LogID INT
AS
BEGIN

	SET NOCOUNT ON;

    SELECT 
	a.LogID,
	a.Code,
	a.Key1,
	b.CodeValue,
	b.CodeDescription,
	a.UserID As UpdatedBy,
	FORMAT(a.LogDateTime, 'dd/MM/yyyy HH:mm:ss') AS UpdatedOn
	FROM 
		(
			SELECT *
			FROM (SELECT l.LogID, l.UserID, l.LogDateTime, pk.FieldName AS FieldName, pk.Value AS Value
				FROM AuditLog l CROSS APPLY OPENJSON(ActionRequest, '$.PK')
					WITH (
						FieldName VARCHAR(50),
						Value VARCHAR(1000)
					) AS pk
				) AS t
				PIVOT
				(
					MAX(Value)
					FOR FieldName IN([Code],[Key1])
				) AS p
			WHERE LogID = @LogID
		) a
		LEFT JOIN
		(
			SELECT *
			FROM (SELECT l.LogID, l.UserID, l.LogDateTime, pk.FieldName AS FieldName, pk.Value AS Value
				FROM AuditLog l CROSS APPLY OPENJSON(ActionRequest, '$.Columns')
					WITH (
						FieldName VARCHAR(50),
						Value VARCHAR(1000)
					) AS pk
				) AS t
				PIVOT
				(
					MAX(Value)
					FOR FieldName IN([CodeValue],[CodeDescription])
				) AS p
			WHERE LogID = @LogID
		) b
		ON a.LogID = b.LogID

END
GO
