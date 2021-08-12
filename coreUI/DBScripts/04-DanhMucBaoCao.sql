---------------DANH MỤC BÁO CÁO 2019-12-30 009:00
/*
create table DanhMucNhomBaoCao
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucNhomBaoCao primary key (ID),
	constraint	DanhMucNhomBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucNhomBaoCao unique(Ma)
)
go
create table DanhMucBaoCao
(
	ID							bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	ReportProcedureName			nvarchar(255)	not null,
	FixedColumnList				nvarchar(255),
	KhoGiay						smallint		not null,
	HuongIn						smallint		not null,
	ChucDanhKy					nvarchar(255),
	DienGiaiKy					nvarchar(255),
	TenNguoiKy					nvarchar(255),
	ThamChieuChungTu			bit,
	IDDanhMucBaoCaoThamChieu	bigint,
	IDDanhMucNhomBaoCao			bigint			not null,
	FileExcelMau				nvarchar(max), --File Excel export
	SheetExcelMau				nvarchar(255), --Sheet Excel export
	SoDongBatDau				int, -- Số dòng bắt đầu export trong file excel
	CreateDate					datetime		not null,
	EditDate					datetime,
	constraint	PK_DanhMucBaoCao primary key (ID),
	constraint	DanhMucBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucBaoCao unique(Ma),
	constraint	DanhMucBaoCaoThamChieu_DanhMucBaoCao foreign key (IDDanhMucBaoCaoThamChieu) references DanhMucBaoCao(ID),
	constraint	DanhMucNhomBaoCao_DanhMucBaoCao foreign key (IDDanhMucNhomBaoCao) references DanhMucNhomBaoCao(ID)
)
go
create table DanhMucBaoCaoCot
(
	ID				bigint			not null,
	IDDanhMucBaoCao	bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	ColumnWidth		float			not null,
	HeaderHeight	float,
	TenNhomCot		nvarchar(255),
	ThuTu			tinyint,
	TenCotExcel		nvarchar(2),
	KieuDuLieu		tinyint not null, --Kiểu dữ liệu cột: 1: Text, 2: Ngày tháng, 3: Số nguyên, 4: Số thực, 5: Check
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint	PK_DanhMucBaoCaoCot primary key (ID),
	constraint	DanhMucBaoCaoCot_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucBaoCaoCot_DanhMucBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID),
)
go
*/
------------
create procedure List_DanhMucNhomBaoCao
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, CreateDate, EditDate from DanhMucNhomBaoCao where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
create procedure Insert_DanhMucNhomBaoCao
	@ID			bigint out,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@CreateDate datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucNhomBaoCao';
		insert DanhMucNhomBaoCao (ID, Ma, Ten, CreateDate) values (@ID, @Ma, @Ten, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucNhomBaoCao
	@ID			bigint,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucNhomBaoCao set
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
create procedure Delete_DanhMucNhomBaoCao
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucNhomBaoCao	where ID = @ID;
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
create procedure List_DanhMucBaoCao
	@ID bigint = null
as
begin
	set nocount on;
	select 
		a.ID, 
		a.Ma, 
		a.Ten, 
		a.ReportProcedureName,	
		a.FixedColumnList,
		a.KhoGiay,
		a.HuongIn,
		a.ChucDanhKy,
		a.DienGiaiKy,
		a.TenNguoiKy,
		a.ThamChieuChungTu,
		a.IDDanhMucBaoCaoThamChieu, b.Ma MaDanhMucBaoCaoThamChieu, b.Ten TenDanhMucBaoCaoThamChieu,
		a.IDDanhMucNhomBaoCao, c.Ma MaDanhMucNhomBaoCao, c.Ten TenDanhMucNhomBaoCao,
		a.FileExcelMau,
		a.SheetExcelMau,
		a.SoDongBatDau,
		a.CreateDate,
		a.EditDate
	from DanhMucBaoCao a
		left join DanhMucBaoCao b on a.IDDanhMucBaoCaoThamChieu = b.ID
		inner join DanhMucNhomBaoCao c on a.IDDanhMucNhomBaoCao = c.ID
	where case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) order by Ma;
	select 
		ID,
		IDDanhMucBaoCao,
		Ma,
		Ten,
		ColumnWidth,
		HeaderHeight,
		TenNhomCot,
		ThuTu,
		TenCotExcel,
		KieuDuLieu,
		CreateDate,
		EditDate
	from DanhMucBaoCaoCot where	case when @ID is not null then IDDanhMucBaoCao else 0 end = ISNULL(@ID, 0) order by ThuTu;
