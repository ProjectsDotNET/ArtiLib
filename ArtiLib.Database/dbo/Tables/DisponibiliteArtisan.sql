CREATE TABLE [dbo].[DisponibiliteArtisan] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [IdArtisan] INT      NOT NULL,
    [DateHeure] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DisponibiliteArtisan_Artisan] FOREIGN KEY ([IdArtisan]) REFERENCES [dbo].[Artisan] ([Id])
);

