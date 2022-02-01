---------------DANH MỤC PHÂN QUYỀN 2019=12-29 15:57:00
/*
create table DanhMucMenu
(
	ID				bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	ThuTuHienThi	int,
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint		PK_DanhMucMenu primary key (ID),
	constraint		DanhMucMenu_AutoID foreign key (ID) references AutoID(ID),
	constraint		Ma_DanhMucMenu unique(Ma)
)
go
create table DanhMucMenuLoaiDoiTuong
(
	ID						bigint			not null,
	IDDanhMucMenu			bigint			not null,
	IDDanhMucLoaiDoiTuong	bigint			not null,
	NoiDungHienThi			nvarchar(255)	not null,
	PhanCachNhom			bit,
	ThuTuHienThi			int,
	CreateDate				datetime		not null,
	EditDate				datetime,
	constraint	PK_DanhMucMenuLoaiDoiTuong primary key (ID),
	constraint	DanhMucMenuLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuLoaiDoiTuong foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucMenuLoaiDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID)
)
go
create table DanhMucMenuChungTu
(
	ID					bigint			not null,
	IDDanhMucMenu		bigint			not null,
	IDDanhMucChungTu	bigint			not null,
	NoiDungHienThi		nvarchar(255)	not null,
	PhanCachNhom		bit,
	ThuTuHienThi		int,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucMenuChungTu primary key (ID),
	constraint	DanhMucMenuChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuChungTu foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucChungTu_DanhMucMenuChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID)
)
go
create table DanhMucMenuBaoCao
(
	ID					bigint			not null,
	IDDanhMucMenu		bigint			not null,
	IDDanhMucBaoCao		bigint			not null,
	NoiDungHienThi		nvarchar(255)	not null,
	PhanCachNhom		bit,
	ThuTuHienThi		int,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucMenuBaoCao primary key (ID),
	constraint	DanhMucMenuBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucMenu_DanhMucMenuBaoCao foreign key (IDDanhMucMenu) references DanhMucMenu(ID),
	constraint	DanhMucBaoCao_DanhMucMenuBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID)
)
go
*/
alter procedure List_DanhMucMenu
	@ID	bigint = null
as
begin
	set nocount on;
	select	a.ID, 
			a.Ma, a.Ten, 
			a.ThuTuHienThi, 
			a.CreateDate, 
			a.EditDate 
	from DanhMucMenu a where case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) order by ThuTuHienThi;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucLoaiDoiTuong, b.Ma MaDanhMucLoaiDoiTuong, b.Ten TenDanhMucLoaiDoiTuong,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			a.CreateDate,
			a.EditDate
	from DanhMucMenuLoaiDoiTuong a inner join DanhMucLoaiDoiTuong b on a.IDDanhMucLoaiDoiTuong = b.ID where case when @ID is not null then a.IDDanhMucMenu else 0 end = ISNULL(@ID, 0)
	order by ThuTuHienThi;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucChungTu, b.Ma MaDanhMucChungTu, b.Ten TenDanhMucChungTu, b.LoaiManHinh,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			a.CreateDate,
			a.EditDate
	from DanhMucMenuChungTu a inner join DanhMucChungTu b on a.IDDanhMucChungTu = b.ID where case when @ID is not null then a.IDDanhMucMenu else 0 end = ISNULL(@ID, 0)
	order by ThuTuHienThi;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucBaoCao, b.Ma MaDanhMucBaoCao, b.Ten TenDanhMucBaoCao,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			b.IDDanhMucNhomBaoCao,
			c.Ten TenDanhMucNhomBaoCao,
			a.CreateDate,
			a.EditDate
	from 
		DanhMucMenuBaoCao a inner join DanhMucBaoCao b on a.IDDanhMucBaoCao = b.ID 
		inner join DanhMucNhomBaoCao c on b.IDDanhMucNhomBaoCao = c.iD
	where case when @ID is not null then a.IDDanhMucMenu else 0 end = ISNULL(@ID, 0)
	order by ThuTuHienThi;