end
go
create procedure Insert_DanhMucBaoCao
	@ID							bigint out,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@ReportProcedureName		nvarchar(255),
	@FixedColumnList			nvarchar(255) = null,
	@KhoGiay					smallint,
	@HuongIn					smallint,
	@ChucDanhKy					nvarchar(255) = null,
	@DienGiaiKy					nvarchar(255) = null,
	@TenNguoiKy					nvarchar(255) = null,
	@ThamChieuChungTu			bit,
	@IDDanhMucBaoCaoThamChieu	bigint = null,
	@IDDanhMucBaoCaoCopyCot		bigint = null,
	@FileExcelMau				nvarchar(max) = null,
	@SheetExcelMau				nvarchar(255) = null,
	@SoDongBatDau				int = null,
	@IDDanhMucNhomBaoCao		bigint,
	@CreateDate					datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucBaoCao';
		set @CreateDate = GETDATE();
		insert DanhMucBaoCao (ID, Ma, Ten, ReportProcedureName, FixedColumnList, KhoGiay, HuongIn, ChucDanhKy, DienGiaiKy, TenNguoiKy, ThamChieuChungTu, IDDanhMucBaoCaoThamChieu, FileExcelMau, SheetExcelMau, SoDongBatDau, IDDanhMucNhomBaoCao, CreateDate) 
			values (@ID, @Ma, @Ten, @ReportProcedureName, @FixedColumnList, @KhoGiay, @HuongIn, @ChucDanhKy, @DienGiaiKy, @TenNguoiKy, @ThamChieuChungTu, @IDDanhMucBaoCaoThamChieu, @FileExcelMau, @SheetExcelMau, @SoDongBatDau, @IDDanhMucNhomBaoCao, @CreateDate);
		--Thêm vào danh mục phân quyền
		declare @IDChiTiet bigint;
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucPhanQuyen;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenBaoCao @ID = null, @IDDanhMucPhanQuyen = @IDChiTiet, @IDDanhMucBaoCao = @ID, @Xem = 0, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
		--Copy cột báo cáo
		if @IDDanhMucBaoCaoCopyCot is not null
		begin
			declare @MaCot nvarchar(128), @TenCot nvarchar(255), @ColumnWidth float, @HeaderHeight float, @TenNhomCot nvarchar(255), @ThuTu tinyint, @TenCotExcel nvarchar(2), @KieuDuLieu tinyint
			declare curDanhMucBaoCaoCot cursor for select Ma, Ten, ColumnWidth, HeaderHeight, TenNhomCot, TenCotExcel, KieuDuLieu, ThuTu from DanhMucBaoCaoCot where IDDanhMucBaoCao = @IDDanhMucBaoCaoCopyCot
			open curDanhMucBaoCaoCot
			fetch next from curDanhMucBaoCaoCot into @MaCot, @TenCot, @ColumnWidth, @HeaderHeight, @TenNhomCot, @TenCotExcel, @KieuDuLieu, @ThuTu
			while @@fetch_status = 0
			begin
				exec Insert_DanhMucBaoCaoCot null, @ID, @MaCot, @TenCot, @ColumnWidth, @HeaderHeight, @TenNhomCot, @ThuTu, @TenCotExcel, @KieuDuLieu, null
				fetch next from curDanhMucBaoCaoCot into @MaCot, @TenCot, @ColumnWidth, @HeaderHeight, @TenNhomCot, @TenCotExcel, @KieuDuLieu, @ThuTu
			end;
			deallocate curDanhMucBaoCaoCot
		end;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucBaoCao
	@ID							bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@ReportProcedureName		nvarchar(255),
	@FixedColumnList			nvarchar(255) = null,
	@KhoGiay					smallint,
	@HuongIn					smallint,
	@ChucDanhKy					nvarchar(255) = null,
	@DienGiaiKy					nvarchar(255) = null,
	@TenNguoiKy					nvarchar(255) = null,
	@ThamChieuChungTu			bit,
	@IDDanhMucBaoCaoThamChieu	bigint = null,
	@FileExcelMau				nvarchar(max) = null,
	@SheetExcelMau				nvarchar(255) = null,
	@SoDongBatDau				int = null,
	@IDDanhMucNhomBaoCao		bigint,
	@EditDate					datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucBaoCao set
			Ma = @Ma,
			Ten = @Ten,
			ReportProcedureName = @ReportProcedureName,
			FixedColumnList = @FixedColumnList,
			KhoGiay = @KhoGiay,
			HuongIn = @HuongIn,
			ChucDanhKy = @ChucDanhKy,
			DienGiaiKy = @DienGiaiKy,
			TenNguoiKy = @TenNguoiKy,
			ThamChieuChungTu = @ThamChieuChungTu,
			FileExcelMau = @FileExcelMau,
			SheetExcelMau = @SheetExcelMau,
			SoDongBatDau = @SoDongBatDau,
			IDDanhMucNhomBaoCao = @IDDanhMucNhomBaoCao,
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
create procedure Delete_DanhMucBaoCao
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenBaoCao	where IDDanhMucBaoCao = @ID;
		delete DanhMucBaoCaoCot	where IDDanhMucBaoCao = @ID;
		delete DanhMucBaoCao	where ID = @ID;
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
create procedure List_DanhMucBaoCaoCot
	@ID bigint = null,
	@IDDanhMucBaoCao bigint = null
