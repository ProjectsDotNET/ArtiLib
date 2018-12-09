CREATE TABLE [dbo].[RendezVous] (
    [Id]                     INT IDENTITY (1, 1) NOT NULL,
    [IdClient]               INT NOT NULL,
    [IdDisponibiliteArtisan] INT NOT NULL,
    [IdStatutRendezVous]     INT NOT NULL,
    [IdRendezVousDeplace]    INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RendezVous_Client] FOREIGN KEY ([IdClient]) REFERENCES [dbo].[Client] ([Id]),
    CONSTRAINT [FK_RendezVous_DisponibiliteArtisan] FOREIGN KEY ([IdDisponibiliteArtisan]) REFERENCES [dbo].[DisponibiliteArtisan] ([Id]),
    CONSTRAINT [FK_RendezVous_RendezVous] FOREIGN KEY ([IdRendezVousDeplace]) REFERENCES [dbo].[RendezVous] ([Id]),
    CONSTRAINT [FK_RendezVous_StatutRendezVous] FOREIGN KEY ([IdStatutRendezVous]) REFERENCES [dbo].[StatutRendezVous] ([Id])
);

