CREATE VIEW `Administrator_rozklad_jazdy_administratora_view` AS
SELECT p.nazwa_przystanek, rja.id_administrator, rja.nr_linii, rja.data_odjazdu
FROM Rozklad_jazdy_administratora as rja
INNER JOIN Przystanek as p ON rja.id_przystanek=p.id_przystanek;

CREATE VIEW `Brygadzista_rozklad_jazdy_administratora_view` AS
SELECT p.nazwa_przystanek, rja.nr_linii, rja.data_odjazdu
FROM Rozklad_jazdy_administratora as rja
INNER JOIN Przystanek AS p ON rja.id_przystanek=p.id_przystanek;

CREATE VIEW `Kierowca_rozklad_jazdy_administratora_view` AS
SELECT p.nazwa_przystanek, rja.nr_linii, rja.data_odjazdu
FROM Rozklad_jazdy_administratora as rja
INNER JOIN Przystanek as p ON rja.id_przystanek=p.id_przystanek;

CREATE VIEW `Kierowca_rozklad_jazdy_brygadzisty_view` AS
SELECT rjb.id_kierowca, FK.nr_linii, PS.nazwa_przystanek as 'przystanek startowy', PK.nazwa_przystanek as 'przystanek koncowy', rjb.godzina_startu_kierowcy, p.nr_rejestracyjny
FROM Rozklad_jazdy_brygadzisty AS rjb
INNER JOIN Pojazd as p ON rjb.id_pojazd=p.id_pojazd
INNER JOIN Fragment_kursu as FK ON rjb.id_fragment_kursu=FK.id_kurs
    INNER JOIN Przystanek as PS ON FK.przystanek_startowy=PS.id_przystanek
    INNER JOIN Przystanek as PK ON FK.przystanek_koncowy=PK.id_przystanek;

CREATE VIEW `Brygadzista_rozklad_jazdy_brygadzisty_view` AS
SELECT rjb.id_rozklad_jazdy_brygadzisty, rjb.id_kierowca, FK.nr_linii, PS.nazwa_przystanek as 'przystanek startowy', PK.nazwa_przystanek as 'przystanek koncowy', rjb.godzina_startu_kierowcy, p.nr_rejestracyjny, rjb.id_brygada, rjb.id_rozklad_admin
FROM Rozklad_jazdy_brygadzisty AS rjb
INNER JOIN Pojazd as p ON rjb.id_pojazd=p.id_pojazd
INNER JOIN Fragment_kursu as FK ON rjb.id_fragment_kursu=FK.id_kurs
    INNER JOIN Przystanek as PS ON FK.przystanek_startowy=PS.id_przystanek
    INNER JOIN Przystanek as PK ON FK.przystanek_koncowy=PK.id_przystanek;

CREATE VIEW `Kierowca_brygada_view` AS
SELECT k.id_brygada, k.id_pracownik, p.imie, p.nazwisko
FROM Kierowca as k
INNER JOIN Pracownik as p ON k.id_pracownik=p.id_pracownik;

CREATE VIEW `Administrator_pracownik_view` AS
SELECT p.id_pracownik, p.imie, p.nazwisko, p.data_urodzenia, p.data_zatrudnienia, p.pesel, m.nazwa_miejscowosci, u.nazwa_ulicy, a.nr_domu, a.nr_lokalu
FROM Pracownik as p
INNER JOIN Adres as a ON p.id_adres=a.id_adres
INNER JOIN Ulica as u ON a.id_ulica=u.id_ulica
INNER JOIN Miejscowosc as m ON u.id_miejscowosc=m.id_miejscowosc;

CREATE VIEW `Brygadzista_pracownik_view` AS
SELECT k.id_brygada, k.id_pracownik, p.imie, p.nazwisko
FROM Kierowca as k
INNER JOIN Pracownik as p ON k.id_pracownik=p.id_pracownik;

CREATE VIEW `Brygadzista_brygada_view` AS
SELECT k.id_brygada, k.id_pracownik, p.imie, p.nazwisko, brp.id_pracownik as "id brygadzisty", brp.imie as "imie brygadzisty", brp.nazwisko as "nazwisko brygadzisty"
FROM Kierowca as k
INNER JOIN Pracownik as p ON k.id_pracownik=p.id_pracownik
INNER JOIN Brygada as b ON k.id_brygada=b.id_brygada
INNER JOIN Brygadzista as br ON b.id_brygadzista=br.id_brygadzista
INNER JOIN Pracownik as brp ON br.id_pracownik=brp.id_pracownik;

CREATE VIEW `Administrator_adresy_pracownikow_view` AS
SELECT adr.id_adres, adr.nr_domu, adr.nr_lokalu, ul.nazwa_ulicy, miejsc.nazwa_miejscowosci
FROM Adres AS adr
INNER JOIN ulica as ul ON adr.id_ulica=ul.id_ulica
	INNER JOIN miejscowosc as miejsc ON ul.id_miejscowosc=miejsc.id_miejscowosc;
