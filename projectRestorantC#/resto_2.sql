IF db_id('resto2') IS NULL CREATE DATABASE resto2;
GO

USE resto2 ;

CREATE TABLE tdc 
(Type_de_composant VARCHAR(30) NOT NULL, PRIMARY KEY (Type_de_composant));

CREATE TABLE composants
(Type_de_composant VARCHAR(30) NOT NULL, Num_du_composant INT NOT NULL, Composant VARCHAR(30) NOT NULL UNIQUE,
PRIMARY KEY (Type_de_composant, Num_du_composant),
FOREIGN KEY (Type_de_composant) REFERENCES tdc(Type_de_composant) ON DELETE NO ACTION ON UPDATE NO ACTION);

CREATE TABLE commandes 
(Commande INT NOT NULL, TypeDeComposant VARCHAR(30) NOT NULL, NumDuComposant INT NOT NULL, 
PRIMARY KEY (Commande, TypeDeComposant),
FOREIGN KEY (TypeDeComposant, NumDuComposant) REFERENCES composants(Type_de_composant, Num_du_composant));

INSERT INTO tdc (Type_de_composant) VALUES ('plat principal');
INSERT INTO tdc (Type_de_composant) VALUES ('dessert');
INSERT INTO tdc (Type_de_composant) VALUES ('boisson');

INSERT INTO composants (Type_de_composant, Num_du_composant, Composant) VALUES ('plat principal', 1, 'Maigret de canard');
INSERT INTO composants (Type_de_composant, Num_du_composant, Composant) VALUES ('dessert', 1, 'Crème brulée');
INSERT INTO composants (Type_de_composant, Num_du_composant, Composant) VALUES ('dessert', 2, 'Tarte au chocolat');
INSERT INTO composants (Type_de_composant, Num_du_composant, Composant) VALUES ('boisson', 1, 'Vin maison');
INSERT INTO composants (Type_de_composant, Num_du_composant, Composant) VALUES ('boisson', 2, 'Coca-Cola');

INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) VALUES ( 1, 'plat principal', 1 );
INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) VALUES ( 1, 'dessert', 1 );
INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) VALUES ( 1, 'boisson', 1 );
INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) VALUES ( 2, 'plat principal', 1 );
INSERT INTO commandes (Commande, TypeDeComposant, NumDuComposant) VALUES ( 2, 'dessert', 2 );





 







