CREATE TABLE Pelanggan(
	ktp_pelanggan VARCHAR(30) NOT NULL PRIMARY KEY,
	nama_pelanggan VARCHAR(100),
	email VARCHAR(50),
	password VARCHAR(50),
	alamat VARCHAR(100),
	no_telp VARCHAR(20),
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)
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

CREATE TABLE Kendaraan(
	no_pol VARCHAR(30) NOT NULL PRIMARY KEY,
	merk VARCHAR(20),
	tipe VARCHAR(20),
	transmisi VARCHAR(20),
	kapasitas INT,
	tahun VARCHAR(5),
	ktp_pelanggan VARCHAR(30),
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
	antrean INT,
	status VARCHAR(20),
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE CASCADE
		ON UPDATE CASCADE
	);

CREATE TABLE Riwayat(
	id_riwayat INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ktp_pelanggan VARCHAR(30),
	no_pol VARCHAR(30),
	tanggal DATE,
	keluhan VARCHAR(100),
	ktp_admin VARCHAR(30),
						
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


CREATE TABLE Sparepart(
	kode_sparepart VARCHAR(20) NOT NULL PRIMARY KEY,
	nama_sparepart VARCHAR(50),
	jumlah INT,
	harga INT,
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)
	);

CREATE TABLE RiwayatSparepart(
	id_riwayat INT,
	kode_sparepart VARCHAR(20),
	jumlah INT,
	FOREIGN KEY (id_riwayat)
		REFERENCES Riwayat(id_riwayat)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (kode_sparepart)
		REFERENCES Sparepart(kode_sparepart)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );





CREATE TABLE History(
	id_history INT PRIMARY KEY IDENTITY(1,1),
	nama_tabel VARCHAR(20) NOT NULL,
	id_record INT NOT NULL,
	tipe_aksi VARCHAR(10),
	json_data NVARCHAR(MAX),
	diubah_oleh VARCHAR(100),
					);


INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp, image_name, image_data)
VALUES 
(
    '087719631265', 
    'Rifki Yoga Syahbani', 
    'yoga@gmail.com', 
    'Yoga12345@gmail.com', 
    'Jl. Merdeka No. 1', 
    '08123456789', 
    'john.jpg', 
    (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\FotoSaya.jpg', SINGLE_BLOB) AS img)
);

INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp, image_name, image_data)
VALUES 
('1234567890', 'John Doe', 'john@example.com', 'password123', 'Jl. Merdeka No. 1', '08123456789', 'john.jpg', NULL),
('0987654321', 'Jane Doe', 'jane@example.com', 'password456', 'Jl. Sudirman No. 2', '08234567890', 'jane.jpg', NULL);

INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_name, image_data)
VALUES 
('1111111111', 'Admin One', 'admin1@example.com', 'adminpass1', 'Jl. Admin No. 1', '0811111111', 1, 'admin1.jpg', NULL),
('2222222222', 'Admin Two', 'admin2@example.com', 'adminpass2', 'Jl. Admin No. 2', '0822222222', 2, 'admin2.jpg', NULL);

INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan)
VALUES 
('B 1234 ABC', 'Toyota', 'Avanza', 'Manual', 7, '2018', '1234567890'),
('B 5678 DEF', 'Honda', 'Jazz', 'Automatic', 5, '2020', '0987654321');

INSERT INTO Bookings (ktp_pelanggan, no_pol, tanggal, keluhan, antrean, status)
VALUES 
('1234567890', 'B 1234 ABC', '2023-10-25', 'Mesin berbunyi aneh', 1, 'Pending'),
('0987654321', 'B 5678 DEF', '2023-10-26', 'Rem kurang pakem', 2, 'On Progress');

INSERT INTO Riwayat (ktp_pelanggan, no_pol, tanggal, keluhan, ktp_admin)
VALUES 
('1234567890', 'B 1234 ABC', '2023-10-25', 'Mesin berbunyi aneh', '1111111111'),
('0987654321', 'B 5678 DEF', '2023-10-26', 'Rem kurang pakem', '2222222222');


INSERT INTO Sparepart (kode_sparepart, nama_sparepart, jumlah, harga, image_name, image_data)
VALUES 
('SP001', 'Kampas Rem', 50, 150000, 'kampas_rem.jpg', NULL),
('SP002', 'Oli Mesin', 100, 75000, 'oli_mesin.jpg', NULL);

INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, jumlah)
VALUES 
(1, 'SP001', 2), -- Riwayat ID 1 menggunakan 2 kampas rem
(2, 'SP002', 1); -- Riwayat ID 2 menggunakan 1 oli mesin








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



		
