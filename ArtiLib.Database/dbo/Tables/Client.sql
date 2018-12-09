CREATE TABLE [dbo].[Client] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Nom]           NVARCHAR (MAX) NOT NULL,
    [Prenom]        NVARCHAR (MAX) NOT NULL,
    [DateNaissance] DATETIME       NOT NULL,
    [Tel]           NVARCHAR (MAX) NOT NULL,
    [Mail]          NVARCHAR (MAX) NOT NULL,
    [Adresse]       NVARCHAR (MAX) NOT NULL,
    [CodePostal]    NVARCHAR (MAX) NOT NULL,
    [Identifiant]   NVARCHAR (MAX) NOT NULL,
    [Password]      NVARCHAR (MAX) NOT NULL,
    [Ville]         NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

