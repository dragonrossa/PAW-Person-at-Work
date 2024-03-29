/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ŠifraZaposlenika]
      ,[Ime]
      ,[Prezime]
      ,[Adresa]
      ,[PoštanskiBroj]
      ,[Grad]
      ,[Mail]
      ,[Mobitel]
      ,[Telefon]
      ,[Lokacija]
      ,[Odjel]
      ,[RadnaPozicija]
      ,[LoginZap]
      ,[ŠifraProjekta]
      ,[Ostalo]
  FROM [RadniSati].[dbo].[Zaposlenici]

  INSERT INTO Zaposlenici VALUES ('Rosa','Na','Ilica 1A','10000','Zagreb','rodjuga@gmail.com','09454654','01423875','Zagreb','Development','.NET developer',0,1002,'Zaposlenik radi radnim danom od 08:00 do 16:00 h.')
  INSERT INTO Zaposlenici VALUES ('Iva','Na','Ilica 1A','10000','Zagreb','rodjuga@gmail.com','09454654','01423875','Zagreb','Development','Software developer',0,1002,'Zaposlenik radi radnim danom od 07:00 do 15:00 h.')
  INSERT INTO Zaposlenici VALUES ('Marija','Na','Ilica 1A','10000','Zagreb','rodjuga@gmail.com','09454654','01423875','Zagreb','Development','Software developer',0,1003,'Zaposlenik radi radnim danom od 07:00 do 15:00 h.')
  INSERT INTO Zaposlenici VALUES ('Jurica','Gotovina','Ilica 1A','10000','Zagreb','rodjuga@gmail.com','09454654','01423875','Zagreb','	PM','Project manager',0,1004,'Zaposlenik radi radnim danom od 09:00 do 17:00 h. Povremeno putuje klijentu te održava određene radionice.')
  INSERT INTO Zaposlenici VALUES (@ime, @prezime, @adresa, @postanskiBroj, @grad, @mobitel, @telefon, @lokacija, @odjel, @radnaPozicija, @loginZap, @sifraProjekta, @ostalo)
  INSERT INTO Zaposlenici VALUES ('John','Fitz','Ilica 1A','10000','Zagreb','rodjuga@gmail.com','09454654','01423875','Zagreb','	PM','Project manager',0,1004,'Zaposlenik radi kao koordinator nad svim projektima')

  DELETE * FROM Zaposlenici WHERE ŠifraZaposlenika=10

  SELECT COUNT(*), SUM(Budget), MIN(Pocetak),MIN(Kraj) from Projekt

  SELECT COUNT(*) from Zaposlenici;  SELECT COUNT(*) FROM Zaposlenici WHERE Lokacija='Zagreb'

  SELECT Ime+Prezime as 'Ime i prezime' from Zaposlenici

  SELECT COUNT(*) FROM Zaposlenici WHERE Lokacija='Zagreb'

  SELECT DISTINCT(Odjel) from Zaposlenici
