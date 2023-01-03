DROP PROCEDURE IF EXISTS insertToRozkladAdministatora;
delimiter //
CREATE PROCEDURE insertToRozkladAdministatora(IN id_przystanek int, IN id_linii int, IN data_odjazdu datetime(6), IN id_administrator int)
BEGIN
INSERT INTO `mpk_bd2`.`rozklad_jazdy_administratora` (`id_przystanek`, `nr_linii`, `data_odjazdu`, `id_administrator`, `data_dodania`) VALUES
(id_przystanek, id_linii, data_odjazdu, id_administrator, CURRENT_TIMESTAMP());
END //
delimiter ;


DROP PROCEDURE IF EXISTS insertToRozkladBrygadzisty;
delimiter //
CREATE PROCEDURE insertToRozkladBrygadzisty(IN id_fragment_kursu int, IN id_brygada int, IN id_kierowca int, IN godzina_startu_kierowcy datetime(6), IN id_pojazd int, IN id_rozklad_jazdy_admin int)
BEGIN
INSERT INTO `mpk_bd2`.`rozklad_jazdy_brygadzisty` (`id_fragment_kursu`, `id_brygada`, `id_kierowca`, `godzina_startu_kierowcy`, `id_pojazd`, `id_rozklad_admin`,  `data_dodania`) VALUES
(id_fragment_kursu, id_brygada, id_kierowca, godzina_startu_kierowcy, id_pojazd, id_rozklad_jazdy_admin, CURRENT_TIMESTAMP());
END //
delimiter ;

DROP PROCEDURE IF EXISTS insertToCennik;
delimiter //
CREATE PROCEDURE insertToCennik(IN cena int, IN rodzaj char(1), IN typ_przejazdu varchar(255), IN id_administrator int)
BEGIN
INSERT INTO `mpk_bd2`.`cennik` (`cena`, `rodzaj`, `typ_przejazdu`, `id_administrator`, `data_dodania`) VALUES
(cena, rodzaj, typ_przejazdu, id_administrator, CURRENT_TIMESTAMP());
END //
delimiter ;

#call insertToCennik(2, 'N','jendorazowy', '1');
#call insertToRozkladAdministatora(1, 2, '2022-05-05 00:00:00.000000', 1);
#call insertToRozkladBrygadzisty(1, 1, 1, '2022-05-05 00:00:00.000000', 1, 1);

