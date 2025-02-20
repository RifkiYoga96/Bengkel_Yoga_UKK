-- STORE PROCEDURE INSERT--

CREATE PROCEDURE InsertSparepart
    @kode_sparepart VARCHAR(20),
    @nama_sparepart VARCHAR(50),
    @stok INT,
    @stok_minimum INT,
    @harga INT,
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Sparepart (kode_sparepart, nama_sparepart, stok, stok_minimum, harga, image_data)
    VALUES (@kode_sparepart, @nama_sparepart, @stok, @stok_minimum, @harga, @image_data);
END;

go;

CREATE PROCEDURE InsertPelanggan
    @ktp_pelanggan VARCHAR(30),
    @nama_pelanggan VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20)
AS
BEGIN
    INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @email, @password, @alamat, @no_telp);
END;


go;

CREATE PROCEDURE InsertAdmin
    @ktp_admin VARCHAR(30),
    @nama_admin VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20),
    @role INT,
    @image_name NVARCHAR(100),
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_name, image_data)
    VALUES (@ktp_admin, @nama_admin, @email, @password, @alamat, @no_telp, @role, @image_name, @image_data);
END;

go;

CREATE PROCEDURE InsertJasaServis
    @nama_jasaServis VARCHAR(100),
    @harga INT
AS
BEGIN
    INSERT INTO JasaServis (nama_jasaServis, harga)
    VALUES (@nama_jasaServis, @harga);
END;

go;

CREATE PROCEDURE InsertKendaraan
    @no_pol VARCHAR(30),
    @merk VARCHAR(20),
    @tipe VARCHAR(20),
    @transmisi VARCHAR(20),
    @kapasitas INT,
    @tahun VARCHAR(5),
    @ktp_pelanggan VARCHAR(30),
    @total_servis INT
AS
BEGIN
    INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis)
    VALUES (@no_pol, @merk, @tipe, @transmisi, @kapasitas, @tahun, @ktp_pelanggan, @total_servis);
END;

go;

CREATE PROCEDURE InsertBooking
    @ktp_pelanggan VARCHAR(30) = NULL,
    @nama_pelanggan VARCHAR(100) = NULL,
    @id_kendaraan INT = NULL,
    @no_pol VARCHAR(30) = NULL,
    @nama_kendaraan VARCHAR(100) = NULL,
    @tanggal DATE = NULL,
    @keluhan VARCHAR(100) = NULL,
    @catatan VARCHAR(100) = NULL,
    @antrean INT = NULL,
    @ktp_mekanik VARCHAR(30) = NULL,
    @id_jasaServis INT = NULL,
    @estimasi INT = NULL,
    @status VARCHAR(20) = 'pending'
AS
BEGIN
    INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, 
                          catatan, antrean, ktp_mekanik, id_jasaServis, estimasi, status)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @id_kendaraan, @no_pol, @nama_kendaraan, @tanggal, @keluhan, 
            @catatan, @antrean, @ktp_mekanik, @id_jasaServis, @estimasi, @status);
END;

go;

CREATE PROCEDURE InsertBookingsSparepart
    @id_booking INT,
    @kode_sparepart VARCHAR(20),
    @jumlah INT,
    @harga INT,
    @image_name NVARCHAR(100),
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO BookingsSparepart (id_booking, kode_sparepart, jumlah, harga, image_name, image_data)
    VALUES (@id_booking, @kode_sparepart, @jumlah, @harga, @image_name, @image_data);
END;

go;

CREATE PROCEDURE InsertRiwayat
    @ktp_pelanggan VARCHAR(30),
    @nama_pelanggan VARCHAR(100),
    @id_kendaraan INT,
    @no_pol VARCHAR(30),
    @nama_kendaraan VARCHAR(100),
    @tanggal DATE,
    @ktp_admin VARCHAR(30),
    @ktp_mekanik VARCHAR(30),
    @keluhan VARCHAR(100),
    @catatan VARCHAR(100),
    @total_harga INT,
    @id_jasaServis INT,
    @status VARCHAR(20)
AS
BEGIN
    INSERT INTO Riwayat (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, ktp_admin, ktp_mekanik, 
                         keluhan, catatan, total_harga, id_jasaServis, status)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @id_kendaraan, @no_pol, @nama_kendaraan, @tanggal, @ktp_admin, @ktp_mekanik, 
            @keluhan, @catatan, @total_harga, @id_jasaServis, @status);
END;


go;

CREATE PROCEDURE InsertRiwayatSparepart
    @id_riwayat INT,
    @kode_sparepart VARCHAR(20),
    @nama_sparepart VARCHAR(50),
    @jumlah INT,
    @harga INT,
    @image_name NVARCHAR(100),
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, nama_sparepart, jumlah, harga, image_name, image_data)
    VALUES (@id_riwayat, @kode_sparepart, @nama_sparepart, @jumlah, @harga, @image_name, @image_data);
END;

go;


