CREATE TABLE Sparepart(
	kode_sparepart VARCHAR(20) NOT NULL PRIMARY KEY,
	nama_sparepart VARCHAR(50),
	jumlah INT,
	jumlah_minimum INT,
	harga INT,
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)
	);
CREATE TABLE Pelanggan(
	ktp_pelanggan VARCHAR(30) NOT NULL PRIMARY KEY,
	nama_pelanggan VARCHAR(100),
	email VARCHAR(50),
	password VARCHAR(50),
	alamat VARCHAR(100),
	no_telp VARCHAR(20),
	);

CREATE TABLE Admins(
	ktp_admin VARCHAR(30) NOT NULL PRIMARY KEY,
	nama_admin VARCHAR(100),
	email VARCHAR(50),
	password VARCHAR(50),
	alamat VARCHAR(100),
	no_telp VARCHAR(20),
	role INT,
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)
);



CREATE TABLE Kendaraan(
	no_pol VARCHAR(30) NOT NULL PRIMARY KEY,
	merk VARCHAR(20),
	tipe VARCHAR(20),
	transmisi VARCHAR(20),
	kapasitas INT,
	tahun VARCHAR(5),
	ktp_pelanggan VARCHAR(30),
	total_servis INT,
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE CASCADE
		ON UPDATE CASCADE
	);

CREATE TABLE Bookings(
	id_booking INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ktp_pelanggan VARCHAR(30),
	no_pol VARCHAR(30),
	tanggal DATE,
	keluhan VARCHAR(100),
	catatan VARCHAR(100),
	antrean INT,
	status VARCHAR(20),
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE CASCADE
		ON UPDATE CASCADE
	);

CREATE TABLE BookingsSparepart(
	id_booking INT,
	kode_sparepart VARCHAR(20),
	FOREIGN KEY (id_booking)
		REFERENCES Bookings(id_booking)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (kode_sparepart)
		REFERENCES Sparepart(kode_sparepart)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );

CREATE TABLE Riwayat(
	id_riwayat INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ktp_pelanggan VARCHAR(30),
	no_pol VARCHAR(30),
	tanggal DATE,
	ktp_admin VARCHAR(30),
	keluhan VARCHAR(100),
	catatan VARCHAR(100),
	total_harga INT,
	status VARCHAR(20)
						
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan),
	FOREIGN KEY (no_pol)
		REFERENCES Kendaraan(no_pol)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (ktp_admin)
		REFERENCES Admins(ktp_admin)
		ON DELETE CASCADE
		ON UPDATE CASCADE
	);



CREATE TABLE RiwayatSparepart(
	id_riwayat INT,
	kode_sparepart VARCHAR(20),
	FOREIGN KEY (id_riwayat)
		REFERENCES Riwayat(id_riwayat)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (kode_sparepart)
		REFERENCES Sparepart(kode_sparepart)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );

CREATE TABLE JasaServis(
	id_jasaServis INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nama_jasaServis VARCHAR(100),
	harga INT
	);

CREATE TABLE History(
	id_history INT PRIMARY KEY IDENTITY(1,1),
	nama_tabel VARCHAR(20) NOT NULL,
	id_record INT NOT NULL,
	tipe_aksi VARCHAR(10),
	json_data NVARCHAR(MAX),
	diubah_oleh VARCHAR(100),
					);


INSERT INTO Admins(ktp_admin,nama_admin,email,password,alamat,no_telp,role,image_name,image_data) 
VALUES (
	 '087719631265', 
    'Rifki Yoga Syahbani', 
    'yoga@gmail.com', 
    'Yoga12345', 
    'Jl. Merdeka No. 1', 
    '08123456789', 
	1,
    'FotoSaya.jpg', 
    (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\FotoSaya.jpg', SINGLE_BLOB) AS img)
);


INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp)
VALUES 
('1234567890123456', 'John Doe', 'john.doe@example.com', 'password123', 'Jl. Merdeka No. 123', '081234567890'),
('2345678901234567', 'Jane Smith', 'jane.smith@example.com', 'password456', 'Jl. Sudirman No. 456', '081234567891'),
('3456789012345678', 'Alice Johnson', 'alice.johnson@example.com', 'password789', 'Jl. Thamrin No. 789', '081234567892');

INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_name, image_data)
VALUES 
('9876543210987654', 'Admin One', 'admin.one@example.com', 'admin123', 'Jl. Admin No. 1', '081234567893', 1, 'admin1.jpg', NULL),
('8765432109876543', 'Admin Two', 'admin.two@example.com', 'admin456', 'Jl. Admin No. 2', '081234567894', 2, 'admin2.jpg', NULL);

INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis)
VALUES 
('B 1234 ABC', 'Toyota', 'Avanza', 'Manual', 7, '2018', '1234567890123456', 3),
('B 5678 DEF', 'Honda', 'Jazz', 'Automatic', 5, '2019', '2345678901234567', 2),
('B 9101 GHI', 'Suzuki', 'Ertiga', 'Manual', 7, '2020', '3456789012345678', 1);

INSERT INTO Bookings (ktp_pelanggan, no_pol, tanggal, keluhan, antrean, status)
VALUES 
('1234567890123456', 'B 1234 ABC', '2023-10-01', 'Mesin berbunyi aneh', 1, 'Pending'),
('2345678901234567', 'B 5678 DEF', '2023-10-02', 'Rem kurang pakem', 2, 'On Progress'),
('3456789012345678', 'B 9101 GHI', '2023-10-03', 'AC tidak dingin', 3, 'Completed');

INSERT INTO Riwayat (ktp_pelanggan, no_pol, tanggal, ktp_admin, keluhan, catatan, total_harga, status)
VALUES 
('1234567890123456', 'B 1234 ABC', '2023-10-01', '9876543210987654', 'Mesin berbunyi aneh', 'Ganti oli dan tune-up', 500000, 'Completed'),
('2345678901234567', 'B 5678 DEF', '2023-10-02', '8765432109876543', 'Rem kurang pakem', 'Ganti kampas rem', 300000, 'Completed'),
('3456789012345678', 'B 9101 GHI', '2023-10-03', '9876543210987654', 'AC tidak dingin', 'Isi freon dan bersihkan filter', 400000, 'Completed');

INSERT INTO Sparepart (kode_sparepart, nama_sparepart, jumlah, harga, image_name, image_data)
VALUES 
('SP001', 'Oli Mesin', 50, 100000, 'oli_mesin.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\velg.jpeg', SINGLE_BLOB) AS img)),
('SP002', 'Kampas Rem', 30, 150000, 'kampas_rem.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\IRC SCT-004.jpg', SINGLE_BLOB) AS img)),
('SP003', 'Freon AC', 20, 200000, 'freon_ac.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\IRC NR72.jpg', SINGLE_BLOB) AS img));

INSERT INTO BookingsSparepart (id_booking, kode_sparepart)
VALUES 
(1, 'SP002'),
(2, 'SP001'),
(2, 'SP002'),
(3, 'SP001'),
(3, 'SP002'),
(3, 'SP003');

INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart)
VALUES 
(1, 'SP002'),
(2, 'SP001'),
(2, 'SP002'),
(3, 'SP001'),
(3, 'SP002'),
(3, 'SP003'); 

INSERT INTO JasaServis(nama_jasaServis,harga)
VALUES
('Ringan',20000),
('Sedang',35000),
('Berat',50000),
('Ganti Oli',10000);



CREATE TABLE change_history (
    history_id INT PRIMARY KEY IDENTITY(1,1),
    table_name NVARCHAR(100) NOT NULL,
    record_id INT NOT NULL, 
    action_type NVARCHAR(50) NOT NULL,
    old_data NVARCHAR(MAX), -- Data sebelum perubahan (dalam format JSON)
    new_data NVARCHAR(MAX), -- Data setelah perubahan (dalam format JSON)
    changed_by NVARCHAR(100), -- User yang melakukan perubahan
    changed_at DATETIME DEFAULT GETDATE() -- Waktu perubahan
);


-- Insert data ke tabel Admins
INSERT INTO Admins (
    ktp_admin, 
    nama_admin, 
    email, 
    password, 
    alamat, 
    no_telp, 
    role, 
    image_name, 
    image_data
)
SELECT 
    '1234567890123456', -- ktp_admin (contoh: 16 digit)
    'John Doe', -- nama_admin
    'john.doe@example.com', -- email
    'password123', -- password
    'Jl. Contoh No. 123', -- alamat
    '081234567890', -- no_telp
    1, -- role (contoh: 1 untuk admin)
    'FotoSaya.jpg', -- image_name (nama file gambar)
    BulkColumn -- image_data (data biner dari file gambar)
FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\FotoSaya.jpg', SINGLE_BLOB) AS ImageFile;


DROP TABLE Kendaraan;

ALTER TABLE Riwayat ADD CONSTRAINT Fk_Riwayat_Admins FOREIGN KEY (no_pol)
		REFERENCES Kendaraan(no_pol);



		
