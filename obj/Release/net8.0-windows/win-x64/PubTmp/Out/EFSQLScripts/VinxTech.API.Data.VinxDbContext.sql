IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [Branches] (
        [Id] int NOT NULL IDENTITY,
        [NameEn] nvarchar(max) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        [DescriptionEn] nvarchar(max) NOT NULL,
        [DescriptionAr] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Branches] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [Employees] (
        [Id] uniqueidentifier NOT NULL,
        [firstNameEn] nvarchar(max) NOT NULL,
        [lastNameEn] nvarchar(max) NOT NULL,
        [firstNameAr] nvarchar(max) NOT NULL,
        [lastNameAr] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [MobileNumber] nvarchar(max) NOT NULL,
        [DOB] datetime2 NOT NULL,
        [IdNumber] int NOT NULL,
        [HireDate] datetime2 NULL,
        [IdExpiryDate] datetime2 NOT NULL,
        [IsActive] bit NOT NULL,
        [Branch] int NOT NULL,
        [CretedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [EmployeeServices] (
        [Id] uniqueidentifier NOT NULL,
        [EmployeeId] int NOT NULL,
        [ServiceID] int NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [UpdatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_EmployeeServices] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [Services] (
        [Id] int NOT NULL IDENTITY,
        [ServiceNameEn] nvarchar(max) NOT NULL,
        [ServiceNameAr] nvarchar(max) NOT NULL,
        [ServiceDescriptionEn] nvarchar(max) NOT NULL,
        [ServiceDescriptionAr] nvarchar(max) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [Username] nvarchar(200) NOT NULL,
        [PasswordHash] nvarchar(256) NOT NULL,
        [firstNameEn] nvarchar(100) NOT NULL,
        [lastNameEn] nvarchar(100) NOT NULL,
        [firstNameAr] nvarchar(100) NOT NULL,
        [lastNameAr] nvarchar(100) NOT NULL,
        [Email] nvarchar(256) NOT NULL,
        [MobileNumber] nvarchar(15) NOT NULL,
        [Role] int NOT NULL,
        [HireDate] datetime2 NULL,
        [IsActive] bit NOT NULL,
        [LastLogin] datetime2 NULL,
        [CretedBy] nvarchar(200) NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [CreatedAt], [Description], [Name], [UpdatedAt])
    VALUES (1, ''2024-10-09T18:54:42.4684073Z'', N''Has full access to all system features and can manage all users, settings, and roles.'', N''Super Admin'', ''2024-10-09T18:54:42.4684075Z''),
    (2, ''2024-10-09T18:54:42.4684077Z'', N''Can manage users and settings, but has limited access to sensitive system configurations.'', N''Admin'', ''2024-10-09T18:54:42.4684078Z''),
    (3, ''2024-10-09T18:54:42.4684079Z'', N''Has access to basic features and functionalities necessary for daily operations.'', N''Employee'', ''2024-10-09T18:54:42.4684080Z'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE UNIQUE INDEX [IX_EmployeeServices_EmployeeId] ON [EmployeeServices] ([EmployeeId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE UNIQUE INDEX [IX_EmployeeServices_ServiceID] ON [EmployeeServices] ([ServiceID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Username] ON [Users] ([Username]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009185442_AddServicesTable3'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009185442_AddServicesTable3', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    DROP INDEX [IX_EmployeeServices_EmployeeId] ON [EmployeeServices];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    DROP INDEX [IX_EmployeeServices_ServiceID] ON [EmployeeServices];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T19:01:54.9311969Z'', [UpdatedAt] = ''2024-10-09T19:01:54.9311970Z''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T19:01:54.9311972Z'', [UpdatedAt] = ''2024-10-09T19:01:54.9311972Z''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T19:01:54.9311974Z'', [UpdatedAt] = ''2024-10-09T19:01:54.9311974Z''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    CREATE UNIQUE INDEX [IX_EmployeeServices_EmployeeId_ServiceID] ON [EmployeeServices] ([EmployeeId], [ServiceID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009190155_AddServicesTable4'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009190155_AddServicesTable4', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202052_4th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:20:52.2941080Z'', [UpdatedAt] = ''2024-10-09T20:20:52.2941084Z''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202052_4th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:20:52.2941087Z'', [UpdatedAt] = ''2024-10-09T20:20:52.2941087Z''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202052_4th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:20:52.2941089Z'', [UpdatedAt] = ''2024-10-09T20:20:52.2941090Z''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202052_4th'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009202052_4th', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    DROP INDEX [IX_EmployeeServices_EmployeeId_ServiceID] ON [EmployeeServices];
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[EmployeeServices]') AND [c].[name] = N'EmployeeId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [EmployeeServices] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [EmployeeServices] ALTER COLUMN [EmployeeId] bigint NOT NULL;
    CREATE UNIQUE INDEX [IX_EmployeeServices_EmployeeId_ServiceID] ON [EmployeeServices] ([EmployeeId], [ServiceID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Employees]') AND [c].[name] = N'IdNumber');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Employees] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Employees] ALTER COLUMN [IdNumber] bigint NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:24:55.6216399Z'', [UpdatedAt] = ''2024-10-09T20:24:55.6216401Z''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:24:55.6216405Z'', [UpdatedAt] = ''2024-10-09T20:24:55.6216405Z''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-09T20:24:55.6216407Z'', [UpdatedAt] = ''2024-10-09T20:24:55.6216408Z''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241009202456_5th'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241009202456_5th', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    ALTER TABLE [Users] ADD [Breanch] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    ALTER TABLE [Users] ADD [DOB] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    ALTER TABLE [Users] ADD [IdExpiryDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    ALTER TABLE [Users] ADD [IdNumber] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-14T03:30:42.1904409Z'', [UpdatedAt] = ''2024-10-14T03:30:42.1904412Z''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-14T03:30:42.1904415Z'', [UpdatedAt] = ''2024-10-14T03:30:42.1904416Z''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    EXEC(N'UPDATE [Roles] SET [CreatedAt] = ''2024-10-14T03:30:42.1904418Z'', [UpdatedAt] = ''2024-10-14T03:30:42.1904418Z''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [CreatedAt], [Description], [Name], [UpdatedAt])
    VALUES (4, ''2024-10-14T03:30:42.1904420Z'', N''Responsible for handling transactions and managing customer payments.'', N''Cashier'', ''2024-10-14T03:30:42.1904420Z'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014033042_6th'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241014033042_6th', N'8.0.8');
END;
GO

COMMIT;
GO

