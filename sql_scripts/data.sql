INSERT INTO `mpk_bd2`.`miejscowosc` (`id_miejscowosc`, `nazwa_miejscowosci`) VALUES ('1', 'Wrocław');

INSERT INTO `mpk_bd2`.`ulica` (`id_ulica`, `nazwa_ulicy`, `id_miejscowosc`) VALUES ('1', 'Libelta', '1'),
('2', 'Monte Cassino', '1'),
('3', 'Okrzei', '1'),
('4', 'Partyzantów', '1'),
('5', 'Tramwajowa', '1'),
('6', 'Kliniki', '1'),
('7', 'Plac Grunwaldzki', '1'),
('8', 'Krasińskiego', '1'),
('9', 'Dwrocowa', '1'),
('10', 'Dyrekcyjna', '1'),
('11', 'Borowska', '1');

INSERT INTO `mpk_bd2`.`adres` (`id_adres`, `nr_domu`, `nr_lokalu`, `id_ulica`) VALUES ('1', '123', '4', '1'),
('2', '16', '2', '2'),
('3', '66', '3', '3'),
('4', '27', '4', '4'),
('5', '33', '1', '1'),
('6', '117', '2', '2'),
('7', '32', '3', '3'),
('8', '3', '4', '4'),
('9', '13', NULL, '5'),
('10', '36', NULL, '6'),
('11', '62', NULL, '7'),
('12', '29', NULL, '8'),
('13', '99', NULL, '9'),
('14', '3', NULL, '10'),
('15', '42', NULL, '11');

INSERT INTO `mpk_bd2`.`pracownik` (`id_pracownik`, `imie`, `nazwisko`, `data_urodzenia`, `data_zatrudnienia`, `pesel`, `id_adres`) VALUES 
('1', 'Grzegorz', 'Brzęczyszczykiewicz', '1966-02-02', '1990-01-03', '96012116282', '1'),
('2', 'Maria', 'Seń', '1987-05-12', '2010-02-04', '03291688689', '2'),
('3', 'Bartosz', 'Grün', '1992-09-08', '2020-07-09', '83021744894', '3'),
('4', 'Kamil', 'Szos', '1984-02-06', '2017-06-04', '85121441811', '4'),
('5', 'Andrzej', 'Kruk', '1996-01-12', '2021-09-02', '89011984457', '5'),
('6', 'Alicja', 'Dąb', '1989-05-05', '2016-02-07', '86081358746', '6'),
('7', 'Damian', 'Czas', '1992-04-04', '2019-03-04', '71011851484', '7'),
('8', 'Cezary', 'Stój', '1990-07-07', '2015-02-11', '55031475853', '8');

INSERT INTO `mpk_bd2`.`brygadzista` (`id_brygadzista`, `id_pracownik`) VALUES ('1', '2');
INSERT INTO `mpk_bd2`.`brygadzista` (`id_brygadzista`, `id_pracownik`) VALUES ('2', '8');

INSERT INTO `mpk_bd2`.`administrator` (`id_administrator`, `id_pracownik`) VALUES ('1', '1');


INSERT INTO `mpk_bd2`.`brygada` (`id_brygada`, `id_brygadzista`) VALUES ('1', '1');
INSERT INTO `mpk_bd2`.`brygada` (`id_brygada`, `id_brygadzista`) VALUES ('2', '2');

INSERT INTO `mpk_bd2`.`kierowca` (`id_kierowca`, `nr_seryjny_prawa_jazdy`, `kat_prawa_jazdy`, `id_pracownik`, `id_brygada`)
 VALUES ('1', '4433312', 'D', '3', '1'),
('2', '5553127', 'D', '4', '1'),
('3', '4177010', 'D', '5', '1'),
('4', '8921067', 'D', '6', '2'),
('5', '4444404', 'D', '7', '2');


INSERT INTO `mpk_bd2`.`cennik` (`id_cennik`, `cena`, `rodzaj`, `typ_przejazdu`, `id_administrator`) VALUES ('1', '3', '1', 'miejski', '1');

INSERT INTO `mpk_bd2`.`linia_autobusowa` (`id_linia_autobusowa`, `typ_linii`) VALUES ('1', 'm');
INSERT INTO `mpk_bd2`.`linia_autobusowa` (`id_linia_autobusowa`, `typ_linii`) VALUES ('2', 'm');
INSERT INTO `mpk_bd2`.`linia_autobusowa` (`id_linia_autobusowa`, `typ_linii`) VALUES ('3', 'm');
INSERT INTO `mpk_bd2`.`linia_autobusowa` (`id_linia_autobusowa`, `typ_linii`) VALUES ('4', 'm');
INSERT INTO `mpk_bd2`.`linia_autobusowa` (`id_linia_autobusowa`, `typ_linii`) VALUES ('5', 'm');

