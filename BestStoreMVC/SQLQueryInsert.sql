INSERT INTO [dbo].[Products] ([Name], [Brand], [Category], [Price], [Description], [ImageFileName], [CreatedAt])  
VALUES  
('Laptop Pro X15', 'Dell', 'Laptop', 1299.99, 'High-performance laptop with Intel i7', 'laptop_pro_x15.jpg', GETDATE()),  
('Gaming Laptop G5', 'Asus', 'Laptop', 1599.99, 'Powerful gaming laptop with RTX 4070', 'gaming_laptop_g5.jpg', GETDATE()),  
('UltraWide Monitor 34"', 'LG', 'Monitor', 799.99, 'Curved ultrawide 34-inch monitor', 'ultrawide_monitor_34.jpg', GETDATE()),  
('Mechanical Keyboard K8', 'Keychron', 'Keyboard', 99.99, 'Wireless mechanical keyboard', 'keyboard_k8.jpg', GETDATE()),  
('Wireless Mouse MX Master 3', 'Logitech', 'Mouse', 99.99, 'Ergonomic wireless mouse', 'mouse_mx_master_3.jpg', GETDATE()),  
('Solid State Drive 1TB', 'Samsung', 'Storage', 129.99, 'Fast NVMe SSD 1TB', 'ssd_1tb.jpg', GETDATE()),  
('External HDD 4TB', 'Western Digital', 'Storage', 99.99, 'Portable 4TB external hard drive', 'hdd_4tb.jpg', GETDATE()),  
('Gaming Headset X200', 'Razer', 'Headset', 149.99, 'Surround sound gaming headset', 'headset_x200.jpg', GETDATE()),  
('Wireless Router AX6000', 'Netgear', 'Networking', 249.99, 'High-speed Wi-Fi 6 router', 'router_ax6000.jpg', GETDATE()),  
('Smartphone Galaxy S23', 'Samsung', 'Smartphone', 899.99, 'Latest flagship smartphone', 'galaxy_s23.jpg', GETDATE()),  
('Tablet Pro 12.9"', 'Apple', 'Tablet', 1099.99, '12.9-inch iPad Pro', 'tablet_pro_12.9.jpg', GETDATE()),  
('Bluetooth Speaker X5', 'JBL', 'Speaker', 79.99, 'Portable Bluetooth speaker', 'speaker_x5.jpg', GETDATE()),  
('Smartwatch Series 8', 'Apple', 'Smartwatch', 399.99, 'Latest Apple Watch Series 8', 'smartwatch_series_8.jpg', GETDATE()),  
('Portable Power Bank 20000mAh', 'Anker', 'Accessories', 49.99, 'High-capacity power bank', 'power_bank_20000.jpg', GETDATE()),  
('Graphics Card RTX 4080', 'NVIDIA', 'GPU', 1199.99, 'Powerful gaming graphics card', 'gpu_rtx_4080.jpg', GETDATE()),  
('Mechanical Gaming Mouse', 'SteelSeries', 'Mouse', 79.99, 'High-precision gaming mouse', 'gaming_mouse_steel.jpg', GETDATE()),  
('USB-C Docking Station', 'Belkin', 'Accessories', 149.99, 'Multi-port USB-C docking station', 'usb_c_dock.jpg', GETDATE()),  
('Noise Cancelling Headphones', 'Sony', 'Headphones', 349.99, 'Wireless noise-cancelling headphones', 'headphones_sony.jpg', GETDATE()),  
('Smart Home Hub', 'Google', 'Smart Home', 129.99, 'Voice-controlled smart home hub', 'smart_home_hub.jpg', GETDATE()),  
('Ergonomic Office Chair', 'Herman Miller', 'Furniture', 999.99, 'Adjustable ergonomic chair', 'office_chair.jpg', GETDATE());  

select * from Products;