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
    SET NOCOUNT ON;

    INSERT INTO Sparepart (kode_sparepart, nama_sparepart, stok, stok_minimum, harga, image_data, created_at, updated_at)
    VALUES (@kode_sparepart, @nama_sparepart, @stok, @stok_minimum, @harga, @image_data, GETDATE(), GETDATE());
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
    INSERT INTO Pelanggan (ktp_pelanggan, nama_pelanggan, email, password, alamat, no_telp, created_at, updated_at)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @email, @password, @alamat, @no_telp, GETDATE(), GETDATE());
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
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO Admins (ktp_admin, nama_admin, email, password, alamat, no_telp, role, image_data, created_at, updated_at)
    VALUES (@ktp_admin, @nama_admin, @email, @password, @alamat, @no_telp, @role, @image_data, GETDATE(), GETDATE());
END;


go;

CREATE PROCEDURE InsertJasaServis
    @nama_jasaServis VARCHAR(100),
    @harga INT
AS
BEGIN
    INSERT INTO JasaServis (nama_jasaServis, harga, created_at, updated_at)
    VALUES (@nama_jasaServis, @harga, GETDATE(), GETDATE());
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
    INSERT INTO Kendaraan (no_pol, merk, tipe, transmisi, kapasitas, tahun, ktp_pelanggan, total_servis, created_at, updated_at)
    VALUES (@no_pol, @merk, @tipe, @transmisi, @kapasitas, @tahun, @ktp_pelanggan, @total_servis, GETDATE(), GETDATE());
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
    @status VARCHAR(20) = 'pending',
    @tipe_antrean VARCHAR(20) = 1
AS
BEGIN
    INSERT INTO Bookings (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, keluhan, catatan, antrean, ktp_mekanik, id_jasaServis, status, tipe_antrean)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @id_kendaraan, @no_pol, @nama_kendaraan, @tanggal, @keluhan, @catatan, @antrean, @ktp_mekanik, @id_jasaServis, @status, @tipe_antrean);
END;


go;

CREATE PROCEDURE InsertBookingSparepart
    @id_booking INT,
    @kode_sparepart VARCHAR(20),
    @jumlah INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO BookingsSparepart (id_booking, kode_sparepart, nama_sparepart, jumlah, harga, image_data)
    SELECT 
        @id_booking,
        s.kode_sparepart,
        s.nama_sparepart,
        @jumlah,
        s.harga,
        s.image_data
    FROM Sparepart s
    WHERE s.kode_sparepart = @kode_sparepart;
END;


go;

CREATE PROCEDURE InsertRiwayat
    @ktp_pelanggan VARCHAR(30) = NULL,
    @nama_pelanggan VARCHAR(100) = NULL,
    @id_kendaraan INT = NULL,
    @no_pol VARCHAR(30) = NULL,
    @nama_kendaraan VARCHAR(100) = NULL,
    @tanggal DATE = NULL,
    @ktp_admin VARCHAR(30) = NULL,
    @ktp_mekanik VARCHAR(30) = NULL,
    @keluhan VARCHAR(100) = NULL,
    @catatan VARCHAR(100) = NULL,
    @total_harga INT = NULL,
    @id_jasaServis INT = NULL,
    @status VARCHAR(20) = NULL
AS
BEGIN
    INSERT INTO Riwayat (ktp_pelanggan, nama_pelanggan, id_kendaraan, no_pol, nama_kendaraan, tanggal, ktp_admin, ktp_mekanik, keluhan, catatan, total_harga, id_jasaServis, status, created_at)
    VALUES (@ktp_pelanggan, @nama_pelanggan, @id_kendaraan, @no_pol, @nama_kendaraan, @tanggal, @ktp_admin, @ktp_mekanik, @keluhan, @catatan, @total_harga, @id_jasaServis, @status, GETDATE());
END;



go;



CREATE PROCEDURE InsertRiwayatSparepart
    @id_riwayat INT,
    @kode_sparepart VARCHAR(20),
    @nama_sparepart VARCHAR(50),
    @jumlah INT,
    @harga INT,
    @image_data VARBINARY(MAX)
AS
BEGIN
    INSERT INTO RiwayatSparepart (id_riwayat, kode_sparepart, nama_sparepart, jumlah, harga, image_data)
    VALUES (@id_riwayat, @kode_sparepart, @nama_sparepart, @jumlah, @harga, @image_data);
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
        image_data = @image_data,
        updated_at = GETDATE()
    WHERE kode_sparepart = @kode_sparepart;
END;

go;

CREATE PROCEDURE UpdatePelanggan
    @ktp_pelanggan_old VARCHAR(30),  
    @ktp_pelanggan_new VARCHAR(30),  
    @nama_pelanggan VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE Pelanggan
        SET 
            ktp_pelanggan = @ktp_pelanggan_new,
            nama_pelanggan = @nama_pelanggan,
            email = @email,
            password = @password,
            alamat = @alamat,
            no_telp = @no_telp, 
            updated_at = GETDATE()
        WHERE ktp_pelanggan = @ktp_pelanggan_old;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;


go;

