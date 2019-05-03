CREATE PROC [dbo].[sp_view_amenities] 
AS
BEGIN
	SELECT ID, Name, Qty, Unit FROM Amenities WHERE (status = 'A')
END

CREATE proc [dbo].[sp_update_amenities] 
	@ID nchar(5),
	@Name nvarchar(100),
	@Qty int,
	@Unit nvarchar(100)
as
begin
	UPDATE Amenities SET Name=@Name,Qty=@Qty,Unit=@Unit WHERE ID=@ID
end

CREATE proc [dbo].[sp_last_amenities] 
AS
BEGIN
	SELECT id FROM amenities ORDER BY id DESC
END

CREATE proc [dbo].[sp_insert_amenities] 
	@ID nchar(5),
	@Name nvarchar(100),
	@Qty int,
	@Unit nvarchar(100),
	@Status nchar(1)
as
begin
	INSERT INTO Amenities VALUES (@ID,@Name,@Qty,@Unit,@Status)
end

CREATE proc [dbo].[sp_delete_amenities] 
	@ID nchar(5)
as
begin
	DELETE FROM Amenities WHERE ID = @ID
end
