INSERT INTO contact (firstname, lastname, phone_number, ACTIVE, image) VALUES ("jony", "mujanovic", "0782587881", "1", "bonhomme");
INSERT INTO contact (firstname, lastname, phone_number, ACTIVE, image ) VALUES ("Ahmed", "mujanovic", "0772587881", "1", "bonhomme");
INSERT INTO contact (firstname, lastname, phone_number, ACTIVE, image) VALUES ("Adem", "mujanovic", "0792587881", "1", "bonhomme");
INSERT INTO contact (firstname, lastname, phone_number, active, image) VALUES ("Selma", "mujanovic", "0762587881", "1", "bonhomme");

INSERT INTO `group` (`name`) VALUES ('Onela');

INSERT INTO contact_has_group (Contact_idContact, Group_idGroup) VALUES ("1","1");