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
	no_ktp_admin VARCHAR(30),
						
	FOREIGN KEY (ktp_pelanggan)
		REFERENCES Pelanggan(ktp_pelanggan)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (no_pol)
		REFERENCES Kendaraan(no_pol)
		ON DELETE CASCADE
		ON UPDATE CASCADE
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

CREATE TABLE Kendaraan(
	no_pol VARCHAR NOT NULL IDENTITY(1,1) PRIMARY KEY,
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

CREATE TABLE Sparepart(
	kode_sparepart VARCHAR(20) NOT NULL PRIMARY KEY,
	nama_sparepart VARCHAR(50),
	jumlah INT,
	harga INT,
	image_name NVARCHAR(100),
	image_data VARBINARY(MAX)
	);

CREATE TABLE History(
	id_history INT PRIMARY KEY IDENTITY(1,1),
	nama_tabel VARCHAR(20) NOT NULL,
	id_record INT NOT NULL,
	tipe_aksi VARCHAR(10),
	json_data NVARCHAR(MAX),
	diubah_oleh VARCHAR(100),
					);



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