INSERT INTO `mpk_bd2`.`pojazd` (`id_pojazd`, `przeglad_techniczny`, `maks_liczba_pasazerow`, `nr_rejestracyjny`, `nr_vin`, `id_brygada`) VALUES 
('1', '2022-05-05 00:00:00.000000', '120', 'DW54G43', 'GBV4444', '1'),
('2', '2022-04-11 00:00:00.000000', '120', 'DWJD4JD', 'KLM6643', '1'),
('3', '2022-02-02 00:00:00.000000', '145', 'DW515HY', 'H6G33JK', '1'),
('4', '2021-06-13 00:00:00.000000', '130', 'DW44TH3', 'JDV5498', '2'),
('5', '2022-03-11 00:00:00.000000', '130', 'DW99NBS', 'QCQ5462', '2');

INSERT INTO `mpk_bd2`.`przystanek` (`id_przystanek`, `nazwa_przystanek`, `id_adres`) VALUES 
('1', 'Libieta', '5'),
('2', 'Monte Cassino', '6'),
('3', 'Okrzei', '7'),
('4', 'Partyzantów', '8'),
('5', 'Tramwajowa', '9'),
('6', 'Kliniki', '10'),
('7', 'Plac Grunwaldzki', '11'),
('8', 'Skwer Krasińskiego', '12'),
('9', 'Dwrocowa Dworzec Główny', '13'),
('10', 'Dyrekcyjna', '14'),
('11', 'Borowska', '15');

INSERT INTO `mpk_bd2`.`trasa` (`nr_linii`, `nr_przystanku_na_trasie`, `id_przystanek`, `id_trasa`) VALUES 
('1', '1', '1', '1'),
('1', '2', '2', '2'),
('1', '3', '3', '3'),
('1', '4', '4', '4'),
('2', '1', '5', '5'),
('2', '2', '6', '6'),
('2', '1', '8', '7'),
('2', '2', '9', '8'),
('2', '3', '10', '9'),
('2', '4', '11', '10'),
('3', '1', '1', '11'),
('3', '2', '3', '12'),
('3', '3', '5', '13'),
('3', '4', '7', '14'),
('3', '5', '9', '15'),
('4', '1', '2', '16'),
('4', '2', '5', '17'),
('4', '3', '8', '18'),
('4', '4', '11', '19');

INSERT INTO `mpk_bd2`.`fragment_kursu` (`id_kurs`, `nr_linii`, `godzina_startu`, `przystanek_startowy`, `przystanek_koncowy`) VALUES ('1', '1', '2038-01-19 03:14:07', '1', '4');
INSERT INTO `mpk_bd2`.`fragment_kursu` (`id_kurs`, `nr_linii`, `godzina_startu`, `przystanek_startowy`, `przystanek_koncowy`) VALUES ('2', '1', '2038-01-19 03:14:07', '5', '7');
INSERT INTO `mpk_bd2`.`fragment_kursu` (`id_kurs`, `nr_linii`, `godzina_startu`, `przystanek_startowy`, `przystanek_koncowy`) VALUES ('3', '1', '2038-01-19 03:14:07', '8', '11');
INSERT INTO `mpk_bd2`.`fragment_kursu` (`id_kurs`, `nr_linii`, `godzina_startu`, `przystanek_startowy`, `przystanek_koncowy`) VALUES ('4', '2', '2038-01-19 03:14:07', '1', '9');
INSERT INTO `mpk_bd2`.`fragment_kursu` (`id_kurs`, `nr_linii`, `godzina_startu`, `przystanek_startowy`, `przystanek_koncowy`) VALUES ('5', '3', '2038-01-19 03:14:07', '2', '11');

INSERT INTO `mpk_bd2`.`rozklad_jazdy_administratora` (`id_rozklad_jazdy_admin`, `id_przystanek`, `nr_linii`, `id_administrator`, `data_odjazdu`) VALUES 
('1', '1', '17', '1', '2018-01-19 09:14:07'),
('2', '1', '22', '1', '2018-01-19 09:17:07'),
('3', '1', '43', '1', '2018-01-19 09:16:07'),
('4', '1', '56', '1', '2018-01-19 09:20:07'),
('5', '1', '2', '1', '2018-01-19 09:22:07');

INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_rozklad_jazdy_brygadzisty`, `id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`) VALUES ('1', '1', '1', '1', '2038-01-19 03:14:07', '1', '1');
INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_rozklad_jazdy_brygadzisty`, `id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`) VALUES ('2', '2', '1', '2', '2038-01-19 03:14:07', '2', '1');
INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_rozklad_jazdy_brygadzisty`, `id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`) VALUES ('3', '3', '1', '3', '2038-01-19 03:14:07', '3', '1');
INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_rozklad_jazdy_brygadzisty`, `id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`) VALUES ('4', '4', '2', '4', '2038-01-19 03:14:07', '4', '1');
INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_rozklad_jazdy_brygadzisty`, `id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`) VALUES ('5', '5', '2', '5', '2038-01-19 03:14:07', '5', '1');