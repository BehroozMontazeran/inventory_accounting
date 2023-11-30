CREATE TABLE [dbo].[ProjectForm] (
    [Id]                         INT            IDENTITY (1, 1) NOT NULL,
    [StudentId]                  DECIMAL (18)   NOT NULL,
    [FullName]                   NVARCHAR (250) NOT NULL,
    [Mobile]                     NCHAR (11)     NOT NULL,
    [EmailAddress]               NVARCHAR (50)  NOT NULL,
    [PassedUnits]                INT            NOT NULL,
    [Avarage]                    DECIMAL (4, 2) NOT NULL,
    [Grade]                      NVARCHAR (50)  NOT NULL,
    [ProjectName]                NVARCHAR (MAX) NOT NULL,
    [ProjectDescription]         NVARCHAR (MAX) NOT NULL,
    [ProfessrorConfirmation]     BIT            NULL,
    [ProfessrorConfirmationDate] NVARCHAR (100) NULL,
    [ManagerConfirmation]        NVARCHAR (100) NULL,
    [ManagerConfirmationDate]    NVARCHAR (100) NULL,
    [ManagerComment]             NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);