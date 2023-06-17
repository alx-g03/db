USE LabBD

--toate persoanele cu varsta intre 21 si 29 de ani
SELECT nume FROM Client WHERE varsta > 20 AND varsta < 30
UNION
SELECT nume FROM Sponsor;

--toate showroom-urile si toate telefoanele pe care le au
SELECT Showroom.locatie, Telefon.brand, Telefon.model 
FROM ((Showroom
INNER JOIN Inventar
ON Showroom.cod_sh = Inventar.cod_sh)
INNER JOIN Telefon
ON Inventar.cod_t = Telefon.cod_t);

--fiecare sponsor si toate showroom-urile in care a investit
SELECT Sponsor.nume, Sponsor.investitie , Showroom.locatie
FROM ((Sponsor
LEFT JOIN Conventie
ON Sponsor.cod_sp = Conventie.cod_sp)
LEFT JOIN Showroom
ON Conventie.cod_sh = Showroom.cod_sh);

--frecventa fiecarui eveniment
SELECT cod_e, COUNT(cod_sh) AS [frecventa eveniment] FROM Showroom
GROUP BY cod_e;

--detaliile evenimentelor care se intampla in mai multe showroom-uri in acelasi timp
SELECT Eveniment.nume, Eveniment.descriere, COUNT(Showroom.cod_sh) AS [frecventa eveniment] FROM Showroom
RIGHT JOIN Eveniment
ON Showroom.cod_e = Eveniment.cod_e
GROUP BY Eveniment.nume, Eveniment.descriere
HAVING COUNT(Showroom.cod_sh) >= 2;

--pretul telefoanelor fiecarui client
SELECT cod_c, SUM(pret) AS [valoare telefon] FROM Telefon
GROUP BY cod_c;

--pretul telefoanelor fiecarui client
SELECT Client.nume, SUM(Telefon.pret) AS [valoare telefon] FROM Telefon
RIGHT JOIN Client
ON Telefon.cod_c = Client.cod_c
GROUP BY Client.nume;

--cea mai mare investitie a fiecarui sponsor
SELECT DISTINCT Sponsor.nume, MAX(Sponsor.investitie) AS [investitie maxima]
FROM ((Sponsor
LEFT JOIN Conventie
ON Sponsor.cod_sp = Conventie.cod_sp)
LEFT JOIN Showroom
ON Conventie.cod_sh = Showroom.cod_sh)
GROUP BY Sponsor.nume;

--toate telefoanele care au fost cumparate
SELECT * FROM Telefon
WHERE cod_c IN (SELECT cod_c FROM Client);

--toti clientii care au un telefon mai scump de 3000 de lei
SELECT * FROM Client
WHERE EXISTS
(SELECT cod_t FROM Telefon WHERE Client.cod_c = Telefon.cod_c AND Telefon.pret > 3000);