as
begin
	set nocount on;
	select 
		ID,
		IDDanhMucBaoCao,
		Ma,
		Ten,
		ColumnWidth,
		HeaderHeight,
		TenNhomCot,
		ThuTu,
		TenCotExcel,
		KieuDuLieu,
		CreateDate,
		EditDate
	from DanhMucBaoCaoCot
	where	case when @ID is not null then ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucBaoCao is not null then IDDanhMucBaoCao else 0 end = ISNULL(@IDDanhMucBaoCao, 0);
end
go
create procedure Insert_DanhMucBaoCaoCot
	@ID					bigint out,
	@IDDanhMucBaoCao	bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@ColumnWidth		float,
	@HeaderHeight		float,
	@TenNhomCot			nvarchar(255) = null,
	@ThuTu				tinyint,
	@TenCotExcel		nvarchar(2),
	@KieuDuLieu			tinyint,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucBaoCaoCot';
		set @CreateDate = GETDATE();
		insert DanhMucBaoCaoCot (ID, IDDanhMucBaoCao, Ma, Ten, ColumnWidth, HeaderHeight, TenNhomCot, ThuTu, TenCotExcel, KieuDuLieu, CreateDate) 
			values (@ID, @IDDanhMucBaoCao, @Ma, @Ten, @ColumnWidth, @HeaderHeight, @TenNhomCot, @ThuTu, @TenCotExcel, @KieuDuLieu, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucBaoCaoCot
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@ColumnWidth	float,
	@HeaderHeight	float,
	@TenNhomCot		nvarchar(255) = null,
	@ThuTu			tinyint,
	@TenCotExcel	nvarchar(2),
	@KieuDuLieu		tinyint,
	@EditDate		datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucBaoCaoCot set
			Ma = @Ma,
			Ten = @Ten,
			ColumnWidth = @ColumnWidth,
			HeaderHeight = @HeaderHeight,
			TenNhomCot = @TenNhomCot,
			ThuTu = @ThuTu,
			TenCotExcel = @TenCotExcel,
			KieuDuLieu = @KieuDuLieu,
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
create procedure Delete_DanhMucBaoCaoCot
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucBaoCaoCot	where ID = @ID;
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
create procedure GetMa_DanhMucBaoCao_ByID
	@ID bigint,
	@Ma nvarchar(128) = null out
as
begin
	set nocount on;
	select @Ma = Ma from DanhMucBaoCao where ID = @ID;
end
go
/* COPY BÁO CÁO CỘT
select * from DanhMucBaoCao
select * from DanhMucBaoCaoCot where IDDanhMucBaoCao = 5422

declare @Ma nvarchar(128), @Ten nvarchar(255), @ColumnWidth int, @HeaderHeight int, @TenNhomCot nvarchar(255), @ThuTu int, @KieuDuLieu tinyint
declare curBaoCaoCot cursor for select Ma, Ten, ColumnWidth, HeaderHeight, TenNhomCot, ThuTu, KieuDuLieu from DanhMucBaoCaoCot where IDDanhMucBaoCao = 5422
open curBaoCaoCot
fetch next from curBaoCaoCot into @Ma, @Ten, @ColumnWidth, @HeaderHeight, @TenNhomCot, @ThuTu, @KieuDuLieu
while @@FETCH_STATUS = 0
begin
	exec Insert_DanhMucBaoCaoCot null, 35695, @Ma, @Ten, @ColumnWidth, @HeaderHeight, @TenNhomCot, @ThuTu, @KieuDuLieu, null
	fetch next from curBaoCaoCot into @Ma, @Ten, @ColumnWidth, @HeaderHeight, @TenNhomCot, @ThuTu, @KieuDuLieu
end
deallocate curBaoCaoCot
*/
