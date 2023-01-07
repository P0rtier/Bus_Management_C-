DROP ROLE IF EXISTS brygadzista_role;
CREATE ROLE brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`brygada` TO brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`rozklad_jazdy_brygadzisty` TO brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`fragment_kursu` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`pojazd` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`brygadzista` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`kierowca` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`cennik` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`adres` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`ulica` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`miejscowosc` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`linia_autobusowa` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`przystanek` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`brygadzista_rozklad_jazdy_administratora_view` TO brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`brygadzista_rozklad_jazdy_brygadzisty_view` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`brygadzista_pracownik_view` TO brygadzista_role;
GRANT SELECT ON `mpk_bd2`.`kierowca_rozklad_jazdy_brygadzisty_view` TO brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`kierowca_brygada_view` TO brygadzista_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.`brygadzista_brygada_view` TO brygadzista_role;

DROP ROLE IF EXISTS kierowca_role;
CREATE ROLE kierowca_role;
GRANT SELECT ON `mpk_bd2`.`pojazd` TO kierowca_role;
GRANT SELECT ON `mpk_bd2`.`kierowca` TO kierowca_role;
GRANT SELECT ON `mpk_bd2`.`cennik` TO kierowca_role;
GRANT SELECT ON `mpk_bd2`.`kierowca_brygada_view` TO kierowca_role;
GRANT SELECT ON `mpk_bd2`.`kierowca_rozklad_jazdy_brygadzisty_view` TO kierowca_role;
GRANT SELECT ON `mpk_bd2`.`kierowca_rozklad_jazdy_administratora_view` TO kierowca_role;


DROP ROLE IF EXISTS administrator_role;
CREATE ROLE administrator_role;
GRANT SELECT, INSERT, UPDATE, DELETE ON `mpk_bd2`.* TO administrator_role;
GRANT create user on *.* to administrator_role WITH grant option;
GRANT brygadzista_role to administrator_role with admin option;
GRANT kierowca_role to administrator_role with admin option;



DROP USER IF EXISTS `Administrator`;
CREATE USER `Administrator` IDENTIFIED BY '123';
GRANT administrator_role TO `Administrator` with admin option;
SET DEFAULT ROLE ALL TO `Administrator`;

DROP USER IF EXISTS `Brygadzista`;
CREATE USER `Brygadzista` IDENTIFIED BY '123';
GRANT brygadzista_role TO 'Brygadzista';
SET DEFAULT ROLE ALL TO 'Brygadzista';

DROP USER IF EXISTS `Kierowca`;
CREATE USER `Kierowca` IDENTIFIED BY '123';
GRANT kierowca_role TO `Kierowca`;
SET DEFAULT ROLE ALL TO `Kierowca`;



DROP USER IF EXISTS `1`;
CREATE USER `1` IDENTIFIED BY '123';
GRANT administrator_role TO `1` with admin option;
SET DEFAULT ROLE ALL TO `1`;

DROP USER IF EXISTS `2`;
CREATE USER `2` IDENTIFIED BY '123';
GRANT brygadzista_role TO `2`;
SET DEFAULT ROLE ALL TO `2`;

DROP USER IF EXISTS `8`;
CREATE USER `8` IDENTIFIED BY '123';
GRANT brygadzista_role TO `8`;
SET DEFAULT ROLE ALL TO `8`;

DROP USER IF EXISTS `3`;
CREATE USER `3` IDENTIFIED BY '123';
GRANT kierowca_role TO `3`;
SET DEFAULT ROLE ALL TO `3`;

DROP USER IF EXISTS `4`;
CREATE USER `4` IDENTIFIED BY '123';
GRANT kierowca_role TO `4`;
SET DEFAULT ROLE ALL TO `4`;

DROP USER IF EXISTS `5`;
CREATE USER `5` IDENTIFIED BY '123';
GRANT kierowca_role TO `5`;
SET DEFAULT ROLE ALL TO `5`;

DROP USER IF EXISTS `6`;
CREATE USER `6` IDENTIFIED BY '123';
GRANT kierowca_role TO `6`;
SET DEFAULT ROLE ALL TO `6`;

DROP USER IF EXISTS `7`;
CREATE USER `7` IDENTIFIED BY '123';
GRANT kierowca_role TO `7`;
SET DEFAULT ROLE ALL TO `7`;