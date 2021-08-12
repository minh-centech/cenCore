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
create procedure List_DanhMucThamSoHeThong
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
create procedure Insert_DanhMucThamSoHeThong
	@ID				bigint out,
	@IDDanhMucDonVi bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@GiaTri			nvarchar(max),
	@GhiChu			nvarchar(255) = null,
	@CreateDate		datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
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
create procedure Update_DanhMucThamSoHeThong
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
create procedure Delete_DanhMucThamSoHeThong
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
create procedure Get_DanhMucThamSoHeThong_GiaTri
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