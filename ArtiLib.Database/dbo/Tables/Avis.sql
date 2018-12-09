CREATE TABLE [dbo].[Avis] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [NombreEtoile]        INT            NOT NULL,
    [Commentaire]         NVARCHAR (MAX) NULL,
    [IdPrestationArtisan] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Avis_PrestationArtisan] FOREIGN KEY ([IdPrestationArtisan]) REFERENCES [dbo].[PrestationArtisan] ([Id])
);

