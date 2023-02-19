CREATE DATABASE EcommerceTest;

CREATE TABLE Category(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Category varchar(50)
);

CREATE TABLE Item(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
ItemName varchar(100),
Price decimal(10,2),
Media varchar(100),
ItemCategoryID int FOREIGN KEY REFERENCES Category(ID)
);

CREATE TABLE Users(
ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
UserName varchar(50),
Email varchar(50),
Password varchar(50)
);


INSERT INTO Category VALUES
('Beds'),
('Rugs'),
('Cooking'),
('Decor'),
('Eating'),
('Gardening')



INSERT INTO Item VALUES 
('Large bed', 299.99, 'https://www.ikea.com/us/en/images/products/malm-bed-frame-high-black-brown-luroey__0638608_pe699032_s5.jpg?f=xxxs', 1),
('Medium bed', 179.99, 'https://www.ikea.com/us/en/images/products/tarva-bed-frame-pine__0655004_pe708894_s5.jpg?f=xxxs', 1),
('Orange rug', 26.99, 'https://www.ikea.com/us/en/images/products/trampa-door-mat-natural__0721300_pe733149_s5.jpg?f=xxxs', 2),
('Black clock', 11.99, 'https://www.ikea.com/us/en/images/products/pluttis-wall-clock-low-voltage-black__1013114_pe829054_s5.jpg?f=xxxs', 4),
('Small bed', 99.99, 'https://www.ikea.com/us/en/images/products/slaekt-ext-bed-frame-with-slatted-bed-base-white-birch__0792601_pe764766_s5.jpg?f=l', 1),
('Earth globe', 9.99, 'https://www.ikea.com/us/en/images/products/lindrande-decoration-earth-globe-black__0665697_pe713144_s5.jpg?f=xs', 4),
('White microwave oven', 59.99, 'https://www.ikea.com/us/en/images/products/tillreda-microwave-oven-white__0912596_pe783444_s5.jpg?f=xxxs', 3),
('Cyan rug', 19.99, 'https://www.ikea.com/us/en/images/products/toftbo-bath-mat-stripe-blue__1041126_pe840893_s5.jpg?f=xs', 2),
('Gas cooktop', 149.99, 'https://www.ikea.com/us/en/images/products/avbraenning-gas-cooktop-stainless-steel__0930887_pe790929_s5.jpg?f=xxxs', 3),
('Silver fridge', 179.99, 'https://www.ikea.com/us/en/images/products/faerskhet-bottom-freezer-refrigerator-stainless-steel-color__0956332_pe804798_s5.jpg?f=xxxs', 3),
('Wooden hourglass', 8.99, 'https://www.ikea.com/us/en/images/products/eftertaenka-decorative-hourglass-clear-glass-sand__1006429_pe825808_s5.jpg?f=xxxs', 4),
('Dracaena marginata', 14.99, 'https://www.ikea.com/us/en/images/products/dracaena-marginata-potted-plant-dragon-tree-3-stem__67436_pe181279_s5.jpg?f=s', 6),
('Plant pot', 16.99, 'https://www.ikea.com/us/en/images/products/persillade-plant-pot-dark-gray__0439713_pe592235_s5.jpg?f=s', 6),
('Green fejka', 7.99, 'https://www.ikea.com/us/en/images/products/fejka-artificial-potted-plant-indoor-outdoor-hanging-eucalyptus__0817871_pe774216_s5.jpg?f=s', 6),
('Stripped rug', 24.99, 'https://www.ikea.com/us/en/images/products/vrensted-rug-flatwoven-in-outdoor-beige-light-blue__0936257_pe793190_s5.jpg?f=s', 2),
('Fur rug', 28.99, 'https://www.ikea.com/us/en/images/products/vindebaek-rug-high-pile-gray__1014737_pe829725_s5.jpg?f=s', 2),
('Flatware cutlery', 5.99, 'https://www.ikea.com/us/en/images/products/mopsig-16-piece-flatware-set__0759952_pe750550_s5.jpg?f=s', 5),
('Glass', 1.99, 'https://www.ikea.com/us/en/images/products/pokal-glass-clear-glass__0713251_pe729361_s5.jpg?f=s', 5),
('Bamboo bowl', 13.99, 'https://www.ikea.com/us/en/images/products/blanda-matt-serving-bowl-bamboo__0711996_pe728647_s5.jpg?f=s', 5),
('Sedge basket', 3.99, 'https://www.ikea.com/us/en/images/products/pennfisk-basket-natural-sedge-handmade-round__1115634_pe872173_s5.jpg?f=s', 5)





