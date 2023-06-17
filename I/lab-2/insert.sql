USE LabBD

INSERT INTO Client
           (cod_c
           ,nume
           ,varsta)
     VALUES
           (1
           ,'Alex'
           ,19)

INSERT INTO Client
           (cod_c
           ,nume
           ,varsta)
     VALUES
           (2
           ,'Vasi'
           ,21)

INSERT INTO Client
           (cod_c
           ,nume
           ,varsta)
     VALUES
           (3
           ,'Iuga'
           ,20)


INSERT INTO Telefon
           (cod_t
           ,brand
           ,model
		   ,pret
		   ,cod_c)
     VALUES
           (1
           ,'Oneplus'
		   ,'7 Pro 5G'
		   ,3499
           ,1)

INSERT INTO Telefon
           (cod_t
           ,brand
           ,model
		   ,pret
		   ,cod_c)
     VALUES
           (2
           ,'Iphone'
		   ,'13'
		   ,5599
           ,2)

INSERT INTO Telefon
           (cod_t
           ,brand
           ,model
		   ,pret
		   ,cod_c)
     VALUES
           (3
           ,'Samsung'
		   ,'Galaxy s10'
		   ,2899
           ,3)


INSERT INTO Eveniment
           (cod_e
           ,nume
           ,descriere)
     VALUES
           (1
           ,'Big discounts'
           ,'Reduceri la telefoane Samsung')

INSERT INTO Eveniment
           (cod_e
           ,nume
           ,descriere)
     VALUES
           (2
           ,'WWDC'
           ,'Prezentare produse Apple')


INSERT INTO Showroom
           (cod_sh
           ,locatie
           ,cod_e)
     VALUES
           (1
           ,'Bucuresti'
           ,2)

INSERT INTO Showroom
           (cod_sh
           ,locatie
           ,cod_e)
     VALUES
           (2
           ,'Cluj-Napoca'
           ,2)

INSERT INTO Showroom
           (cod_sh
           ,locatie
           ,cod_e)
     VALUES
           (3
           ,'Iasi'
           ,1)


INSERT INTO Sponsor
           (cod_sp
           ,nume
           ,investitie)
     VALUES
           (1
           ,'Cristi'
           ,10000)

INSERT INTO Sponsor
           (cod_sp
           ,nume
           ,investitie)
     VALUES
           (2
           ,'Vlad'
           ,20000)


INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (1
           ,1)

INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (2
           ,1)

INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (3
           ,1)

INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (2
           ,2)

INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (3
           ,2)

INSERT INTO Inventar
           (cod_t
           ,cod_sh)
     VALUES
           (3
           ,3)


INSERT INTO Conventie
           (cod_sh
           ,cod_sp)
     VALUES
           (1
           ,1)

INSERT INTO Conventie
           (cod_sh
           ,cod_sp)
     VALUES
           (1
           ,2)

INSERT INTO Conventie
           (cod_sh
           ,cod_sp)
     VALUES
           (2
           ,2)

INSERT INTO Conventie
           (cod_sh
           ,cod_sp)
     VALUES
           (3
           ,1)