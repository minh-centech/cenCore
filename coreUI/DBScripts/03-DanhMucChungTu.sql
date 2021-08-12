---------------DANH MỤC CHỨNG TỪ
/*
create table DanhMucChungTu
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	KiHieu		nvarchar(20)	not null,
	LoaiManHinh	nvarchar(128)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucChungTu primary key (ID),
	constraint	DanhMucChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucChungTu unique(Ma)
)
go
create table DanhMucChungTuTrangThai
(
	ID					bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	HachToan			bit,
	Sua					bit,
	Xoa					bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucChungTuTrangThai primary key (ID),
	constraint	DanhMucChungTuTrangThai_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuTrangThai_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	Ma_DanhMucChungTuTrangThai unique(Ma)
)
go
create table DanhMucChungTuIn
(
	ID					bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	ListProcedureName	nvarchar(255)	not null,
	FileMauIn			nvarchar(255)	not null,
	SoLien				tinyint			not null,
	PrintPreview		bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucChungTuIn primary key (ID),
	constraint	DanhMucChungTuIn_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuIn_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	Ma_DanhMucChungTuIn unique(Ma)
)
go
create table DanhMucChungTuQuyTrinh
(
	ID							bigint		not null,
	IDDanhMucChungTu			bigint		not null,
	IDDanhMucChungTuQuyTrinh	bigint		not null,
	CreateDate					datetime	not null,
	EditDate					datetime,
	constraint	PK_DanhMucChungTuQuyTrinh primary key (ID),
	constraint	DanhMucChungTuQuyTrinh_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucChungTuQuyTrinh_DanhMucChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint	DanhMucChungTuQuyTrinh_DanhMucChungTuQuyTrinh foreign key (IDDanhMucChungTuQuyTrinh) references DanhMucChungTu(ID)
)
go
*/
------------
create procedure List_DanhMucChungTu
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, KiHieu, LoaiManHinh, CreateDate, EditDate from DanhMucChungTu where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
	select ID, IDDanhMucChungTu, Ma, Ten, HachToan, Sua, Xoa, CreateDate, EditDate from DanhMucChungTuTrangThai where	case when @ID is not null then IDDanhMucChungTu else 0 end = ISNULL(@ID, 0) order by Ma;
	select ID, IDDanhMucChungTu, Ma, Ten, ListProcedureName, FileMauIn, SoLien, PrintPreview, CreateDate, EditDate from DanhMucChungTuIn where	case when @ID is not null then IDDanhMucChungTu else 0 end = ISNULL(@ID, 0) order by Ma;
	select a.ID, a.IDDanhMucChungTu, a.IDDanhMucChungTuQuyTrinh, b.Ma MaDanhMucChungTuQuyTrinh, b.Ten TenDanhMucChungTuQuyTrinh, a.CreateDate, a.EditDate from DanhMucChungTuQuyTrinh a inner join DanhMucChungTu b on a.IDDanhMucChungTuQuyTrinh = b.ID where	case when @ID is not null then a.IDDanhMucChungTu else 0 end = ISNULL(@ID, 0) order by b.Ma;
end
go
create procedure Insert_DanhMucChungTu
	@ID				bigint out,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@KiHieu			nvarchar(20),
	@LoaiManHinh	nvarchar(128),
	@CreateDate		datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucChungTu';
		insert DanhMucChungTu (ID, Ma, Ten, KiHieu, LoaiManHinh, CreateDate) values (@ID, @Ma, @Ten, @KiHieu, @LoaiManHinh, @CreateDate);
		--Thêm vào danh mục phân quyền
		declare @IDChiTiet bigint;
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucPhanQuyen;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenChungTu @ID = null, @IDDanhMucPhanQuyen = @IDChiTiet, @IDDanhMucChungTu = @ID, @Xem = 0, @Them = 0, @Sua = 0, @Xoa = 0, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucChungTu
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@KiHieu			nvarchar(20),
	@LoaiManHinh	nvarchar(128),
	@EditDate		datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @EditDate = GETDATE();
		update DanhMucChungTu set
			Ma = @Ma,
			Ten = @Ten,
			KiHieu = @KiHieu,
			LoaiManHinh = @LoaiManHinh,
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
create procedure Delete_DanhMucChungTu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenChungTu	where IDDanhMucChungTu = @ID;
		delete DanhMucChungTuQuyTrinh	where IDDanhMucChungTu = @ID;
		delete DanhMucChungTuIn	where IDDanhMucChungTu = @ID;
		delete DanhMucChungTuTrangThai	where IDDanhMucChungTu = @ID;
		delete DanhMucChungTu	where ID = @ID;
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
create procedure List_DanhMucChungTuTrangThai
	@ID bigint = null,
	@IDDanhMucChungTu bigint = null
