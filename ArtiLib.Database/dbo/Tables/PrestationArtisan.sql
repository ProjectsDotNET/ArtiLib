CREATE TABLE [dbo].[PrestationArtisan] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [IdPrestation]      INT            NOT NULL,
    [IdArtisan]         INT            NOT NULL,
    [Tarif]             FLOAT (53)     NOT NULL,
    [Reduction]         FLOAT (53)     NULL,
    [CourteDescription] NVARCHAR (MAX) NULL,
    [LongueDescription] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PrestationArtisan_Artisan] FOREIGN KEY ([IdArtisan]) REFERENCES [dbo].[Artisan] ([Id]),
    CONSTRAINT [FK_PrestationArtisan_Prestation] FOREIGN KEY ([IdPrestation]) REFERENCES [dbo].[Prestation] ([Id])
);

