---------------DANH MỤC ĐƠN VỊ 2019-12-29 16:12
/*
create table DanhMucTuDien
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucTuDien primary key (ID),
	constraint	DanhMucTuDien_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucTuDien unique(Ma)
)
go
*/
create procedure List_DanhMucTuDien
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, CreateDate, EditDate from DanhMucTuDien where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
create procedure Insert_DanhMucTuDien
	@ID			bigint out,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@CreateDate datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucTuDien';
		set @CreateDate = GETDATE();
		insert DanhMucTuDien (ID, Ma, Ten, CreateDate) values (@ID, @Ma, @Ten, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucTuDien
	@ID			bigint,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@EditDate	datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucTuDien set
			Ma = @Ma,
			Ten = @Ten,
			EditDate = @EditDate
		where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Delete_DanhMucTuDien
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucTuDien	where ID = @ID;
		delete AutoID where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end