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
create procedure Check_ForeignKey
	@TableName nvarchar(255) = null,
	@ColumnName nvarchar(255) = null,
	@ValueCheck bigint = null,
	@ErrorMessage nvarchar(max) = null,
	@Count bigint = null output
as
begin
	create table #Count
	(
		Count bigint
	);
	declare @strSql nvarchar(max) = 'insert into #Count select count(' + @ColumnName + ') from ' + @TableName + ' where ' + @ColumnName + ' = ' + cast(@ValueCheck as nvarchar(30)) ;

	exec sp_executesql @strSql;

	select @Count = (select top 1 Count from #Count);

	if (@Count > 0)
	begin
		raiserror(@ErrorMessage, 16, 1);
	end;

	drop table #Count;
end;
go
-----------------