-- STORE PROCEDURE UPDATE --

CREATE PROCEDURE UpdateSparepart
    @kode_sparepart VARCHAR(20),
    @nama_sparepart VARCHAR(50),
    @stok INT,
    @stok_minimum INT,
    @harga INT,
    @image_data VARBINARY(MAX)
AS
BEGIN
    UPDATE Sparepart 
    SET nama_sparepart = @nama_sparepart,
        stok = @stok,
        stok_minimum = @stok_minimum,
        harga = @harga,
        image_data = @image_data
    WHERE kode_sparepart = @kode_sparepart;
END;

go;

CREATE PROCEDURE UpdatePelanggan
    @ktp_pelanggan VARCHAR(30),
    @nama_pelanggan VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20)
AS
BEGIN
    UPDATE Pelanggan
    SET nama_pelanggan = @nama_pelanggan,
        email = @email,
        password = @password,
        alamat = @alamat,
        no_telp = @no_telp
    WHERE ktp_pelanggan = @ktp_pelanggan;
END;

go;

CREATE PROCEDURE UpdateAdmin
    @ktp_admin VARCHAR(30),
    @nama_admin VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20),
    @role INT,
    @image_name NVARCHAR(100),
    @image_data VARBINARY(MAX)
AS
BEGIN
    UPDATE Admins
    SET nama_admin = @nama_admin,
        email = @email,
        password = @password,
        alamat = @alamat,
        no_telp = @no_telp,
        role = @role,
        image_name = @image_name,
        image_data = @image_data
    WHERE ktp_admin = @ktp_admin;
END;

go;

CREATE PROCEDURE UpdateJasaServis
    @id_jasaServis INT,
    @nama_jasaServis VARCHAR(100),
    @harga INT
AS
BEGIN
    UPDATE JasaServis
    SET nama_jasaServis = @nama_jasaServis,
        harga = @harga
    WHERE id_jasaServis = @id_jasaServis;
END;

go;

CREATE PROCEDURE UpdateKendaraan
    @id_kendaraan INT,
    @no_pol VARCHAR(30),
    @merk VARCHAR(20),
    @tipe VARCHAR(20),
    @transmisi VARCHAR(20),
    @kapasitas INT,
    @tahun VARCHAR(5),
    @ktp_pelanggan VARCHAR(30),
    @total_servis INT
AS
BEGIN
    UPDATE Kendaraan
    SET no_pol = @no_pol,
        merk = @merk,
        tipe = @tipe,
        transmisi = @transmisi,
        kapasitas = @kapasitas,
        tahun = @tahun,
        ktp_pelanggan = @ktp_pelanggan,
        total_servis = @total_servis
    WHERE id_kendaraan = @id_kendaraan;
END;

go;

CREATE PROCEDURE UpdateBooking
    @id_booking INT,
    @ktp_pelanggan VARCHAR(30),
    @nama_pelanggan VARCHAR(100),
    @id_kendaraan INT,
    @no_pol VARCHAR(30),
    @nama_kendaraan VARCHAR(100),
    @tanggal DATE,
    @keluhan VARCHAR(100),
    @catatan VARCHAR(100),
    @antrean INT,
    @ktp_mekanik VARCHAR(30),
    @id_jasaServis INT,
    @estimasi INT,
    @status VARCHAR(20)
AS
BEGIN
    UPDATE Bookings
    SET ktp_pelanggan = @ktp_pelanggan,
        nama_pelanggan = @nama_pelanggan,
        id_kendaraan = @id_kendaraan,
        no_pol = @no_pol,
        nama_kendaraan = @nama_kendaraan,
        tanggal = @tanggal,
        keluhan = @keluhan,
        catatan = @catatan,
        antrean = @antrean,
        ktp_mekanik = @ktp_mekanik,
        id_jasaServis = @id_jasaServis,
        estimasi = @estimasi,
        status = @status
    WHERE id_booking = @id_booking;
END;

go;

CREATE PROCEDURE UpdateBookingsSparepart
    @id_booking INT,
    @kode_sparepart VARCHAR(20),
    @jumlah INT,
    @harga INT,
    @image_name NVARCHAR(100),
    @image_data VARBINARY(MAX)
AS
BEGIN
    UPDATE BookingsSparepart
    SET jumlah = @jumlah,
        harga = @harga,
        image_name = @image_name,
        image_data = @image_data
    WHERE id_booking = @id_booking AND kode_sparepart = @kode_sparepart;
END;

go;


-- FUNCTION GetStock--

CREATE FUNCTION GetAntrean(@tanggal DATE)
RETURNS TABLE
AS
RETURN
(
   SELECT 
    ISNULL((SELECT MAX(antrean) FROM Bookings WHERE tanggal = @tanggal), 0) + 1 AS Antrean,
    ISNULL((SELECT MAX(antrean) FROM Bookings WHERE tanggal = @tanggal AND status = 'dikerjakan'), 0) AS ServisNow
);