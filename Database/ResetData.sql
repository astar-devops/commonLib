USE [Dev]
GO

-- Clean up SystemCode table
DELETE FROM [Dev].[dbo].[SystemCode]

-- Reseed AuditLog Identity column
DELETE FROM [Dev].[dbo].[AuditLog] WHERE LOGID > 10

DBCC CHECKIDENT('AuditLog', RESEED, 10)


-- Reset InterfaceLog Identity column

DBCC CHECKIDENT('InterfaceLog')

DELETE FROM [Dev].[dbo].[InterfaceLog]

DBCC CHECKIDENT('InterfaceLog', RESEED, 0)


-- Reset ExceptionLog Identity column

DBCC CHECKIDENT('ExceptionLog')

DELETE FROM [Dev].[dbo].[ExceptionLog]

DBCC CHECKIDENT('ExceptionLog', RESEED, 0)