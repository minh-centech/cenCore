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
	FileInMau					nvarchar(255), --File crystal report
	FileExcelMau				nvarchar(255), --File Excel export
	SheetExcelMau				nvarchar(255), --Sheet Excel export
	SoDongBatDau				tinyint, -- Số dòng bắt đầu export trong file excel
	ThamChieuChungTu			bit,
	IDDanhMucBaoCaoThamChieu	bigint,
	IDDanhMucNhomBaoCao			bigint			not null,
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
alter procedure List_DanhMucNhomBaoCao
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, CreateDate, EditDate from DanhMucNhomBaoCao where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
alter procedure Insert_DanhMucNhomBaoCao
	@ID			bigint out,
	@Ma			nvarchar(128) = null,
	@Ten		nvarchar(255) = null,
	@CreateDate datetime out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã nhóm báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã nhóm báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucNhomBaoCao where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã nhóm báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên nhóm báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên nhóm báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucNhomBaoCao';
		insert DanhMucNhomBaoCao (ID, Ma, Ten, CreateDate) values (@ID, @Ma, @Ten, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE();
		raiserror(@ErrMsg, 16, 1);
	end catch;
end
go
alter procedure Update_DanhMucNhomBaoCao
	@ID			bigint,
	@Ma			nvarchar(128),
	@Ten		nvarchar(255),
	@EditDate	datetime out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã nhóm báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã nhóm báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucNhomBaoCao where Ma = @Ma and ID <> @ID;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã nhóm báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên nhóm báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên nhóm báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

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
alter procedure Delete_DanhMucNhomBaoCao
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
alter procedure List_DanhMucBaoCao
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
		a.FileInMau,
		a.FileExcelMau,
		a.SheetExcelMau,
		a.SoDongBatDau,
		a.ThamChieuChungTu,
		a.IDDanhMucBaoCaoThamChieu, b.Ma MaDanhMucBaoCaoThamChieu, b.Ten TenDanhMucBaoCaoThamChieu,
		a.IDDanhMucNhomBaoCao, c.Ma MaDanhMucNhomBaoCao, c.Ten TenDanhMucNhomBaoCao,
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
alter procedure Insert_DanhMucBaoCao
	@ID							bigint out,
	@Ma							nvarchar(128) = null,
	@Ten						nvarchar(255) = null,
	@ReportProcedureName		nvarchar(255) = null,
	@FixedColumnList			nvarchar(255) = null,
	@KhoGiay					smallint = null,
	@HuongIn					smallint = null,
	@ChucDanhKy					nvarchar(255) = null,
	@DienGiaiKy					nvarchar(255) = null,
	@TenNguoiKy					nvarchar(255) = null,
	@FileInMau					nvarchar(255) = null,
	@FileExcelMau				nvarchar(255) = null,
	@SheetExcelMau				nvarchar(255) = null,
	@SoDongBatDau				tinyint = null,
	@ThamChieuChungTu			bit = null,
	@IDDanhMucBaoCaoThamChieu	bigint = null,
	@IDDanhMucBaoCaoCopyCot		bigint = null,
	@IDDanhMucNhomBaoCao		bigint = null,
	@CreateDate					datetime out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucBaoCao where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @ReportProcedureName is null or LTRIM(RTRIM(@ReportProcedureName)) = ''
	begin
		raiserror(N'Tên store báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@ReportProcedureName) > 255
	begin
		raiserror(N'Tên store báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @FixedColumnList is not null and LTRIM(RTRIM(@FixedColumnList)) > 255
	begin
		raiserror(N'Danh sách cột fixed không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;
	
	if @KhoGiay is null
	begin
		raiserror(N'Khổ giấy in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @KhoGiay < 1 or @KhoGiay > 2
	begin
		raiserror(N'Khổ giấy in báo cáo chỉ nhận giá trị 1 (A4) hoặc 2 (A3)!', 16, 1);
		return;
	end;

	if @KhoGiay is null
	begin
		raiserror(N'Khổ giấy in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @KhoGiay < 1 or @KhoGiay > 2
	begin
		raiserror(N'Khổ giấy in báo cáo chỉ nhận giá trị 1 (A4) hoặc 2 (A3)!', 16, 1);
		return;
	end;

	if @HuongIn is null
	begin
		raiserror(N'Hướng in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @HuongIn < 1 or @HuongIn > 2
	begin
		raiserror(N'Hướng in báo cáo chỉ nhận giá trị 1 (Dọc) hoặc 2 (Ngang)!', 16, 1);
		return;
	end;

	if @ChucDanhKy is not null and LTRIM(RTRIM(@ChucDanhKy)) > 255
	begin
		raiserror(N'Chức danh kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @DienGiaiKy is not null and LTRIM(RTRIM(@DienGiaiKy)) > 255
	begin
		raiserror(N'Diễn giải kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @TenNguoiKy is not null and LTRIM(RTRIM(@TenNguoiKy)) > 255
	begin
		raiserror(N'Tên người kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @FileInMau is not null and LTRIM(RTRIM(@FileInMau)) > 255
	begin
		raiserror(N'Tên file mẫu in không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @FileExcelMau is not null and LTRIM(RTRIM(@FileExcelMau)) > 255
	begin
		raiserror(N'Tên file excel mẫu không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @SheetExcelMau is not null and LTRIM(RTRIM(@SheetExcelMau)) > 255
	begin
		raiserror(N'Tên sheet excel mẫu không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @SoDongBatDau is not null and (@SoDongBatDau < 0 or @SoDongBatDau > 255)
	begin
		raiserror(N'Số dòng bắt đầu phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if @IDDanhMucBaoCaoThamChieu is not null
	begin
		select @countID = count(ID) from DanhMucBaoCao where ID = @IDDanhMucBaoCaoThamChieu;
		if @countID = 0
		begin
			set @ErrMsg = N'Mã báo cáo tham chiếu không tồn tại!'
			raiserror(@ErrMsg, 16, 1);
			return;
		end;
	end;

	if @IDDanhMucNhomBaoCao is null
	begin
		set @ErrMsg = N'Mã nhóm báo cáo không được bỏ trống!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucNhomBaoCao where ID = @IDDanhMucNhomBaoCao;
	if @countID = 0
	begin
		set @ErrMsg = N'Mã nhóm báo cáo không tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;


	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucBaoCao';
		set @CreateDate = GETDATE();
		insert DanhMucBaoCao (ID, Ma, Ten, ReportProcedureName, FixedColumnList, KhoGiay, HuongIn, ChucDanhKy, DienGiaiKy, TenNguoiKy, FileInMau, FileExcelMau, SheetExcelMau, SoDongBatDau, ThamChieuChungTu, IDDanhMucBaoCaoThamChieu, IDDanhMucNhomBaoCao, CreateDate) 
			values (@ID, @Ma, @Ten, @ReportProcedureName, @FixedColumnList, @KhoGiay, @HuongIn, @ChucDanhKy, @DienGiaiKy, @TenNguoiKy, @FileInMau, @FileExcelMau, @SheetExcelMau, @SoDongBatDau, isnull(@ThamChieuChungTu, 0), @IDDanhMucBaoCaoThamChieu, @IDDanhMucNhomBaoCao, @CreateDate);
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
alter procedure Update_DanhMucBaoCao
	@ID							bigint,
	@Ma							nvarchar(128) = null,
	@Ten						nvarchar(255) = null,
	@ReportProcedureName		nvarchar(255) = null,
	@FixedColumnList			nvarchar(255) = null,
	@KhoGiay					smallint = null,
	@HuongIn					smallint = null,
	@ChucDanhKy					nvarchar(255) = null,
	@DienGiaiKy					nvarchar(255) = null,
	@TenNguoiKy					nvarchar(255) = null,
	@FileInMau					nvarchar(255) = null,
	@FileExcelMau				nvarchar(255) = null,
	@SheetExcelMau				nvarchar(255) = null,
	@SoDongBatDau				tinyint = null,
	@ThamChieuChungTu			bit = null,
	@IDDanhMucBaoCaoThamChieu	bigint = null,
	@IDDanhMucBaoCaoCopyCot		bigint = null,
	@IDDanhMucNhomBaoCao		bigint = null,
	@EditDate					datetime out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucBaoCao where Ma = @Ma and ID <> @ID;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @ReportProcedureName is null or LTRIM(RTRIM(@ReportProcedureName)) = ''
	begin
		raiserror(N'Tên store báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@ReportProcedureName) > 255
	begin
		raiserror(N'Tên store báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if @FixedColumnList is not null and LTRIM(RTRIM(@FixedColumnList)) > 255
	begin
		raiserror(N'Danh sách cột fixed không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;
	
	if @KhoGiay is null
	begin
		raiserror(N'Khổ giấy in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @KhoGiay < 1 or @KhoGiay > 2
	begin
		raiserror(N'Khổ giấy in báo cáo chỉ nhận giá trị 1 (A4) hoặc 2 (A3)!', 16, 1);
		return;
	end;

	if @KhoGiay is null
	begin
		raiserror(N'Khổ giấy in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @KhoGiay < 1 or @KhoGiay > 2
	begin
		raiserror(N'Khổ giấy in báo cáo chỉ nhận giá trị 1 (A4) hoặc 2 (A3)!', 16, 1);
		return;
	end;

	if @HuongIn is null
	begin
		raiserror(N'Hướng in báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if @HuongIn < 1 or @HuongIn > 2
	begin
		raiserror(N'Hướng in báo cáo chỉ nhận giá trị 1 (Dọc) hoặc 2 (Ngang)!', 16, 1);
		return;
	end;

	if @ChucDanhKy is not null and LTRIM(RTRIM(@ChucDanhKy)) > 255
	begin
		raiserror(N'Chức danh kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @DienGiaiKy is not null and LTRIM(RTRIM(@DienGiaiKy)) > 255
	begin
		raiserror(N'Diễn giải kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @TenNguoiKy is not null and LTRIM(RTRIM(@TenNguoiKy)) > 255
	begin
		raiserror(N'Tên người kí không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @FileInMau is not null and LTRIM(RTRIM(@FileInMau)) > 255
	begin
		raiserror(N'Tên file mẫu in không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @FileExcelMau is not null and LTRIM(RTRIM(@FileExcelMau)) > 255
	begin
		raiserror(N'Tên file excel mẫu không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @SheetExcelMau is not null and LTRIM(RTRIM(@SheetExcelMau)) > 255
	begin
		raiserror(N'Tên sheet excel mẫu không được dài hơn 255 kí tự!', 16, 1);
		return;
	end;

	if @SoDongBatDau is not null and (@SoDongBatDau < 0 or @SoDongBatDau > 255)
	begin
		raiserror(N'Số dòng bắt đầu phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if @IDDanhMucBaoCaoThamChieu is not null
	begin
		select @countID = count(ID) from DanhMucBaoCao where ID = @IDDanhMucBaoCaoThamChieu;
		if @countID = 0
		begin
			set @ErrMsg = N'Mã báo cáo tham chiếu không tồn tại!'
			raiserror(@ErrMsg, 16, 1);
			return;
		end;
	end;

	if @IDDanhMucNhomBaoCao is null
	begin
		set @ErrMsg = N'Mã nhóm báo cáo không được bỏ trống!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucNhomBaoCao where ID = @IDDanhMucNhomBaoCao;
	if @countID = 0
	begin
		set @ErrMsg = N'Mã nhóm báo cáo không tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

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
			FileInMau = @FileInMau,
			FileExcelMau = @FileExcelMau,
			SheetExcelMau = @SheetExcelMau,
			SoDongBatDau = @SoDongBatDau,
			ThamChieuChungTu = @ThamChieuChungTu,
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
alter procedure Delete_DanhMucBaoCao
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
alter procedure List_DanhMucBaoCaoCot
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
alter procedure Insert_DanhMucBaoCaoCot
	@ID					bigint out,
	@IDDanhMucBaoCao	bigint = null,
	@Ma					nvarchar(128) = null,
	@Ten				nvarchar(255) = null,
	@ColumnWidth		float = null,
	@HeaderHeight		float = null,
	@TenNhomCot			nvarchar(255) = null,
	@ThuTu				tinyint = null,
	@TenCotExcel		nvarchar(2) = null,
	@KieuDuLieu			tinyint = null,
	@CreateDate			datetime out
as
begin
	set nocount on;

	declare @ErrMsg nvarchar(max), @countID int;

	if @IDDanhMucBaoCao is null
	begin
		set @ErrMsg = N'Mã báo cáo không được phép bỏ trống!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;
	select @countID = count(ID) from DanhMucBaoCao where ID = @IDDanhMucBaoCao;
	if @countID = 0
	begin
		set @ErrMsg = N'Mã báo cáo ' + @Ma +  N' không tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;
	
	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã cột báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã cột báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucBaoCaoCot where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã cột báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên cột báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên cột báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if (@ColumnWidth is null) or @ColumnWidth = 0
	begin
		raiserror(N'Độ rộng cột báo cáo không được bỏ trống hoặc bằng 0!', 16, 1);
		return;
	end;

	if (@HeaderHeight is null) or @HeaderHeight = 0
	begin
		raiserror(N'Chiều cao tiêu đề cột báo cáo không được bỏ trống hoặc bằng 0!', 16, 1);
		return;
	end;

	if (@TenNhomCot is null) or len(@TenNhomCot) > 255
	begin
		raiserror(N'Tên nhóm cột báo cáo không được dài quá 255 kí tự!', 16, 1);
		return;
	end;

	if (@ThuTu is null) or @ThuTu < 0 or @ThuTu > 255
	begin
		raiserror(N'Thứ tự cột báo cáo phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if (@TenCotExcel is null) or len(@TenCotExcel) > 255
	begin
		raiserror(N'Tên cột excel không được dài quá 255 kí tự!', 16, 1);
		return;
	end;

	if (@ThuTu is null) or @ThuTu < 0 or @ThuTu > 5
	begin
		raiserror(N'Thứ tự cột báo cáo phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if (@KieuDuLieu is null) or @KieuDuLieu < 1 or @KieuDuLieu > 5
	begin
		raiserror(N'Kiểu dữ liệu cột chỉ được nhận các giá trị: 1 (Text), 2 (Ngày tháng), 3: (Số nguyên), 4: (Số thực), 5: (Check)!', 16, 1);
		return;
	end;

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
alter procedure Update_DanhMucBaoCaoCot
	@ID				bigint,
	@Ma				nvarchar(128) = null,
	@Ten			nvarchar(255) = null,
	@ColumnWidth	float = null,
	@HeaderHeight	float = null,
	@TenNhomCot		nvarchar(255) = null,
	@ThuTu			tinyint = null,
	@TenCotExcel	nvarchar(2) = null,
	@KieuDuLieu		tinyint = null,
	@EditDate		datetime out
as
begin
	set nocount on;

	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã cột báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã cột báo cáo không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucBaoCaoCot where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã cột báo cáo ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên cột báo cáo không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên cột báo cáo không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	if (@ColumnWidth is null) or @ColumnWidth = 0
	begin
		raiserror(N'Độ rộng cột báo cáo không được bỏ trống hoặc bằng 0!', 16, 1);
		return;
	end;

	if (@HeaderHeight is null) or @HeaderHeight = 0
	begin
		raiserror(N'Chiều cao tiêu đề cột báo cáo không được bỏ trống hoặc bằng 0!', 16, 1);
		return;
	end;

	if (@TenNhomCot is null) or len(@TenNhomCot) > 255
	begin
		raiserror(N'Tên nhóm cột báo cáo không được dài quá 255 kí tự!', 16, 1);
		return;
	end;

	if (@ThuTu is null) or @ThuTu < 0 or @ThuTu > 255
	begin
		raiserror(N'Thứ tự cột báo cáo phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if (@TenCotExcel is null) or len(@TenCotExcel) > 255
	begin
		raiserror(N'Tên cột excel không được dài quá 255 kí tự!', 16, 1);
		return;
	end;

	if (@ThuTu is null) or @ThuTu < 0 or @ThuTu > 5
	begin
		raiserror(N'Thứ tự cột báo cáo phải nằm trong khoảng từ 0 đến 255!', 16, 1);
		return;
	end;

	if (@KieuDuLieu is null) or @KieuDuLieu < 1 or @KieuDuLieu > 5
	begin
		raiserror(N'Kiểu dữ liệu cột chỉ được nhận các giá trị: 1 (Text), 2 (Ngày tháng), 3: (Số nguyên), 4: (Số thực), 5: (Check)!', 16, 1);
		return;
	end;
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
alter procedure Delete_DanhMucBaoCaoCot
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
alter procedure GetMa_DanhMucBaoCao_ByID
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
