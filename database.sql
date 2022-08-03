CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

CREATE TABLE TableFood 
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100)NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống' --Trống || Có người 

)
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (1, N'Bàn 0', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (2, N'Bàn 1', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (3, N'Bàn 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (4, N'Bàn 3', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (5, N'Bàn 4', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (6, N'Bàn 5', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (7, N'Bàn 6', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (8, N'Bàn 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (9, N'Bàn 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (10, N'Bàn 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (11, N'Bàn 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (12, N'Bàn 11', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (13, N'Bàn 12', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (14, N'Bàn 13', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (15, N'Bàn 14', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (16, N'Bàn 15', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (17, N'Bàn 16', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (18, N'Bàn 17', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (19, N'Bàn 18', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (20, N'Bàn 19', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (21, N'Bàn 20', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
CREATE TABLE Account 
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'HHTT' ,
	
	Password NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT DEFAULT 0 NOT NULL
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (1, N'CÀ PHÊ PHIN')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (2, N'CÀ PHÊ ESPRESSO')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (3, N'FREEZE')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (4, N'THỨC UỐNG KHÁC')
INSERT [dbo].[FoodCategory] ([id], [name]) VALUES (5, N'TRÀ')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO

CREATE TABLE Food 
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (1, N'PHIN sữa đá', 1, 29000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (2, N'PHIN đen đá', 1, 29000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (3, N'Bạc xỉu đá', 1, 29000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (4, N'Espresso', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (5, N'Americano', 2, 35000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (6, N'Cappuchino', 2, 55000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (7, N'Latte', 2, 55000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (8, N'Mocha', 2, 59000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (9, N'Caramel Macchiato', 2, 59000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (10, N'Freeze Trà Xanh', 3, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (11, N'Freeze Sô-cô-la', 3, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (12, N'cookies & Cream', 3, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (13, N'Caramel Phin Freeze', 3, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (14, N'Classic Cream Freeze', 3, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (15, N'Chanh Đá Xay', 4, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (16, N'Chanh Dây Đá Viên', 4, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (17, N'Tắc Đá Viên', 4, 49000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (18, N'Sô-Cô-La', 4, 59000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (19, N'Trà Sen Vàng', 5, 39000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (20, N'Trà Thạch Đào', 5, 39000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (21, N'Trà Thanh Đào', 5, 39000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (22, N'Trà Thạch vải', 5, 39000)
INSERT [dbo].[Food] ([id], [name], [idCategory], [price]) VALUES (23, N'Trà Thạch Đậu Đỏ', 5, 39000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	discount INT DEFAULT 0,
	status INT NOT NULL DEFAULT 0
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
	)
GO

--INSERT    dbo.Bill
--        ( DateCheckIn ,
--          DateCheckOut ,
--          idTable ,
--          status
--        )
--VALUES  ( GETDATE() , -- DateCheckIn - date
--          NULL , -- DateCheckOut - date
--          3 , -- idTable - int
--          0  -- status - int
--        )

--INSERT    dbo.Bill
--        ( DateCheckIn ,
--          DateCheckOut ,
--          idTable ,
--          status
--        )
--VALUES  ( GETDATE() , -- DateCheckIn - date
--          NULL , -- DateCheckOut - date
--          4, -- idTable - int
--          0  -- status - int
--        )
--INSERT    dbo.Bill
--        ( DateCheckIn ,
--          DateCheckOut ,
--          idTable ,
--          status
--        )
--VALUES  ( GETDATE() , -- DateCheckIn - date
--          GETDATE() , -- DateCheckOut - date
--          5 , -- idTable - int
--          1  -- status - int
--        )
--INSERT    dbo.Bill
--        ( DateCheckIn ,
--          idTable ,
--          status
--        )
--VALUES  ( GETDATE() , -- DateCheckIn - date
 
--          6 , -- idTable - int
--          0  -- status - int
--        )
--INSERT    dbo.Bill
--        ( DateCheckIn ,

--          idTable ,
--          status
--        )
--VALUES  ( GETDATE() , -- DateCheckIn - date
--          1 , -- idTable - int
--         0  -- status - int
--        )


CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)

)
GO

--INSERT    dbo.BillInfo
--        ( idBill, idFood, count )
--VALUES  ( 1, -- idBill - int
--          1, -- idFood - int
--          2  -- count - int
--          )
--INSERT    dbo.BillInfo
--        ( idBill, idFood, count )
--VALUES  ( 2, -- idBill - int
--          3, -- idFood - int
--          4  -- count - int
--          )
--INSERT    dbo.BillInfo
--        ( idBill, idFood, count )
--VALUES  ( 3, -- idBill - int
--          5, -- idFood - int
--          1  -- count - int
--          )
--INSERT    dbo.BillInfo
--        ( idBill, idFood, count )
--VALUES  ( 4, -- idBill - int
--          1, -- idFood - int
--          2  -- count - int
--          )
--INSERT    dbo.BillInfo
--        ( idBill, idFood, count )
--VALUES  ( 5, -- idBill - int
--          6, -- idFood - int
--          2  -- count - int
--          )
--GO

INSERT INTO dbo.Account
(UserName,
DisplayName,
PassWord,
Type
)
VALUES (N'admin', 
		N'admin',
		N'1',
		1
		)

INSERT INTO dbo.Account
(UserName,
DisplayName,
PassWord,
Type
)
VALUES (N'staff', 
		N'staff',
		N'1',
		0
		)
GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'admin' -- nvarchar(100)
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO


CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
			  discount,
	          status
			  
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        )
END
GO

use QuanLyQuanCafe
GO

CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 1
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @count
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO


CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO



CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE PROC USP_SwtichTable
@idTable1 INT , @idTable2 INT	
AS BEGIN
		DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	
	IF (@idFirstBill IS NULL)
	BEGIN

		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO 

ALTER TABLE dbo.Bill ADD totalPrice FLOAT

Delete dbo.Bill
select * from dbo.Bill
GO

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn],  DateCheckIn AS [Ngày nhập], DateCheckOut AS [Ngày xuất], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO

CREATE PROC USP_GetListBillByMonth
@checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn],  DateCheckIn AS [Ngày nhập], DateCheckOut AS [Ngày xuất], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE Month(DateCheckOut) = Month(@checkOut) AND 
	 Year(DateCheckOut) = Year(@checkOut) AND b.status = 1
	AND t.id = b.idTable
END
GO

SELECT t.name AS [Tên bàn],  DateCheckIn AS [Ngày nhập], DateCheckOut AS [Ngày xuất], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE Month(DateCheckOut) = Month(12) AND 
	 Year(DateCheckOut) = Year(2021) AND b.status = 1
	AND t.id = b.idTable
GO


	
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS 
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill = Deleted.idBill FROM Deleted
	
	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO



CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO

CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO