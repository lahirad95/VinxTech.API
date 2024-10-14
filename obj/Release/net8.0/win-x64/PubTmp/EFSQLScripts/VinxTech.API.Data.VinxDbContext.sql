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
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
)
BEGIN
    CREATE TABLE [Branches] (
        [Id] int NOT NULL IDENTITY(1000, 1),
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
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
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
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
)
BEGIN
    CREATE TABLE [Services] (
        [Id] int NOT NULL IDENTITY(3001, 1),
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
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
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
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [CreatedAt], [Description], [Name], [UpdatedAt])
    VALUES (1, ''2024-10-08T11:17:08.5007544Z'', N''Has full access to all system features and can manage all users, settings, and roles.'', N''Super Admin'', ''2024-10-08T11:17:08.5007546Z''),
    (2, ''2024-10-08T11:17:08.5007549Z'', N''Can manage users and settings, but has limited access to sensitive system configurations.'', N''Admin'', ''2024-10-08T11:17:08.5007550Z''),
    (3, ''2024-10-08T11:17:08.5007552Z'', N''Has access to basic features and functionalities necessary for daily operations.'', N''Employee'', ''2024-10-08T11:17:08.5007552Z'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedAt', N'Description', N'Name', N'UpdatedAt') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Users_Username] ON [Users] ([Username]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008111708_UpdateServicesAgain'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008111708_UpdateServicesAgain', N'8.0.8');
END;
GO

COMMIT;
GO

