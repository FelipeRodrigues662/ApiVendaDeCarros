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

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(120) NOT NULL,
    [Telefone] INT NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Modelo] (
    [Id] int NOT NULL IDENTITY,
    [Nome] NVARCHAR(120) NOT NULL,
    [Ano] INT NOT NULL,
    [Cor] NVARCHAR(40) NOT NULL,
    CONSTRAINT [PK_Modelo] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EstadoDeVenda] (
    [Id] int NOT NULL IDENTITY,
    [Vendido] BIT NOT NULL DEFAULT CAST(0 AS BIT),
    [ClienteId] INT NOT NULL,
    CONSTRAINT [PK_EstadoDeVenda] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EstadoDeVenda_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Carros] (
    [Id] int NOT NULL IDENTITY,
    [ModeloId] INT NOT NULL,
    [Valor] MONEY NOT NULL,
    [EstadoDeVendaId] INT NOT NULL,
    CONSTRAINT [PK_Carros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carros_EstadoDeVenda_EstadoDeVendaId] FOREIGN KEY ([EstadoDeVendaId]) REFERENCES [EstadoDeVenda] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Carros_Modelo_ModeloId] FOREIGN KEY ([ModeloId]) REFERENCES [Modelo] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Carros_EstadoDeVendaId] ON [Carros] ([EstadoDeVendaId]);
GO

CREATE INDEX [IX_Carros_ModeloId] ON [Carros] ([ModeloId]);
GO

CREATE INDEX [IX_EstadoDeVenda_ClienteId] ON [EstadoDeVenda] ([ClienteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221212135608_Init', N'7.0.0');
GO

COMMIT;
GO

