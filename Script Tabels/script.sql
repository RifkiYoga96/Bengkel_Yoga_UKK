﻿CREATE TABLE Sparepart(
	kode_sparepart VARCHAR(20) NOT NULL PRIMARY KEY,
	nama_sparepart VARCHAR(50),
	stok INT,
	stok_minimum INT,
	harga INT,
	image_data VARBINARY(MAX),

	created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    deleted_at DATETIME NULL
	);

CREATE TABLE Pelanggan(
	ktp_pelanggan VARCHAR(30) NOT NULL PRIMARY KEY,
	nama_pelanggan VARCHAR(100),
	email VARCHAR(50),
	password VARCHAR(50),
	alamat VARCHAR(100),
	no_telp VARCHAR(20),

	created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    deleted_at DATETIME NULL
	);

CREATE TABLE Admins(
	ktp_admin VARCHAR(30) NOT NULL PRIMARY KEY,
	nama_admin VARCHAR(100),
	email VARCHAR(50),
	password VARCHAR(50),
	alamat VARCHAR(100),
	no_telp VARCHAR(20),
	role INT,
	image_data VARBINARY(MAX),

	created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    deleted_at DATETIME NULL
);

CREATE TABLE JasaServis(
	id_jasaServis INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	nama_jasaServis VARCHAR(100),
	harga INT,

	created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    deleted_at DATETIME NULL
	);


CREATE TABLE Kendaraan(
	id_kendaraan INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	no_pol VARCHAR(30),
	merk VARCHAR(20),
	tipe VARCHAR(20),
	transmisi VARCHAR(20),
	kapasitas INT,
	tahun VARCHAR(5),
	ktp_pelanggan VARCHAR(30),
	total_servis INT,
	created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    deleted_at DATETIME NULL,
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE CASCADE
		ON UPDATE CASCADE
	);


CREATE TABLE Bookings(
	id_booking INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ktp_pelanggan VARCHAR(30),
	nama_pelanggan VARCHAR(100),
	id_kendaraan INT,
	no_pol VARCHAR(30),
	nama_kendaraan VARCHAR(100),
	tanggal DATE,
	keluhan VARCHAR(100),

	catatan VARCHAR(100),
	antrean INT,
	ktp_mekanik VARCHAR(30),
	id_jasaServis INT,
	status VARCHAR(20)
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	FOREIGN KEY (ktp_mekanik)
		REFERENCES Admins(ktp_admin)
		ON DELETE SET NULL
		ON UPDATE CASCADE
	);


CREATE TABLE BookingsSparepart(
	id_booking INT,
	kode_sparepart VARCHAR(20),
	jumlah INT,
	harga INT,
	image_data VARBINARY(MAX)

	FOREIGN KEY (id_booking)
		REFERENCES Bookings(id_booking)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );

CREATE TABLE Riwayat(
    id_riwayat INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ktp_pelanggan VARCHAR(30),
    nama_pelanggan VARCHAR(100),
    id_kendaraan INT,
    no_pol VARCHAR(30),
    nama_kendaraan VARCHAR(100),
    tanggal DATE,
    ktp_admin VARCHAR(30),
    ktp_mekanik VARCHAR(30),
    keluhan VARCHAR(100),
    catatan VARCHAR(100),
    total_harga INT,
    id_jasaServis INT,
    status VARCHAR(20),
	created_at DATETIME DEFAULT GETDATE(),
                        
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan),
	FOREIGN KEY (id_kendaraan)
		REFERENCES Kendaraan(id_kendaraan)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	FOREIGN KEY (ktp_admin)
		REFERENCES Admins(ktp_admin)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);



CREATE TABLE RiwayatSparepart(
	id_riwayat INT,
	kode_sparepart VARCHAR(20),
	nama_sparepart VARCHAR(50),
	jumlah INT,
	harga INT,
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)

	FOREIGN KEY (id_riwayat)
		REFERENCES Riwayat(id_riwayat)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );



CREATE TABLE History(
	id_history INT PRIMARY KEY IDENTITY(1,1),
	nama_tabel VARCHAR(20) NOT NULL,
	id_record VARCHAR(100) NOT NULL,
	tipe_aksi VARCHAR(10),
	json_data NVARCHAR(MAX),
						);	

						go;

CREATE TRIGGER trg_UpdateKtpMekanik 
ON Admins 
AFTER UPDATE 
AS 
BEGIN
    SET NOCOUNT ON;

    UPDATE r
    SET r.ktp_mekanik = i.ktp_admin
    FROM Riwayat r
    LEFT JOIN DELETED d ON r.ktp_mekanik = d.ktp_admin
    INNER JOIN INSERTED i ON d.ktp_admin = i.ktp_admin
    WHERE i.role = 0;
