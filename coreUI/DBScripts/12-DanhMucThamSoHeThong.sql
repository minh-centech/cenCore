---------------DANH MỤC ĐƠN VỊ 2019-12-29 16:12
/*
create table DanhMucThamSoHeThong
(
	ID				bigint			not null,
	IDDanhMucDonVi	bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	GiaTri			nvarchar(max)	not null,
	GhiChu			nvarchar(255),
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint	PK_DanhMucThamSoHeThong primary key (ID),
	constraint	DanhMucThamSoHeThong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucDonVi_DanhMucThamSoHeThong foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	Ma_DanhMucThamSoHeThong unique(Ma)
)
go
*/
alter procedure List_DanhMucThamSoHeThong
	@ID bigint = null,
	@IDDanhMucDonVi bigint
as
begin
	set nocount on;
	select ID, IDDanhMucDonVi, Ma, Ten, GiaTri, GhiChu, CreateDate, EditDate from DanhMucThamSoHeThong 
		where IDDanhMucDonVi = @IDDanhMucDonVi and 
		case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) 
	order by Ma;
end
go
alter procedure Insert_DanhMucThamSoHeThong
	@ID				bigint out,
	@IDDanhMucDonVi bigint = null,
	@Ma				nvarchar(128) = null,
	@Ten			nvarchar(255) = null,
	@GiaTri			nvarchar(max) = null,
	@GhiChu			nvarchar(255) = null,
	@CreateDate		datetime = null out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã tham số hệ thống không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucThamSoHeThong where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã tham số hệ thống ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên tham số hệ thống không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @GiaTri is null or LTRIM(RTRIM(@GiaTri)) = ''
	begin
		raiserror(N'Giá trị tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;

	if @GhiChu is not null and len(@GhiChu) > 255
	begin
		raiserror(N'Ghi chú tham số hệ thống không được dài quá 255 kí tự!', 16, 1);
		return;
	end;


	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucThamSoHeThong';
		set @CreateDate = GETDATE();
		insert DanhMucThamSoHeThong (ID, IDDanhMucDonVi, Ma, Ten, GiaTri, GhiChu, CreateDate) values (@ID, @IDDanhMucDonVi, @Ma, @Ten, @GiaTri, @GhiChu, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Update_DanhMucThamSoHeThong
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@GiaTri			nvarchar(max),
	@GhiChu			nvarchar(255) = null,
	@EditDate		datetime = null out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã tham số hệ thống không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucThamSoHeThong where Ma = @Ma and ID <> @ID;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã tham số hệ thống ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên tham số hệ thống không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @GiaTri is null or LTRIM(RTRIM(@GiaTri)) = ''
	begin
		raiserror(N'Giá trị tham số hệ thống không được bỏ trống!', 16, 1);
		return;
	end;

	if @GhiChu is not null and len(@GhiChu) > 255
	begin
		raiserror(N'Ghi chú tham số hệ thống không được dài quá 255 kí tự!', 16, 1);
		return;
	end;

	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucThamSoHeThong set
			Ma = @Ma,
			Ten = @Ten,
			GiaTri = @GiaTri,
			GhiChu = @GhiChu,
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
alter procedure Delete_DanhMucThamSoHeThong
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucThamSoHeThong	where ID = @ID;
		delete AutoID where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Get_DanhMucThamSoHeThong_GiaTri
	@IDDanhMucDonVi bigint,
	@Ma nvarchar(128),
	@GiaTri nvarchar(4000) out
as
begin
	set nocount on;
	select @GiaTri = GiaTri from DanhMucThamSoHeThong where IDDanhMucDonVi = @IDDanhMucDonVi and 
	Ma = @Ma;
end
go