/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Šifra]
      ,[Naziv]
      ,[Opis]
      ,[PM]
      ,[Task]
      ,[Rezultat]
      ,[Koordinator]
      ,[Klijent]
      ,[Pocetak]
      ,[Kraj]
      ,[Datum]
      ,[Budget]
      ,[Drzava]
      ,[ImeZaposlenika]
      ,[PrezimeZaposlenika]
  FROM [RadniSati].[dbo].[Projekt]

  UPDATE Projekt SET VALUES() WHERE Šifra=

  SELECT COUNT(*) from Projekt
  SELECT SUM(Budget) from Projekt
  SELECT MIN(Pocetak) from Projekt
  SELECT MIN(Kraj) from Projekt

  SELECT COUNT(*), SUM(Budget), MIN(Pocetak),MIN(Kraj) from Projekt
