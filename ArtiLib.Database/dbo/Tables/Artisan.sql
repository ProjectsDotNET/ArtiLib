CREATE TABLE [dbo].[Artisan] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nom]           NVARCHAR (MAX) NOT NULL,
    [Prenom]        NVARCHAR (MAX) NOT NULL,
    [DateNaissance] DATETIME       NOT NULL,
    [Tel]           NVARCHAR (13)  NOT NULL,
    [Mail]          NVARCHAR (MAX) NOT NULL,
    [Adresse]       NVARCHAR (MAX) NOT NULL,
    [CodePostal]    NVARCHAR (7)   NOT NULL,
    [Ville]         NVARCHAR (MAX) NOT NULL,
    [Identifiant]   NVARCHAR (MAX) NOT NULL,
    [Password]      NVARCHAR (MAX) NOT NULL,
    [RaisonSociale] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

