INSERT INTO Categories(Name, Description) VALUES
('Smartphones', 'Mobile devices that combine telephone, computing, and multimedia functions.'),
('Laptops', 'Portable computers suitable for mobile use.'),
('Desktop Computers', 'Stationary computers suitable for use at a single location.'),
('Tablets', 'Portable computers with a touchscreen display, typically smaller than a laptop.'),
('Cameras', 'Devices for recording still images or video.'),
('Televisions', 'Electronic systems for receiving and displaying broadcasting visual images and sound.'),
('Audio Equipment', 'Devices for sound reproduction and recording, such as headphones, speakers, and soundbars.'),
('Gaming Consoles', 'Specialized computers used for playing video games.'),
('Wearable Technology', 'Electronic devices that can be worn on the body, such as smartwatches and fitness trackers.'),
('Computer Peripherals', 'Input/output and storage devices that connect to a computer, like keyboards, mice, and external drives.');
 
GO

INSERT INTO Products 
    (Name, Description, Price, Stock, ImageUrl, CategoryId, AddedByUserId) 
VALUES

-- ----------------------------------------------------------------------
-- 1. Smartphones (CategoryId: 1) - (2 Products)
-- ----------------------------------------------------------------------
('iPhone 17 Pro Max', 'Apple flagship with A19 Bionic chip, ProMotion display, and 5x optical zoom camera.', 1299.00, 45, 'images/Icon.png', 1, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Samsung Galaxy Z Fold 7', 'Latest generation foldable phone with a large tablet-sized inner screen and S Pen support.', 1999.00, 20, 'images/Icon.png', 1, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 2. Laptops (CategoryId: 2) - (2 Products)
-- ----------------------------------------------------------------------
('MacBook Air 13-inch (M4)', 'Ultralight laptop powered by the M4 chip, featuring a fanless design and long battery life.', 1099.00, 70, 'images/Icon.png', 2, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Dell XPS 13 Plus', 'Premium ultrabook with a stunning 4K OLED display and modern, minimalist design.', 1499.00, 35, 'images/Icon.png', 2, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 3. Desktop Computers (CategoryId: 3) - (2 Products)
-- ----------------------------------------------------------------------
('Alienware Aurora R16 Gaming', 'High-end gaming desktop with liquid cooling and NVIDIA RTX 5090 graphics card.', 3299.00, 10, 'images/Icon.png', 3, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Apple Mac Studio (M3 Ultra)', 'Professional desktop workstation for video editing and 3D rendering with M3 Ultra chip.', 3999.00, 8, 'images/Icon.png', 3, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 4. Tablets (CategoryId: 4) - (2 Products)
-- ----------------------------------------------------------------------
('iPad Pro 13-inch (M4)', 'Ultra-thin Pro tablet featuring an M4 chip and revolutionary Ultra Retina XDR display.', 1199.00, 50, 'images/Icon.png', 4, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Samsung Galaxy Tab S10 Ultra', 'Android flagship tablet with a massive 14.6-inch AMOLED screen and S Pen included.', 999.99, 30, 'images/Icon.png', 4, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 5. Cameras (CategoryId: 5) - (2 Products)
-- ----------------------------------------------------------------------
('Canon EOS R5 Mark II', 'Full-frame mirrorless camera for high-resolution stills and 8K video.', 4299.00, 7, 'images/Icon.png', 5, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Sony Alpha A7 IV', 'Versatile full-frame mirrorless camera known for its hybrid photo and video capabilities.', 2499.00, 15, 'images/Icon.png', 5, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 6. Televisions (CategoryId: 6) - (2 Products)
-- ----------------------------------------------------------------------
('LG G5 OLED 65"', 'Flagship OLED TV with MLA technology for extreme brightness and gallery design.', 2799.00, 12, 'images/Icon.png', 6, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Samsung S95F 4K OLED 77"', 'Quantum Dot OLED TV with unmatched color volume and clarity in a large format.', 3999.99, 9, 'images/Icon.png', 6, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 7. Audio Equipment (CategoryId: 7) - (2 Products)
-- ----------------------------------------------------------------------
('Sony WH-1000XM6', 'Industry-leading wireless noise-cancelling headphones with enhanced sound quality.', 399.99, 150, 'images/Icon.png', 7, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Bose Soundbar 900', 'Premium smart soundbar with Dolby Atmos and proprietary spatial sound processing.', 899.00, 40, 'images/Icon.png', 7, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 8. Gaming Consoles (CategoryId: 8) - (2 Products)
-- ----------------------------------------------------------------------
('PlayStation 5 Pro', 'Enhanced model of the PS5 with accelerated ray tracing and more stable 4K performance.', 699.99, 65, 'images/Icon.png', 8, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Nintendo Switch 2', 'Next-generation hybrid console with better graphics and backwards compatibility.', 499.00, 80, 'images/Icon.png', 8, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 9. Wearable Technology (CategoryId: 9) - (2 Products)
-- ----------------------------------------------------------------------
('Apple Watch Ultra 3', 'Rugged, high-end smartwatch designed for extreme sports and extended battery life.', 799.00, 40, 'images/Icon.png', 9, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Samsung Galaxy Watch 7 Classic', 'Premium Android-compatible smartwatch with rotating bezel and advanced health sensors.', 449.00, 50, 'images/Icon.png', 9, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),

-- ----------------------------------------------------------------------
-- 10. Computer Peripherals (CategoryId: 10) - (2 Products)
-- ----------------------------------------------------------------------
('Dell Ultrasharp U2724D', '27-inch QHD monitor for color-critical work with high refresh rate.', 384.99, 60, 'images/Icon.png', 10, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'),
('Logitech G Pro X Superlight 2', 'Ultra-lightweight wireless gaming mouse favored by esports professionals.', 159.99, 0, 'images/Icon.png', 10, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'), -- 🚫 OUT OF STOCK
('Crucial T705 2TB NVMe SSD', 'PCIe 5.0 internal solid state drive offering extreme read/write speeds.', 259.00, 0, 'images/Icon.png', 10, '1f1ca0cd-899d-4da8-ac6c-ffe8f6dbc3ef'); -- 🚫 OUT OF STOCK (Total of 21 Products, including 2 OOS, for varied selection)

GO
