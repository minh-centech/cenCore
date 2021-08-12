---------------DANH MỤC ĐƠN VỊ 2019-12-29 16:12
/*

create table DanhMucThamSoNguoiSuDung
(
	ID						bigint			not null,
	IDDanhMucDonVi			bigint			not null,
	IDDanhMucNguoiSuDung	bigint			not null,
	Ma						nvarchar(128)	not null,
	Ten						nvarchar(255)	not null,
	GiaTri					nvarchar(max)	not null,
	GhiChu					nvarchar(255),
	CreateDate				datetime		not null,
	EditDate				datetime,
	constraint	PK_DanhMucThamSoNguoiSuDung primary key (ID),
	constraint	DanhMucThamSoNguoiSuDung_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucDonVi_DanhMucThamSoNguoiSuDung foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucNguoiSuDung_DanhMucThamSoNguoiSuDung foreign key (IDDanhMucNguoiSuDung) references DanhMucNguoiSuDung(ID),
	constraint	Ma_DanhMucThamSoNguoiSuDung unique(Ma)
)
go
*/
create procedure List_DanhMucThamSoNguoiSuDung
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucNguoiSuDung bigint
as
begin
	set nocount on;
	select ID, IDDanhMucDonVi, Ma, Ten, GiaTri, GhiChu, CreateDate, EditDate from DanhMucThamSoNguoiSuDung 
		where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucNguoiSuDung = @IDDanhMucNguoiSuDung and case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) 
	order by Ma;
end
go
create procedure Insert_DanhMucThamSoNguoiSuDung
	@ID						bigint out,
	@IDDanhMucDonVi			bigint,
	@IDDanhMucNguoiSuDung	bigint,
	@Ma						nvarchar(128),
	@Ten					nvarchar(255),
	@GiaTri					nvarchar(max),
	@GhiChu					nvarchar(255) = null,
	@CreateDate				datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucThamSoNguoiSuDung';
		set @CreateDate = GETDATE();
		insert DanhMucThamSoNguoiSuDung (ID, IDDanhMucDonVi, IDDanhMucNguoiSuDung, Ma, Ten, GiaTri, GhiChu, CreateDate) values (@ID, @IDDanhMucDonVi, @IDDanhMucNguoiSuDung, @Ma, @Ten, @GiaTri, @GhiChu, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucThamSoNguoiSuDung
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@GiaTri			nvarchar(max),
	@GhiChu			nvarchar(255) = null,
	@EditDate		datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucThamSoNguoiSuDung set
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
create procedure Update_DanhMucThamSoNguoiSuDung_GiaTri
	@IDDanhMucDonVi			bigint,
	@IDDanhMucNguoiSuDung	bigint,
	@Ma						nvarchar(128),
	@GiaTri					nvarchar(max),
	@EditDate				datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucThamSoNguoiSuDung set
			GiaTri = @GiaTri,
			EditDate = @EditDate
		where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucNguoiSuDung = @IDDanhMucNguoiSuDung and Ma = @Ma;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Delete_DanhMucThamSoNguoiSuDung
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucThamSoNguoiSuDung	where ID = @ID;
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
create procedure Get_DanhMucThamSoNguoiSuDung_GiaTri
	@IDDanhMucDonVi bigint,
	@IDDanhMucNguoiSuDung bigint,
	@Ma nvarchar(128),
	@GiaTri nvarchar(4000) out
as
begin
	set nocount on;
	select @GiaTri = GiaTri from DanhMucThamSoNguoiSuDung where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucNguoiSuDung = @IDDanhMucNguoiSuDung and Ma = @Ma;
end
go