end
go
alter procedure Insert_DanhMucMenu
	@ID				bigint out,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@ThuTuHienThi	int,
	@CreateDate		datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucMenu';
		insert DanhMucMenu (ID, Ma, Ten, ThuTuHienThi, CreateDate) values (@ID, @Ma, @Ten, @ThuTuHienThi, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Update_DanhMucMenu
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@ThuTuHienThi	int,
	@EditDate		datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucMenu set
			Ma = @Ma,
			Ten = @Ten,
			ThuTuHienThi = @ThuTuHienThi,
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
alter procedure Delete_DanhMucMenu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucMenuBaoCao	where IDDanhMucMenu = @ID;
		delete DanhMucMenuChungTu	where IDDanhMucMenu = @ID;
		delete DanhMucMenuLoaiDoiTuong	where IDDanhMucMenu = @ID;
		delete DanhMucMenu	where ID = @ID;
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
alter procedure List_DanhMucMenuLoaiDoiTuong
	@ID	bigint = null,
	@IDDanhMucMenu	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucLoaiDoiTuong, b.Ma MaDanhMucLoaiDoiTuong, b.Ten TenDanhMucLoaiDoiTuong,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			a.CreateDate,
			a.EditDate
	from DanhMucMenuLoaiDoiTuong a inner join DanhMucLoaiDoiTuong b on a.IDDanhMucLoaiDoiTuong = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucMenu is not null then a.IDDanhMucMenu else 0 end = ISNULL(@IDDanhMucMenu, 0)
	order by a.ThuTuHienThi;
end
go
alter procedure Insert_DanhMucMenuLoaiDoiTuong
	@ID						bigint out,
	@IDDanhMucMenu			bigint,
	@IDDanhMucLoaiDoiTuong	bigint,
	@NoiDungHienThi			nvarchar(255),
	@PhanCachNhom			bit,
	@ThuTuHienThi			int,
	@CreateDate				datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucMenuLoaiDoiTuong';
		insert DanhMucMenuLoaiDoiTuong(ID, IDDanhMucMenu, IDDanhMucLoaiDoiTuong, NoiDungHienThi, PhanCachNhom, ThuTuHienThi, CreateDate) values (@ID, @IDDanhMucMenu, @IDDanhMucLoaiDoiTuong, @NoiDungHienThi, @PhanCachNhom, @ThuTuHienThi, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Update_DanhMucMenuLoaiDoiTuong
	@ID						bigint,
	@IDDanhMucLoaiDoiTuong	bigint,
	@NoiDungHienThi			nvarchar(255),
	@PhanCachNhom			bit,
	@ThuTuHienThi			int,
	@EditDate				datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucMenuLoaiDoiTuong set
			IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong,
			NoiDungHienThi = @NoiDungHienThi,
			PhanCachNhom = @PhanCachNhom,
			ThuTuHienThi = @ThuTuHienThi,
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
alter procedure Delete_DanhMucMenuLoaiDoiTuong
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucMenuLoaiDoiTuong	where ID = @ID;
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
alter procedure List_DanhMucMenuChungTu
	@ID	bigint = null,
	@IDDanhMucMenu	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucChungTu, b.Ma MaDanhMucChungTu, b.Ten TenDanhMucChungTu,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			a.CreateDate,
			a.EditDate
	from DanhMucMenuChungTu a inner join DanhMucChungTu b on a.IDDanhMucChungTu = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucMenu is not null then a.IDDanhMucMenu else 0 end = ISNULL(@IDDanhMucMenu, 0)
	order by a.ThuTuHienThi;
end
go
alter procedure Insert_DanhMucMenuChungTu
	@ID					bigint out,
	@IDDanhMucMenu		bigint,
	@IDDanhMucChungTu	bigint,
	@NoiDungHienThi		nvarchar(255),
	@PhanCachNhom		bit,
	@ThuTuHienThi		int,
	@CreateDate			datetime out	
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucMenuChungTu';
		insert DanhMucMenuChungTu (ID, IDDanhMucMenu, IDDanhMucChungTu, NoiDungHienThi, PhanCachNhom, ThuTuHienThi, CreateDate) values (@ID, @IDDanhMucMenu, @IDDanhMucChungTu, @NoiDungHienThi, @PhanCachNhom, @ThuTuHienThi, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Update_DanhMucMenuChungTu
	@ID					bigint,
	@IDDanhMucChungTu	bigint,
	@NoiDungHienThi		nvarchar(255),
	@PhanCachNhom		bit,
	@ThuTuHienThi		int,
	@EditDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucMenuChungTu set
			IDDanhMucChungTu = @IDDanhMucChungTu,
			NoiDungHienThi = @NoiDungHienThi,
			PhanCachNhom = @PhanCachNhom,
			ThuTuHienThi = @ThuTuHienThi,
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
alter procedure Delete_DanhMucMenuChungTu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucMenuChungTu	where ID = @ID;
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
alter procedure List_DanhMucMenuBaoCao
	@ID	bigint = null,
	@IDDanhMucMenu	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucMenu,
			a.IDDanhMucBaoCao, b.Ma MaDanhMucBaoCao, b.Ten TenDanhMucBaoCao,
			a.NoiDungHienThi,
			a.PhanCachNhom,
			a.ThuTuHienThi,
			a.CreateDate,
			a.EditDate
	from DanhMucMenuBaoCao a inner join DanhMucBaoCao b on a.IDDanhMucBaoCao = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucMenu is not null then a.IDDanhMucMenu else 0 end = ISNULL(@IDDanhMucMenu, 0)
	order by a.ThuTuHienThi;
end
go
alter procedure Insert_DanhMucMenuBaoCao
	@ID					bigint out,
	@IDDanhMucMenu		bigint,
	@IDDanhMucBaoCao	bigint,
	@NoiDungHienThi		nvarchar(255),
	@PhanCachNhom		bit,
	@ThuTuHienThi		int,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucMenuBaoCao';
		insert DanhMucMenuBaoCao (ID, IDDanhMucMenu, IDDanhMucBaoCao, NoiDungHienThi, PhanCachNhom, ThuTuHienThi, CreateDate) values (@ID, @IDDanhMucMenu, @IDDanhMucBaoCao, @NoiDungHienThi, @PhanCachNhom, @ThuTuHienThi, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
alter procedure Update_DanhMucMenuBaoCao
	@ID					bigint,
	@IDDanhMucBaoCao	bigint,
	@NoiDungHienThi		nvarchar(255),
	@PhanCachNhom		bit,
	@ThuTuHienThi		int,
	@EditDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucMenuBaoCao set
			IDDanhMucBaoCao = @IDDanhMucBaoCao,
			NoiDungHienThi = @NoiDungHienThi,
			PhanCachNhom = @PhanCachNhom,
			ThuTuHienThi = @ThuTuHienThi,
			EditDate = GETDATE()
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
alter procedure Delete_DanhMucMenuBaoCao
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucMenuBaoCao	where ID = @ID;
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