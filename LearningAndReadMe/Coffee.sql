-- Create the simplified table
CREATE TABLE IF NOT EXISTS Coffee 
(
    id INTEGER PRIMARY KEY,
    name VARCHAR(100),
    category VARCHAR(50),
    temp VARCHAR(10),
    description TEXT,
    price DECIMAL(4,2)
);

-- Insert all drinks with sequential IDs
INSERT INTO Coffee (id, name, category, temp, description, price) VALUES
(1, 'House Blend', 'Coffee', 'Both', 'Rich and smooth medium roast with notes of chocolate and caramel', 3.25),
(2, 'Dark Roast', 'Coffee', 'Both', 'Bold and intense with a smoky finish', 3.25),
(3, 'Pour Over', 'Coffee', 'Hot', 'Single-origin beans, hand-poured to perfection', 4.50),
(4, 'Espresso', 'Espresso', 'Hot', 'Pure and powerful', 2.95),
(5, 'Americano', 'Espresso', 'Both', 'Espresso with hot water', 3.50),
(6, 'Cappuccino', 'Espresso', 'Hot', 'Equal parts espresso, steamed milk, and foam', 4.25),
(7, 'Latte', 'Espresso', 'Both', 'Espresso with steamed milk and light foam', 4.50),
(8, 'Mocha', 'Espresso', 'Both', 'Espresso with chocolate, steamed milk, and whipped cream', 4.75),
(9, 'Loose Leaf Tea', 'Tea', 'Both', 'English Breakfast, Earl Grey, Green, or Chamomile', 3.50),
(10, 'Chai Latte', 'Tea', 'Both', 'Spiced black tea with steamed milk', 4.50),
(11, 'Hot Chocolate', 'Other', 'Both', 'Rich chocolate with steamed milk and whipped cream', 3.75),
(12, 'Cold Brew', 'Coffee', 'Cold', 'Smooth, 24-hour steeped coffee', 4.25),
(13, 'Frappé', 'Other', 'Cold', 'Blended coffee with milk and ice', 5.25);