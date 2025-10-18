use EcommerceDB

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
 
 go

INSERT INTO Products 
    (Name, Description, Price, Stock, ImageUrl, CategoryId, AddedByUserId) 
VALUES

-- ----------------------------------------------------------------------
-- 1. Smartphones (CategoryId: 1)
-- ----------------------------------------------------------------------
('iPhone 17 Pro Max', 'Apple flagship with A19 Bionic chip, ProMotion display, and 5x optical zoom camera.', 1299.00, 45, '~/images/Icon.png', 1, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Google Pixel 9 Pro', 'Premium Android experience with the latest Tensor G5 chip and advanced computational photography.', 999.00, 55, '~/images/Icon.png', 1, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Samsung Galaxy Z Fold 7', 'Latest generation foldable phone with a large tablet-sized inner screen and S Pen support.', 1999.00, 20, '~/images/Icon.png', 1, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Samsung Galaxy A56 5G', 'Excellent mid-range 5G phone offering great battery life and a vibrant AMOLED display.', 429.99, 120, '~/images/Icon.png', 1, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 2. Laptops (CategoryId: 2)
-- ----------------------------------------------------------------------
('MacBook Air 13-inch (M4)', 'Ultralight laptop powered by the M4 chip, featuring a fanless design and long battery life.', 1099.00, 70, '~/images/Icon.png', 2, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Dell XPS 13 Plus', 'Premium ultrabook with a stunning 4K OLED display and modern, minimalist design.', 1499.00, 35, '~/images/Icon.png', 2, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Lenovo ThinkPad X1 Carbon Gen 13', 'Legendary business laptop known for its durability, security features, and lightweight build.', 1817.00, 25, '~/images/Icon.png', 2, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('ASUS ROG Zephyrus G14', 'Powerful, compact gaming laptop with AMD Ryzen CPU and NVIDIA RTX 40-series graphics.', 1699.99, 40, '~/images/Icon.png', 2, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 3. Desktop Computers (CategoryId: 3)
-- ----------------------------------------------------------------------
('Alienware Aurora R16 Gaming', 'High-end gaming desktop with liquid cooling and NVIDIA RTX 5090 graphics card.', 3299.00, 10, '~/images/Icon.png', 3, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Dell OptiPlex 7020 Tower', 'Reliable business desktop tower designed for productivity and easy maintenance.', 899.99, 60, '~/images/Icon.png', 3, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Apple Mac Studio (M3 Ultra)', 'Professional desktop workstation for video editing and 3D rendering with M3 Ultra chip.', 3999.00, 8, '~/images/Icon.png', 3, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Lenovo ThinkCentre Neo 55s SFF', 'Compact, small form factor PC, ideal for small business environments.', 534.65, 75, '~/images/Icon.png', 3, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 4. Tablets (CategoryId: 4)
-- ----------------------------------------------------------------------
('iPad Pro 13-inch (M4)', 'Ultra-thin Pro tablet featuring an M4 chip and revolutionary Ultra Retina XDR display.', 1199.00, 50, '~/images/Icon.png', 4, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Samsung Galaxy Tab S10 Ultra', 'Android flagship tablet with a massive 14.6-inch AMOLED screen and S Pen included.', 999.99, 30, '~/images/Icon.png', 4, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Microsoft Surface Pro 11', 'Powerful 2-in-1 Windows tablet with detachable keyboard and Intel Core Ultra processor.', 899.00, 40, '~/images/Icon.png', 4, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Lenovo Tab P11 Gen 2', 'Mid-range tablet with a 11.5-inch 120Hz display and included Precision Pen 2.', 349.99, 90, '~/images/Icon.png', 4, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 5. Cameras (CategoryId: 5)
-- ----------------------------------------------------------------------
('Canon EOS R5 Mark II', 'Full-frame mirrorless camera for high-resolution stills and 8K video.', 4299.00, 7, '~/images/Icon.png', 5, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Sony Alpha A7 IV', 'Versatile full-frame mirrorless camera known for its hybrid photo and video capabilities.', 2499.00, 15, '~/images/Icon.png', 5, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Fujifilm X-T5', 'APS-C mirrorless camera with a retro-style body and 40.2MP sensor.', 1699.00, 22, '~/images/Icon.png', 5, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('DJI Osmo Pocket 3', 'Pocket-sized gimbal camera with 1-inch sensor, perfect for vlogging and stable video.', 519.00, 80, '~/images/Icon.png', 5, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 6. Televisions (CategoryId: 6)
-- ----------------------------------------------------------------------
('LG G5 OLED 65"', 'Flagship OLED TV with MLA technology for extreme brightness and gallery design.', 2799.00, 12, '~/images/Icon.png', 6, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Samsung S95F 4K OLED 77"', 'Quantum Dot OLED TV with unmatched color volume and clarity in a large format.', 3999.99, 9, '~/images/Icon.png', 6, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('TCL QM8K QD-Mini LED 85"', 'High-value, high-brightness Mini-LED TV with thousands of local dimming zones.', 2199.00, 18, '~/images/Icon.png', 6, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Sony Bravia 8 II 55"', 'OLED TV focused on cinematic color accuracy and deep integration with PlayStation 5.', 1799.00, 25, '~/images/Icon.png', 6, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 7. Audio Equipment (CategoryId: 7)
-- ----------------------------------------------------------------------
('Sony WH-1000XM6', 'Industry-leading wireless noise-cancelling headphones with enhanced sound quality.', 399.99, 150, '~/images/Icon.png', 7, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Bose Soundbar 900', 'Premium smart soundbar with Dolby Atmos and proprietary spatial sound processing.', 899.00, 40, '~/images/Icon.png', 7, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Apple AirPods Pro (3rd Gen)', 'True wireless earbuds with adaptive noise cancellation and personalized spatial audio.', 249.00, 200, '~/images/Icon.png', 7, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Klipsch RP-600M Bookshelf Speakers', 'High-fidelity passive bookshelf speakers with signature Tractrix Horn technology.', 549.00, 28, '~/images/Icon.png', 7, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 8. Gaming Consoles (CategoryId: 8)
-- ----------------------------------------------------------------------
('PlayStation 5 Pro', 'Enhanced model of the PS5 with accelerated ray tracing and more stable 4K performance.', 699.99, 65, '~/images/Icon.png', 8, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Nintendo Switch 2', 'Next-generation hybrid console with better graphics and backwards compatibility.', 499.00, 80, '~/images/Icon.png', 8, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Xbox Series X', 'Microsoft most powerful console, supporting 4K gaming at up to 120fps.', 499.00, 55, '~/images/Icon.png', 8, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Steam Deck OLED 1TB', 'Handheld PC gaming device with a vibrant OLED screen and longer battery life.', 649.00, 30, '~/images/Icon.png', 8, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 9. Wearable Technology (CategoryId: 9)
-- ----------------------------------------------------------------------
('Apple Watch Ultra 3', 'Rugged, high-end smartwatch designed for extreme sports and extended battery life.', 799.00, 40, '~/images/Icon.png', 9, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Samsung Galaxy Watch 7 Classic', 'Premium Android-compatible smartwatch with rotating bezel and advanced health sensors.', 449.00, 50, '~/images/Icon.png', 9, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Garmin Fenix 8 Pro', 'Multi-sport GPS watch with solar charging and mapping for outdoor adventurers.', 999.99, 18, '~/images/Icon.png', 9, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Oura Ring Gen 3', 'A smart ring that tracks sleep, activity, and recovery metrics unobtrusively.', 299.00, 110, '~/images/Icon.png', 9, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),

-- ----------------------------------------------------------------------
-- 10. Computer Peripherals (CategoryId: 10)
-- ----------------------------------------------------------------------
('Dell Ultrasharp U2724D', '27-inch QHD monitor for color-critical work with high refresh rate.', 384.99, 60, '~/images/Icon.png', 10, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Logitech G Pro X Superlight 2', 'Ultra-lightweight wireless gaming mouse favored by esports professionals.', 159.99, 130, '~/images/Icon.png', 10, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Keychron Q1 Pro Mechanical Keyboard', 'Gasket-mounted wireless mechanical keyboard with QMK/VIA support.', 189.99, 70, '~/images/Icon.png', 10, 'ef1d6188-4ff7-49d3-b910-8f785782479e'),
('Crucial T705 2TB NVMe SSD', 'PCIe 5.0 internal solid state drive offering extreme read/write speeds.', 259.00, 95, '~/images/Icon.png', 10, 'ef1d6188-4ff7-49d3-b910-8f785782479e');