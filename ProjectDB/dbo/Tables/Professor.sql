CREATE TABLE [dbo].[Professor] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ProfessortId]  DECIMAL (18)   NOT NULL,
    [FullName]      NVARCHAR (250) NOT NULL,
    [ProfessorType] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