END;


go;


INSERT INTO Sparepart (kode_sparepart, nama_sparepart, stok, stok_minimum, harga, image_data)
VALUES
('SP001', 'Oli Mesin', 50, 5, 75000, NULL),
('SP002', 'Busi', 30, 5, 25000, NULL),
('SP003', 'Kampas Rem', 40, 5, 100000, NULL);

INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp)
VALUES
('123456789', 'Ahmad Setiawan', 'ahmad@email.com', 'pass123', 'Jl. Merdeka No.10', '081234567890'),
('987654321', 'Rina Susanti', 'rina@email.com', 'pass456', 'Jl. Diponegoro No.15', '081298765432');

INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_data)
VALUES
('111111111', 'Budi Santoso', 'budi@email.com', 'admin123', 'Jl. Sudirman No.20', '081212341234', 1, NULL),
('222222222', 'Siti Aisyah', 'siti@email.com', 'admin456', 'Jl. Thamrin No.30', '081278956789', 2, NULL);

INSERT INTO JasaServis (nama_jasaServis, harga)
VALUES
('Ganti Oli', 50000),
('Tune Up', 150000),
('Ganti Kampas Rem', 120000);

INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis)
VALUES
('B 1234 AB', 'Toyota', 'Avanza', 'Automatic', 7, '2020', '123456789', 3),
('D 5678 CD', 'Honda', 'Brio', 'Manual', 5, '2018', '987654321', 2);

INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, catatan, antrean, ktp_mekanik, id_jasaServis, status)
VALUES
('123456789', 'Ahmad Setiawan', 1, 'B 1234 AB', 'Toyota Avanza', '2024-06-01', 'Oli Bocor', 'Perlu ganti oli', 1, '111111111', 1, 'Menunggu'),
('987654321', 'Rina Susanti', 2, 'D 5678 CD', 'Honda Brio', '2024-06-02', 'Mesin Berisik', 'Perlu cek mesin', 2, '222222222', 2, 'Diproses');

INSERT INTO BookingsSparepart (id_booking, kode_sparepart, jumlah, harga, image_data)
VALUES
(1, 'SP001', 1, 75000, NULL),
(2, 'SP002', 2, 25000, NULL);

INSERT INTO Riwayat (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, ktp_admin, ktp_mekanik, keluhan, catatan, total_harga, id_jasaServis, status)
VALUES
('123456789', 'Ahmad Setiawan', 1, 'B 1234 AB', 'Toyota Avanza', '2024-06-01', '111111111', '111111111', 'Oli Bocor', 'Ganti oli selesai', 75000, 1, 'Selesai'),
('987654321', 'Rina Susanti', 2, 'D 5678 CD', 'Honda Brio', '2024-06-02', '222222222', '222222222', 'Mesin Berisik', 'Tune up selesai', 150000, 2, 'Selesai');

INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, nama_sparepart, jumlah, harga, image_name, image_data)
VALUES
(1, 'SP001', 'Oli Mesin', 1, 75000, 'oli_mobil.jpg', NULL),
(2, 'SP002', 'Busi', 2, 25000, 'busi.jpg', NULL);









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
('1234567890123456', 'John Cena', 'john.cena@example.com', 'password123', 'Jl. Merdeka No. 123', '081234567890'),
('2345678901234567', 'Jane Doe', 'jane.doe@example.com', 'password456', 'Jl. Sudirman No. 456', '081234567891'),
('3456789012345678', 'Michael Smith', 'michael.smith@example.com', 'password789', 'Jl. Thamrin No. 789', '081234567892'),
('3456789617671731', 'Andi Saputra', 'andi.saputra@example.com', 'password999', 'Jl. Asia Afrika No. 101', '081234567899');



INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_name, image_data)
VALUES 
('9876543210987654', 'Admin One', 'admin.one@example.com', 'admin123', 'Jl. Admin No. 1', '081234567893', 1, 'admin1.jpg', NULL),
('8765432109876543', 'Admin Two', 'admin.two@example.com', 'admin456', 'Jl. Admin No. 2', '081234567894', 2, 'admin2.jpg', NULL),
('8765432103322422', 'Mekanik One', NULL, NULL, 'Jl. Admin No. 2', '081234567894', 0, 'admin2.jpg', NULL);

INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis)
VALUES 
('B 1234 ABC', 'Toyota', 'Avanza', 'Manual', 7, '2018', '1234567890123456', 3),
('B 5678 DEF', 'Honda', 'Jazz', 'Automatic', 5, '2019', '2345678901234567', 2),
('B 9101 GHI', 'Suzuki', 'Ertiga', 'Manual', 7, '2020', '3456789012345678', 1);

DELETE FROM Bookings;
INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, antrean, status, ktp_mekanik,id_jasaServis)
VALUES 
('1234567890123456', NULL,1, NULL, NULL, '2023-10-01', 'Mesin berbunyi aneh', 1, 'dikerjakan','8765432103322422',1),
('2345678901234567', NULL,2, NULL, NULL, '2023-10-02', 'Rem kurang pakem', 2, 'pending','8765432103322422',2),
('3456789012345678', NULL,3, NULL, NULL, '2023-10-03', 'AC tidak dingin', 3, 'pending','8765432103322422',3),
(NULL, 'Rifki Yoga Syahbani',NULL, 'AB 1617 FA', 'Vario Led 150cc (2017)', '2023-10-03', 'AC tidak dingin', 4, 'pending','8765432103322422',2);

DELETE FROM Riwayat;
INSERT INTO Riwayat (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, catatan, total_harga, status,ktp_admin, ktp_mekanik, id_jasaServis)
VALUES 
('1234567890123456',NULL,1, NULL, NULL, '2026-10-01', 'Mesin berbunyi aneh', 'Ganti oli dan tune-up', 500000, 'selesai','4444','3333',2);


INSERT INTO Sparepart (kode_sparepart, nama_sparepart, stok, stok_minimum, harga, image_name, image_data)
VALUES 
('SP001', 'Oli Mesin', 50, 20, 100000, 'oli_mesin.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\velg.jpeg', SINGLE_BLOB) AS img)),
('SP002', 'Kampas Rem', 30, 10, 150000, 'kampas_rem.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\IRC SCT-004.jpg', SINGLE_BLOB) AS img)),
('SP003', 'Freon AC', 20, 20, 200000, 'freon_ac.jpg', (SELECT BulkColumn 
     FROM OPENROWSET(BULK 'D:\APenyimpanan\BENGKEL - UKK\IRC NR72.jpg', SINGLE_BLOB) AS img));

INSERT INTO BookingsSparepart (id_booking, kode_sparepart, jumlah, harga, image_name, image_data)
VALUES 
(1, 'SP002', 1, 150000, 'kampas_rem.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP002')),
(2, 'SP001', 1, 100000, 'oli_mesin.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP001')),
(2, 'SP002',  1, 150000, 'kampas_rem.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP002')),
(3, 'SP001',  1, 100000, 'oli_mesin.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP001')),
(3, 'SP002',  1, 150000, 'kampas_rem.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP002')),
(3, 'SP003', 1, 200000, 'freon_ac.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP003'));


INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, nama_sparepart, jumlah, harga, image_name, image_data)
VALUES 
(1, 'SP001', 'Oli Mesin', 50, 100000, 'oli_mesin.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP001')),
(2, 'SP002', 'Kampas Rem', 30, 150000, 'kampas_rem.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP002')),
(3, 'SP003', 'Freon AC', 20, 200000, 'freon_ac.jpg', (SELECT image_data FROM Sparepart WHERE kode_sparepart = 'SP003'));


INSERT INTO JasaServis(nama_jasaServis,harga)
VALUES
('Ringan',20000),
('Sedang',35000),
('Berat',50000),
('Ganti Oli',10000);



INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, antrean, status, ktp_mekanik, id_jasaServis)
SELECT ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, DATEADD(DAY, t.n, tanggal), keluhan, antrean + t.n, status, ktp_mekanik, id_jasaServis
FROM (
    VALUES 
    ('1234567890123456', NULL,1, NULL, NULL, '2023-10-01', 'Mesin berbunyi aneh', 1, 'dikerjakan','8765432103322422',1),
    ('2345678901234567', NULL,2, NULL, NULL, '2023-10-02', 'Rem kurang pakem', 2, 'pending','8765432103322422',2),
    ('3456789012345678', NULL,3, NULL, NULL, '2023-10-03', 'AC tidak dingin', 3, 'pending','8765432103322422',3),
    (NULL, 'Rifki Yoga Syahbani',NULL, 'AB 1617 FA', 'Vario Led 150cc (2017)', '2023-10-03', 'AC tidak dingin', 4, 'pending','8765432103322422',2)
) AS base(ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, antrean, status, ktp_mekanik, id_jasaServis)
CROSS JOIN (SELECT TOP 25 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n FROM master.dbo.spt_values) AS t;





		
