/*
create table AutoID
(
	ID				bigint identity(1, 1) not null,
	TenBangDuLieu	nvarchar(128) not null,
	constraint PK_AutoID primary key (ID)
)
go
*/
-----------------
create procedure Insert_AutoID
	@ID bigint out,
	@TenBangDuLieu nvarchar(128)
as
begin
	set nocount on;
	insert AutoID (TenBangDuLieu) values (@TenBangDuLieu);
	select @ID = @@IDENTITY;
end
go
-----------------
create procedure Delete_AutoID
	@ID bigint
as
begin
	set nocount on;
	delete AutoID where ID = @ID;
end
go
-----------------
alter procedure Check_ForeignKey
	@TableName nvarchar(255),
	@ColumnName		nvarchar(255),
	@ValueCheck		bigint,
	@Exist			bit = 1, --nếu bằng 1 thì check tồn tại, = null/0 thì check không tồn tại
	@ErrorMessage	nvarchar(max),
	@Count			bigint = null output
as
begin
	create table #Count
	(
		Count bigint
	);
	declare @strSql nvarchar(max) = 'insert into #Count select count(' + @ColumnName + ') from ' + @TableName + ' where ' + @ColumnName + ' = ' + cast(@ValueCheck as nvarchar(30)) ;

	exec sp_executesql @strSql;

	select @Count = (select top 1 Count from #Count);

	drop table #Count;

	if (@Exist = 1 and @Count > 0)
	begin
		raiserror(@ErrorMessage, 16, 1);
		return;
	end;

	if (@Exist is null or @Exist = 0) and @Count = 0
	begin
		raiserror(@ErrorMessage, 16, 1);
		return;
	end;
end;
go
