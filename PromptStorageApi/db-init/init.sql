IF DB_ID(N'PromptStorageDb') IS NULL
BEGIN
    CREATE DATABASE [PromptStorageDb];
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.sql_logins WHERE name = N'prompt_app')
BEGIN
    CREATE LOGIN [prompt_app]
    WITH PASSWORD = '$(PROMPT_DB_PASSWORD)';
END
GO

USE [PromptStorageDb];
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N'prompt_app')
BEGIN
    CREATE USER [prompt_app] FOR LOGIN [prompt_app];
END
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.database_role_members drm
    JOIN sys.database_principals r ON drm.role_principal_id = r.principal_id
    JOIN sys.database_principals m ON drm.member_principal_id = m.principal_id
    WHERE r.name = N'db_owner'
      AND m.name = N'prompt_app'
)
BEGIN
    ALTER ROLE db_owner ADD MEMBER [prompt_app];
END
GO