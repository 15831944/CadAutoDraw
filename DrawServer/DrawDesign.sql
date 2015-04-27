CREATE TABLE [dbo].[DrawDesign]
(
	[Station_Id] INT NOT NULL PRIMARY KEY, 
    [StationName] NCHAR(10) NOT NULL, 
	[StationDistance] NCHAR(10) NOT NULL, 
    [Belong_to_Projet] INT NOT NULL,     
    CONSTRAINT [FK_DrawDesign_ToTable] FOREIGN KEY (Belong_to_Projet) REFERENCES [dbo].[DrawProjet](Projet_Id)
)