CREATE PROCEDURE UpdateAdmin
    @ktp_admin_old VARCHAR(30),  
    @ktp_admin_new VARCHAR(30),  
    @nama_admin VARCHAR(100),
    @email VARCHAR(50),
    @password VARCHAR(50),
    @alamat VARCHAR(100),
    @no_telp VARCHAR(20),
    @role INT,
    @image_data VARBINARY(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        UPDATE Admins
        SET 
            ktp_admin = @ktp_admin_new,
            nama_admin = @nama_admin,
            email = @email,
            password = @password,
            alamat = @alamat,
            no_telp = @no_telp, 
            role = @role,
            image_data = @image_data,
            updated_at = GETDATE()
        WHERE ktp_admin = @ktp_admin_old;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;

go;

CREATE PROCEDURE UpdateJasaServis
    @id_jasaServis INT,
    @nama_jasaServis VARCHAR(100),
    @harga INT
AS
BEGIN
    UPDATE JasaServis
    SET 
        nama_jasaServis = @nama_jasaServis,
        harga = @harga,
        updated_at = GETDATE()
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
    SET 
        no_pol = @no_pol,
        merk = @merk,
        tipe = @tipe,
        transmisi = @transmisi,
        kapasitas = @kapasitas,
        tahun = @tahun,
        ktp_pelanggan = @ktp_pelanggan,
        total_servis = @total_servis,
        updated_at = GETDATE()
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
    @keluhan VARCHAR(100) = NULL,
    @catatan VARCHAR(100) = NULL,
    @antrean INT = NULL,
    @ktp_mekanik VARCHAR(30) = NULL,
    @id_jasaServis INT = NULL,
    @status VARCHAR(20) = NULL
AS
BEGIN
    UPDATE Bookings
    SET 
        ktp_pelanggan = @ktp_pelanggan,
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
        status = @status
    WHERE id_booking = @id_booking;
END;


go;

CREATE PROCEDURE UpdateBookingsSparepart
    @id_booking INT,
    @kode_sparepart VARCHAR(20),
    @jumlah INT,
    @harga INT,
    @image_data VARBINARY(MAX)
AS
BEGIN
    UPDATE BookingsSparepart
    SET jumlah = @jumlah,
        harga = @harga,
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

go;

-- TRIGGER Kurangi Stok & Kembalikan Stok --
CREATE TRIGGER tr_UpdateStok_Sparepart
ON BookingsSparepart
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Sparepart
    SET stok = stok - i.jumlah
    FROM Sparepart s
    INNER JOIN inserted i ON s.kode_sparepart = i.kode_sparepart;
END;

go;

CREATE TRIGGER trg_KembalikanStok_Sparepart
ON RiwayatSparepart
AFTER INSERT
AS 
BEGIN
    SET NOCOUNT ON;

    UPDATE Sparepart
    SET stok = stok - i.jumlah
    FROM Sparepart s
    INNER JOIN inserted i ON s.kode_sparepart = i.kode_sparepart
    INNER JOIN Riwayat r ON s.id_riwayat = i.id_riwayat
    WHERE r.status = 'dibatalkan'
END;








GO;

		--TRIGGER Pelanggan--
CREATE TRIGGER trg_HistoryPelanggan
ON Pelanggan
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM INSERTED) AND NOT EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Pelanggan',
			i.ktp_pelanggan,
			'INSERT',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		--Old
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Pelanggan',
			d.ktp_pelanggan,
			'UPDATE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
		WHERE NOT EXISTS(SELECT 1 FROM History h WHERE h.nama_tabel = 'Pelanggan' AND h.id_record = d.ktp_pelanggan);

		--New
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Pelanggan',
			i.ktp_pelanggan,
			'UPDATE',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF NOT EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Pelanggan',
			d.ktp_pelanggan,
			'DELETE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
	END
END;


GO;
--TRIGGER Admins--
CREATE TRIGGER trg_HistoryAdmins
ON Admins
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM INSERTED) AND NOT EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Admins',
			i.ktp_admin,
			'INSERT',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		--Old
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Admins',
			d.ktp_admin,
			'UPDATE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
		WHERE NOT EXISTS(SELECT 1 FROM History h WHERE h.nama_tabel = 'Pelanggan' AND h.id_record = d.ktp_pelanggan);

		--New
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Admins',
			i.ktp_admin,
			'UPDATE',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF NOT EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Admins',
			d.ktp_admin,
			'DELETE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
	END
END;



GO;
--TRIGGER Admins--
CREATE TRIGGER trg_HistorySparepart
ON Sparepart
AFTER INSERT,UPDATE,DELETE
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM INSERTED) AND NOT EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Sparepart',
			i.kode_sparepart,
			'INSERT',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		--Old
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Sparepart',
			d.kode_sparepart,
			'UPDATE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
		WHERE NOT EXISTS(SELECT 1 FROM History h WHERE h.nama_tabel = 'Pelanggan' AND h.id_record = d.ktp_pelanggan);

		--New
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Sparepart',
			i.kode_sparepart,
			'UPDATE',
			(SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM INSERTED i
	END

	ELSE IF NOT EXISTS(SELECT 1 FROM INSERTED) AND EXISTS(SELECT 1 FROM DELETED)
	BEGIN
		INSERT INTO History(nama_tabel,id_record,tipe_aksi,json_data)
		SELECT
			'Sparepart',
			d.kode_sparepart,
			'DELETE',
			(SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
		FROM DELETED d
	END
END;

