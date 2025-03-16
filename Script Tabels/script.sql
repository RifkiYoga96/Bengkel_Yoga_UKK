DELETE FROM BookingsSparepart;


CREATE TABLE Sparepart(
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
	password VARCHAR(255),
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
	password VARCHAR(255),
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
	tanggal_servis DATE,
	keluhan VARCHAR(100),

	catatan VARCHAR(100),
	antrean INT,
	tipe_antrean INT,
	ktp_mekanik VARCHAR(30),
	id_jasaServis INT,
	status VARCHAR(20),

	deleted_at DATETIME NULL,
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	FOREIGN KEY (ktp_mekanik)
		REFERENCES Admins(ktp_admin)
		ON DELETE SET NULL
		ON UPDATE CASCADE
	);

	DROP TABLE BookingsSparepart;
CREATE TABLE BookingsSparepart(
	id_booking INT,
	kode_sparepart VARCHAR(20),
	nama_sparepart VARCHAR(50),
	jumlah INT,
	harga INT,
	image_data VARBINARY(MAX) NULL

	FOREIGN KEY (id_booking)
		REFERENCES Bookings(id_booking)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );

DROP TABLE Riwayat;
CREATE TABLE Riwayat(
    id_riwayat INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ktp_pelanggan VARCHAR(30),
    nama_pelanggan VARCHAR(100),
    id_kendaraan INT,
    no_pol VARCHAR(30),
    nama_kendaraan VARCHAR(100),
    tanggal DATE,
	tanggal_servis DATETIME,
	tanggal_selesai DATETIME,
    ktp_admin VARCHAR(30),
    ktp_mekanik VARCHAR(30),
    keluhan VARCHAR(100),
    catatan VARCHAR(100),
    total_harga INT,
    id_jasaServis INT,
    status VARCHAR(20),
	pembatalan_oleh VARCHAR(30),
	created_at DATETIME DEFAULT GETDATE(),
                        
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	FOREIGN KEY (id_kendaraan)
		REFERENCES Kendaraan(id_kendaraan),
	FOREIGN KEY (ktp_admin)
		REFERENCES Admins(ktp_admin)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);


Drop TABLE RiwayatSparepart;
CREATE TABLE RiwayatSparepart(
	id_riwayat INT,
	kode_sparepart VARCHAR(20),
	nama_sparepart VARCHAR(50),
	jumlah INT,
	harga INT,
	image_data VARBINARY(MAX)

	FOREIGN KEY (id_riwayat)
		REFERENCES Riwayat(id_riwayat)
		ON DELETE CASCADE
		ON UPDATE CASCADE
        );

CREATE TABLE BatasBooking(
    id_batas_booking INT IDENTITY(1,1) PRIMARY KEY,
    tanggal DATETIME,
    batas_booking INT,
    created_at DATETIME DEFAULT GETDATE()
);

DROP TABLE JadwalLibur;
CREATE TABLE JadwalLibur(
	id_jadwal_libur INT PRIMARY KEY IDENTITY (1,1),
	tanggal DATETIME,
	hari VARCHAR(50)
);

CREATE TABLE JadwalOperasional(
	id_jadwal_operasional INT PRIMARY KEY IDENTITY (1,1),
	hari VARCHAR(50),
	jam_buka TIME,
	jam_tutup TIME
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


DROP TABLE Bookings;
DROP TABLE BookingsSparepart;


-- Insert ke Pelanggan
INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp)
VALUES 
('1234567890', 'Budi Santoso', 'budi@email.com', 'password123', 'Jl. Merdeka No.10', '081234567890');

-- Insert ke Admins
INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role)
VALUES 
('0987654321', 'Admin 1', 'admin@email.com', 'admin123', 'Jl. Sudirman No.20', '081298765432', 1);

-- Insert ke Sparepart
INSERT INTO Sparepart (kode_sparepart, nama_sparepart, stok, stok_minimum, harga)
VALUES 
--('SP001', 'Oli Mesin', 50, 5, 100000),
--('SP002', 'Busi', 100, 10, 50000),
('SP004', 'Ban', 0, 10, 40000);

-- Insert ke JasaServis
INSERT INTO JasaServis (nama_jasaServis, harga)
VALUES 
('Ganti Oli', 150000),
('Tune Up', 200000);

-- Insert ke Kendaraan
INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis)
VALUES 
('D 2111 WW', 'Cagiva', 'Stella 115', 'Manual', 5, '1999', '1234567890', 0),
('B 1234 ABC', 'Toyota', 'Avanza', 'Manual', 7, '2018', '1234567890', 2),
('D 5678 XYZ', 'Honda', 'Brio', 'Automatic', 5, '2020', '1234567890', 1);


DELETE FROM Bookings;
-- Insert ke Bookings
INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, catatan, antrean, ktp_mekanik, id_jasaServis, status, tipe_antrean)
VALUES 
(NULL, 'Budi Santoso', NULL, 'B 1234 ABC', 'Toyota Avanza', '2024-02-24', 'Oli bocor', 'Harus diganti', 1, '0987654321', 1, 'pending',1);

DELETE FROM BookingsSparepart;
-- Insert ke BookingsSparepart (ambil dari sparepart)
INSERT INTO BookingsSparepart (id_booking, kode_sparepart, nama_sparepart, jumlah, harga, image_data)
SELECT 
    1, kode_sparepart, nama_sparepart, 2, harga, image_data
FROM Sparepart
WHERE kode_sparepart = 'SP001';

-- Insert ke Riwayat (setelah booking selesai)
INSERT INTO Riwayat (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, ktp_admin, ktp_mekanik, keluhan, catatan, total_harga, id_jasaServis, status, tanggal_servis, tanggal_selesai, pembatalan_oleh)
VALUES 
('1234567890', 'Budi Santoso', 1, 'B 1234 ABC', 'Toyota Avanza', '2024-02-24', '0987654321', '0987654321', 'Oli bocor', 'Oli diganti', 250000, 1, 'batal servis', '2024-02-24 14:30:00', '2024-02-24 16:30:00', 'Petugas'
);

-- Insert ke RiwayatSparepart (ambil dari bookings sparepart)
INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, nama_sparepart, jumlah, harga, image_data)
SELECT 
    1, kode_sparepart, nama_sparepart, jumlah, harga, image_data
FROM BookingsSparepart
WHERE id_booking = 1;

INSERT INTO BatasBooking (tanggal, batas_booking)
VALUES 
(NULL, 10);

INSERT INTO jadwalLibur(tanggal,hari)
VALUES
(NULL,'Minggu'),('2025-02-28',NULL);

INSERT INTO JadwalOperasional(hari,jam_buka,jam_tutup)
VALUES
(NULL,'08:00:00', '16:00:00'),
('Sabtu','08:00:00', '17:00:00');





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



SELECT * FROM Pelanggan;



		
