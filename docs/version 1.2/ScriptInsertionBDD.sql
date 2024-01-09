INSERT INTO contact (firstname, lastname, phone_number, active) VALUES ("jony", "mujanovic", "0782587881", "1");
INSERT INTO contact (firstname, lastname, phone_number, active) VALUES ("Ahmed", "mujanovic", "0772587881", "1");
INSERT INTO contact (firstname, lastname, phone_number, active) VALUES ("Adem", "mujanovic", "0792587881", "1");
INSERT INTO contact (firstname, lastname, phone_number, active) VALUES ("Selma", "mujanovic", "0762587881", "1");

INSERT INTO `group` (`name`) VALUES ('Onela');

INSERT INTO contact_has_group (Contact_idContact, Group_idGroup) VALUES ("1","1");