as
begin
	set nocount on;
	select ID, IDDanhMucChungTu, Ma, Ten, HachToan, Sua, Xoa, CreateDate, EditDate from DanhMucChungTuTrangThai 
	where	case when @ID is not null then ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucChungTu is not null then IDDanhMucChungTu else 0 end = ISNULL(@IDDanhMucChungTu, 0)
end
go
create procedure Insert_DanhMucChungTuTrangThai
	@ID					bigint out,
	@IDDanhMucChungTu	bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@HachToan			bit,
	@Sua				bit,
	@Xoa				bit,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucChungTuTrangThai';
		insert DanhMucChungTuTrangThai (ID, IDDanhMucChungTu, Ma, Ten, HachToan, Sua, Xoa, CreateDate) 
		values (@ID, @IDDanhMucChungTu, @Ma, @Ten, @HachToan, @Sua, @Xoa, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucChungTuTrangThai
	@ID			bigint,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@HachToan	bit,
	@Sua		bit,
	@Xoa		bit,
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @EditDate = GETDATE();
		update DanhMucChungTuTrangThai set
			Ma = @Ma,
			Ten = @Ten,
			HachToan = @HachToan,
			Sua = @Sua,
			Xoa = @Xoa,
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
create procedure Delete_DanhMucChungTuTrangThai
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucChungTuTrangThai	where ID = @ID;
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
create procedure List_DanhMucChungTuIn
	@ID bigint = null,
	@IDDanhMucChungTu bigint = null
as
begin
	set nocount on;
	select ID, IDDanhMucChungTu, Ma, Ten, ListProcedureName, FileMauIn, SoLien, PrintPreview, CreateDate, EditDate from DanhMucChungTuIn
	where	case when @ID is not null then ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucChungTu is not null then IDDanhMucChungTu else 0 end = ISNULL(@IDDanhMucChungTu, 0)
end
go
create procedure Insert_DanhMucChungTuIn
	@ID					bigint out,
	@IDDanhMucChungTu	bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@ListProcedureName	nvarchar(255),
	@FileMauIn			nvarchar(255),
	@SoLien				tinyint,
	@PrintPreview		bit,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucChungTuIn';
		insert DanhMucChungTuIn (ID, IDDanhMucChungTu, Ma, Ten, ListProcedureName, FileMauIn, SoLien, PrintPreview, CreateDate) 
		values (@ID, @IDDanhMucChungTu, @Ma, @Ten, @ListProcedureName, @FileMauIn, @SoLien, @PrintPreview, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucChungTuIn
	@ID					bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@ListProcedureName	nvarchar(255),
	@FileMauIn			nvarchar(255),
	@SoLien				tinyint,
	@PrintPreview		bit,
	@EditDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @EditDate = GETDATE();
		update DanhMucChungTuIn set
			Ma = @Ma,
			Ten = @Ten,
			ListProcedureName = @ListProcedureName,
			FileMauIn = @FileMauIn,
			SoLien = @SoLien,
			PrintPreview = @PrintPreview,
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
create procedure Delete_DanhMucChungTuIn
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucChungTuIn	where ID = @ID;
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
create procedure List_DanhMucChungTuQuyTrinh
	@ID bigint = null,
	@IDDanhMucChungTu bigint = null
as
begin
	set nocount on;
	select a.ID, a.IDDanhMucChungTu, a.IDDanhMucChungTuQuyTrinh, b.Ma MaDanhMucChungTuQuyTrinh, b.Ten TenDanhMucChungTuQuyTrinh, a.CreateDate, a.EditDate from DanhMucChungTuQuyTrinh a inner join DanhMucChungTu b on a.IDDanhMucChungTuQuyTrinh = b.ID
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucChungTu is not null then a.IDDanhMucChungTu else 0 end = ISNULL(@IDDanhMucChungTu, 0)
end
go
create procedure Insert_DanhMucChungTuQuyTrinh
	@ID							bigint out,
	@IDDanhMucChungTu			bigint,
	@IDDanhMucChungTuQuyTrinh	bigint,
	@CreateDate					datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucChungTuQuyTrinh';
		insert DanhMucChungTuQuyTrinh (ID, IDDanhMucChungTu, IDDanhMucChungTuQuyTrinh, CreateDate) 
		values (@ID, @IDDanhMucChungTu, @IDDanhMucChungTuQuyTrinh, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucChungTuQuyTrinh
	@ID							bigint,
	@IDDanhMucChungTuQuyTrinh	bigint,
	@EditDate					datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @EditDate = GETDATE();
		update DanhMucChungTuQuyTrinh set
			IDDanhMucChungTuQuyTrinh = @IDDanhMucChungTuQuyTrinh,
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
create procedure Delete_DanhMucChungTuQuyTrinh
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucChungTuQuyTrinh	where ID = @ID;
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
create procedure Get_DanhMucChungTu_ID
	@Ma nvarchar(128),
	@ID bigint out
as
begin
	set nocount on;
	select @ID = ID from DanhMucChungTu where Ma = @Ma;
end
go
