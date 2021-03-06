
/*
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
create procedure Delete_AutoID
	@ID bigint
as
begin
	set nocount on;
	delete AutoID where ID = @ID;
end
go
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
create procedure List_DanhMucDonVi
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, CreateDate, EditDate from DanhMucDonVi where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
create procedure Insert_DanhMucDonVi
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
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucDonVi';
		set @CreateDate = GETDATE();
		insert DanhMucDonVi (ID, Ma, Ten, CreateDate) values (@ID, @Ma, @Ten, @CreateDate);
		--Thêm vào danh mục phân quyền
		declare @IDChiTiet bigint;
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucPhanQuyen;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenDonVi @ID = null, @IDDanhMucPhanQuyen = @IDChiTiet, @IDDanhMucDonVi = @ID, @Xem = 0, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE();
		raiserror(@ErrMsg, 16, 1);
	end catch
end
go
create procedure Update_DanhMucDonVi
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
		update DanhMucDonVi set
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
create procedure Delete_DanhMucDonVi
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenDonVi where IDDanhMucDonVi = @ID;
		delete DanhMucDonVi	where ID = @ID;
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
-----------------
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
-----------------
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
-----------------
create procedure List_DanhMucLoaiDoiTuong
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, TenBangDuLieu, CreateDate, EditDate from DanhMucLoaiDoiTuong where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
create procedure List_DanhMucLoaiDoiTuong_ValidMa
	@Ma nvarchar(128)
as
begin
	set nocount on;
	if @Ma is null set @Ma = '%' else set @Ma = '%' + @Ma + '%';
	select ID, Ma, Ten, TenBangDuLieu, CreateDate, EditDate from DanhMucLoaiDoiTuong where Ma like @Ma order by Ma;
end
go
create procedure Insert_DanhMucLoaiDoiTuong
	@ID				bigint out,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@TenBangDuLieu	nvarchar(128),
	@CreateDate		datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucLoaiDoiTuong';
		insert DanhMucLoaiDoiTuong (ID, Ma, Ten, TenBangDuLieu, CreateDate) values (@ID, @Ma, @Ten, @TenBangDuLieu, @CreateDate);
		--Thêm vào danh mục phân quyền
		declare @IDChiTiet bigint;
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucPhanQuyen;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenLoaiDoiTuong @ID = null, @IDDanhMucPhanQuyen = @IDChiTiet, @IDDanhMucLoaiDoiTuong = @ID, @Xem = 0, @Them = 0, @Sua = 0, @Xoa = 0, @CreateDate = null;
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
create procedure Update_DanhMucLoaiDoiTuong
	@ID				bigint,
	@Ma				nvarchar(128),
	@Ten			nvarchar(255),
	@TenBangDuLieu	nvarchar(128),
	@EditDate		datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucLoaiDoiTuong set
			Ma = @Ma,
			Ten = @Ten,
			TenBangDuLieu = @TenBangDuLieu,
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
create procedure Delete_DanhMucLoaiDoiTuong
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenLoaiDoiTuong where IDDanhMucLoaiDoiTuong = @ID;
		delete DanhMucLoaiDoiTuong	where ID = @ID;
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
create procedure Get_DanhMucLoaiDoiTuong_TenBangDuLieu
	@ID bigint,
	@TenBangDuLieu nvarchar(128) out
as
begin
	set nocount on;
	select @TenBangDuLieu = TenBangDuLieu from DanhMucLoaiDoiTuong where ID = @ID;
end
go
create procedure Get_DanhMucLoaiDoiTuong_ID
	@Ma nvarchar(128),
	@ID bigint out
as
begin
	set nocount on;
	select @ID = ID from DanhMucLoaiDoiTuong where Ma = @Ma;
end
go
create procedure Get_DanhMucLoaiDoiTuong_Ma
	@ID bigint,
	@Ma nvarchar(128) out
as
begin
	set nocount on;
	select @Ma = Ma from DanhMucLoaiDoiTuong where ID = @ID;
end
go
-----------------
create procedure List_DanhMucPhanQuyen
	@ID	bigint = null
as
begin
	set nocount on;
	select	a.ID, a.Ma, a.Ten, a.CreateDate, a.EditDate from DanhMucPhanQuyen a where case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) order by Ma;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucDonVi, b.Ma MaDanhMucDonVi, b.Ten TenDanhMucDonVi,
			a.Xem,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenDonVi a inner join DanhMucDonVi b on a.IDDanhMucDonVi = b.ID where case when @ID is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@ID, 0);
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucLoaiDoiTuong, b.Ma MaDanhMucLoaiDoiTuong, b.Ten TenDanhMucLoaiDoiTuong,
			a.Xem,
			a.Them,
			a.Sua,
			a.Xoa,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenLoaiDoiTuong a inner join DanhMucLoaiDoiTuong b on a.IDDanhMucLoaiDoiTuong = b.ID where case when @ID is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@ID, 0)
	order by b.Ma;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucChungTu, b.Ma MaDanhMucChungTu, b.Ten TenDanhMucChungTu,
			a.Xem,
			a.Them,
			a.Sua,
			a.Xoa,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenChungTu a inner join DanhMucChungTu b on a.IDDanhMucChungTu = b.ID where case when @ID is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@ID, 0)
	order by b.Ma;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucBaoCao, b.Ma MaDanhMucBaoCao, b.Ten TenDanhMucBaoCao,
			a.Xem,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenBaoCao a inner join DanhMucBaoCao b on a.IDDanhMucBaoCao = b.ID where case when @ID is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@ID, 0)
	order by b.Ma;
end
go
create procedure Insert_DanhMucPhanQuyen
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
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucPhanQuyen';
		insert DanhMucPhanQuyen (ID, Ma, Ten, CreateDate) values (@ID, @Ma, @Ten, @CreateDate);
		--thiết lập sẵn full quyền
		declare @IDChiTiet bigint;
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucDonVi;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenDonVi @ID = null, @IDDanhMucPhanQuyen = @ID, @IDDanhMucDonVi = @IDChiTiet, @Xem = 1, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
		--
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucChungTu;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenChungTu @ID = null, @IDDanhMucPhanQuyen = @ID, @IDDanhMucChungTu = @IDChiTiet, @Xem = 1, @Them = 1, @Sua = 1, @Xoa = 1, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
		--
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucLoaiDoiTuong;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenLoaiDoiTuong @ID = null, @IDDanhMucPhanQuyen = @ID, @IDDanhMucLoaiDoiTuong = @IDChiTiet, @Xem = 1, @Them = 1, @Sua = 1, @Xoa = 1, @CreateDate = null;
			fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		end;
		deallocate curPhanQuyenChiTiet;
		--
		declare curPhanQuyenChiTiet cursor for select ID from DanhMucBaoCao;
		open curPhanQuyenChiTiet
		fetch next from curPhanQuyenChiTiet into @IDChiTiet;
		while @@fetch_status = 0
		begin
			exec Insert_DanhMucPhanQuyenBaoCao @ID = null, @IDDanhMucPhanQuyen = @ID, @IDDanhMucBaoCao = @IDChiTiet, @Xem = 1, @CreateDate = null;
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
create procedure Update_DanhMucPhanQuyen
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
		update DanhMucPhanQuyen set
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
create procedure Delete_DanhMucPhanQuyen
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenBaoCao	where IDDanhMucPhanQuyen = @ID;
		delete DanhMucPhanQuyenChungTu	where IDDanhMucPhanQuyen = @ID;
		delete DanhMucPhanQuyenLoaiDoiTuong	where IDDanhMucPhanQuyen = @ID;
		delete DanhMucPhanQuyenDonVi	where IDDanhMucPhanQuyen = @ID;
		delete DanhMucPhanQuyen	where ID = @ID;
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
create procedure List_DanhMucPhanQuyenDonVi
	@ID	bigint = null,
	@IDDanhMucPhanQuyen	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucDonVi, b.Ma MaDanhMucDonVi, b.Ten TenDanhMucDonVi,
			a.Xem,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenDonVi a inner join DanhMucDonVi b on a.IDDanhMucDonVi = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucPhanQuyen is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@IDDanhMucPhanQuyen, 0)
end
go
create procedure Insert_DanhMucPhanQuyenDonVi
	@ID					bigint out,
	@IDDanhMucPhanQuyen	bigint,
	@IDDanhMucDonVi		bigint,
	@Xem				bit,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucPhanQuyenDonVi';
		insert DanhMucPhanQuyenDonVi (ID, IDDanhMucPhanQuyen, IDDanhMucDonVi, Xem, CreateDate) values (@ID, @IDDanhMucPhanQuyen, @IDDanhMucDonVi, @Xem, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucPhanQuyenDonVi
	@ID			bigint,
	@Xem		bit,
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucPhanQuyenDonVi set
			Xem = @Xem,
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
create procedure Delete_DanhMucPhanQuyenDonVi
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenDonVi	where IDDanhMucPhanQuyen = @ID;
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
create procedure List_DanhMucPhanQuyenLoaiDoiTuong
	@ID	bigint = null,
	@IDDanhMucPhanQuyen	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucLoaiDoiTuong, b.Ma MaDanhMucLoaiDoiTuong, b.Ten TenDanhMucLoaiDoiTuong,
			a.Xem,
			a.Them,
			a.Sua,
			a.Xoa,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenLoaiDoiTuong a inner join DanhMucLoaiDoiTuong b on a.IDDanhMucLoaiDoiTuong = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucPhanQuyen is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@IDDanhMucPhanQuyen, 0)
end
go
create procedure Insert_DanhMucPhanQuyenLoaiDoiTuong
	@ID						bigint out,
	@IDDanhMucPhanQuyen		bigint,
	@IDDanhMucLoaiDoiTuong	bigint,
	@Xem					bit,
	@Them					bit,
	@Sua					bit,
	@Xoa					bit,
	@CreateDate				datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucPhanQuyenLoaiDoiTuong';
		insert DanhMucPhanQuyenLoaiDoiTuong(ID, IDDanhMucPhanQuyen, IDDanhMucLoaiDoiTuong, Xem, Them, Sua, Xoa, CreateDate) values (@ID, @IDDanhMucPhanQuyen, @IDDanhMucLoaiDoiTuong, @Xem, @Them, @Sua, @Xoa, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucPhanQuyenLoaiDoiTuong
	@ID			bigint,
	@Xem		bit,
	@Them		bit,
	@Sua		bit,
	@Xoa		bit,
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucPhanQuyenLoaiDoiTuong set
			Xem = @Xem,
			Them = @Them,
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
create procedure Delete_DanhMucPhanQuyenLoaiDoiTuong
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenLoaiDoiTuong	where IDDanhMucPhanQuyen = @ID;
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
create procedure List_DanhMucPhanQuyenChungTu
	@ID	bigint = null,
	@IDDanhMucPhanQuyen	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucChungTu, b.Ma MaDanhMucChungTu, b.Ten TenDanhMucChungTu,
			a.Xem,
			a.Them,
			a.Sua,
			a.Xoa,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenChungTu a inner join DanhMucChungTu b on a.IDDanhMucChungTu = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucPhanQuyen is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@IDDanhMucPhanQuyen, 0)
end
go
create procedure Insert_DanhMucPhanQuyenChungTu
	@ID					bigint out,
	@IDDanhMucPhanQuyen	bigint,
	@IDDanhMucChungTu	bigint,
	@Xem				bit,
	@Them				bit,
	@Sua				bit,
	@Xoa				bit,
	@CreateDate			datetime out	
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucPhanQuyenChungTu';
		insert DanhMucPhanQuyenChungTu (ID, IDDanhMucPhanQuyen, IDDanhMucChungTu, Xem, Them, Sua, Xoa, CreateDate) values (@ID, @IDDanhMucPhanQuyen, @IDDanhMucChungTu, @Xem, @Them, @Sua, @Xoa, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucPhanQuyenChungTu
	@ID			bigint,
	@Xem		bit,
	@Them		bit,
	@Sua		bit,
	@Xoa		bit,
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucPhanQuyenChungTu set
			Xem = @Xem,
			Them = @Them,
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
create procedure Delete_DanhMucPhanQuyenChungTu
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenChungTu	where IDDanhMucPhanQuyen = @ID;
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
create procedure List_DanhMucPhanQuyenBaoCao
	@ID	bigint = null,
	@IDDanhMucPhanQuyen	bigint = null
as
begin
	set nocount on;
	select	a.ID,
			a.IDDanhMucPhanQuyen,
			a.IDDanhMucBaoCao, b.Ma MaDanhMucBaoCao, b.Ten TenDanhMucBaoCao,
			a.Xem,
			a.CreateDate,
			a.EditDate
	from DanhMucPhanQuyenBaoCao a inner join DanhMucBaoCao b on a.IDDanhMucBaoCao = b.ID 
	where	case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0)
			and case when @IDDanhMucPhanQuyen is not null then a.IDDanhMucPhanQuyen else 0 end = ISNULL(@IDDanhMucPhanQuyen, 0)
end
go
create procedure Insert_DanhMucPhanQuyenBaoCao
	@ID					bigint out,
	@IDDanhMucPhanQuyen	bigint,
	@IDDanhMucBaoCao	bigint,
	@Xem				bit,
	@CreateDate			datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucPhanQuyenBaoCao';
		insert DanhMucPhanQuyenBaoCao (ID, IDDanhMucPhanQuyen, IDDanhMucBaoCao, Xem, CreateDate) values (@ID, @IDDanhMucPhanQuyen, @IDDanhMucBaoCao, @Xem, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucPhanQuyenBaoCao
	@ID			bigint,
	@Xem		bit,
	@EditDate	datetime out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucPhanQuyenBaoCao set
			Xem = @Xem,
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
create procedure Delete_DanhMucPhanQuyenBaoCao
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucPhanQuyenBaoCao	where IDDanhMucPhanQuyen = @ID;
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
create procedure Get_DanhMucPhanQuyenLoaiDoiTuong
	@IDDanhMucPhanQuyen		bigint,
	@IDDanhMucLoaiDoiTuong	bigint,
	@Xem					bit = 0 out,
	@Them					bit = 0 out,
	@Sua					bit = 0 out,
	@Xoa					bit = 0 out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @Xem = isnull(Xem, 0), @Them = isnull(Them, 0), @Sua = isnull(Sua, 0), @Xoa = isnull(Xoa, 0) from DanhMucPhanQuyenLoaiDoiTuong 
			where IDDanhMucPhanQuyen = @IDDanhMucPhanQuyen and IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Get_DanhMucPhanQuyenChungTu
	@IDDanhMucPhanQuyen		bigint,
	@IDDanhMucChungTu		bigint,
	@Xem					bit = 0 out,
	@Them					bit = 0 out,
	@Sua					bit = 0 out,
	@Xoa					bit = 0 out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @Xem = isnull(Xem, 0), @Them = isnull(Them, 0), @Sua = isnull(Sua, 0), @Xoa = isnull(Xoa, 0) from DanhMucPhanQuyenChungTu 
			where IDDanhMucPhanQuyen = @IDDanhMucPhanQuyen and IDDanhMucChungTu = @IDDanhMucChungTu;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Get_DanhMucPhanQuyenBaoCao
	@IDDanhMucPhanQuyen		bigint,
	@IDDanhMucBaoCao		bigint,
	@Xem					bit = 0 out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @Xem = isnull(Xem, 0) from DanhMucPhanQuyenBaoCao where IDDanhMucPhanQuyen = @IDDanhMucPhanQuyen and IDDanhMucBaoCao = @IDDanhMucBaoCao;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Get_DanhMucPhanQuyenDonVi
	@IDDanhMucPhanQuyen		bigint,
	@IDDanhMucDonVi			bigint,
	@Xem					bit = 0 out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @Xem = isnull(Xem, 0) from DanhMucPhanQuyenDonVi where IDDanhMucPhanQuyen = @IDDanhMucPhanQuyen and IDDanhMucDonVi = @IDDanhMucDonVi;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
-----------------
create procedure List_DanhMucNguoiSuDung
	@ID bigint = null
as
begin
	set nocount on;
	select a.ID, a.Ma, a.Ten, a.Password, a.isAdmin, a.IDDanhMucPhanQuyen, b.Ma MaDanhMucPhanQuyen, b.Ten TenDanhMucPhanQuyen, a.CreateDate, a.EditDate 
	from DanhMucNguoiSuDung a inner join DanhMucPhanQuyen b on a.IDDanhMucPhanQuyen = b.ID where case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) order by a.Ma;
end
go
create procedure List_DanhMucNguoiSuDung_ValidMa
	@Ma nvarchar(128) = null
as
begin
	set nocount on;
	if @Ma is null set @Ma = '%' else set @Ma = '%' + @Ma + '%';
	select
		a.ID, 
		a.Ma, 
		a.Ten
	from DanhMucNguoiSuDung a where a.Ma like @Ma;
end
go
create procedure Insert_DanhMucNguoiSuDung
	@ID					bigint out,
	@IDDanhMucPhanQuyen	bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@Password			nvarchar(128),
	@isAdmin			bit,
	@CreateDate			datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucNguoiSuDung';
		set @CreateDate = GETDATE();
		insert DanhMucNguoiSuDung (ID, IDDanhMucPhanQuyen, Ma, Ten, Password, isAdmin, CreateDate) values (@ID, @IDDanhMucPhanQuyen, @Ma, @Ten, @Password, @isAdmin, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucNguoiSuDung
	@ID					bigint,
	@IDDanhMucPhanQuyen	bigint,
	@Ma					nvarchar(128),
	@Ten				nvarchar(255),
	@isAdmin			bit,
	@EditDate	datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		set @EditDate = GETDATE();
		update DanhMucNguoiSuDung set
			IDDanhMucPhanQuyen = @IDDanhMucPhanQuyen,
			Ma = @Ma,
			Ten = @Ten,
			isAdmin = @isAdmin,
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
create procedure Delete_DanhMucNguoiSuDung
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucNguoiSuDung	where ID = @ID;
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
create procedure Get_DanhMucNguoiSuDung_ID
	@Ma					nvarchar(128),
	@Password			nvarchar(128),
	@ID					bigint = null out,
	@IDDanhMucPhanQuyen	bigint = null out,
	@isAdmin			bit = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		select @ID = ID, @IDDanhMucPhanQuyen = IDDanhMucPhanQuyen, @isAdmin = ISNULL(isAdmin, 0) from DanhMucNguoiSuDung where UPPER(Ma) = UPPER(@Ma) and CAST(Password as varbinary(max)) = CAST(@Password as varbinary(max));
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucNguoiSuDung_Password
	@ID					bigint,
	@Password			nvarchar(128)
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		update DanhMucNguoiSuDung set
			Password = @Password
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
-----------------
--KHỞI TẠO ĐƠN VỊ VÀ NGƯỜI SỬ DỤNG
exec Insert_DanhMucDonVi null, '001', N'HTM - Quản lý tạm ứng', null
go
exec Insert_DanhMucPhanQuyen null, '001', N'Quản trị hệ thống', null
go
exec Insert_DanhMucNguoiSuDung null, 2, 'sa', N'Quản trị', N'9OVzDVe/3TQ=', 1, null
go
-----------------
create procedure List_NhatKyDuLieu
	@ID bigint = null
as
begin
	set nocount on;
	select	a.ID, 
			a.Ngay, 
			a.Gio, 
			IDDanhMucNguoiSuDung,
			MaDanhMucNguoiSuDung,
			TenDanhMucNguoiSuDung,
			AutoID,
			AutoIDChungTu,
			AutoIDChungTuChiTiet,
			ThaoTac,
			TenBangDuLieu,
			DuLieu,
			DuLieuGoc
	from NhatKyDuLieu a;
end
go
create procedure Insert_NhatKyDuLieu
	@IDDanhMucNguoiSuDung	bigint,
	@MaDanhMucNguoiSuDung	nvarchar(128),
	@TenDanhMucNguoiSuDung	nvarchar(255),
	@AutoID					bigint,				--ID bản ghi sửa
	@AutoIDChungTu			bigint = null,		--ID chứng từ 
	@AutoIDChungTuChiTiet	bigint = null,		--ID chứng từ chi tiết
	@ThaoTac				nvarchar(128),
	@TenBangDuLieu			nvarchar(255),
	@DuLieu					nvarchar(max),
	@DuLieuGoc				nvarchar(max) = null
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	select @TenDanhMucNguoiSuDung = Ten from DanhMucNguoiSuDung where ID = @IDDanhMucNguoiSuDung;
	begin tran
	begin try
		insert into NhatKyDuLieu
		(
			Ngay,
			Gio,
			IDDanhMucNguoiSuDung,
			MaDanhMucNguoiSuDung,
			TenDanhMucNguoiSuDung,
			AutoID,				
			AutoIDChungTu,			
			AutoIDChungTuChiTiet,
			ThaoTac,
			TenBangDuLieu,
			DuLieu,
			DuLieuGoc
		)
		values
		(
			getdate(),
			getdate(),
			@IDDanhMucNguoiSuDung,
			@MaDanhMucNguoiSuDung,
			@TenDanhMucNguoiSuDung,
			@AutoID,				
			@AutoIDChungTu,			
			@AutoIDChungTuChiTiet,	
			@ThaoTac,
			@TenBangDuLieu,
			@DuLieu,
			@DuLieuGoc
		);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
-----------------
create procedure List_DanhMucDoiTuong
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;

	if @SearchStr is not null
	begin
		declare @countID bigint;
		select @countID = count(ID) from DanhMucDoiTuong where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong and Ma = @SearchStr;
		if @countID = 1
		begin
			select a.ID, a.IDDanhMucDonVi, a.IDDanhMucLoaiDoiTuong, a.Ma, a.Ten, 
				a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, a.CreateDate, a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, a.EditDate 
				from DanhMucDoiTuong a inner join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
					left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
			where a.IDDanhMucDonVi = @IDDanhMucDonVi and 
				a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
				and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
				and a.Ma = @SearchStr
			order by a.Ma;
		end;
		else
		begin
			set @SearchStr = '%' + @SearchStr + '%';
			select a.ID, a.IDDanhMucDonVi, a.IDDanhMucLoaiDoiTuong, a.Ma, a.Ten, 
				a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, a.CreateDate, a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, a.EditDate 
				from DanhMucDoiTuong a inner join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
					left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
			where a.IDDanhMucDonVi = @IDDanhMucDonVi and 
				a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
				and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
				and (a.Ma like @SearchStr or a.Ten like @SearchStr)
			order by a.Ma;
		end;
	end;
	else
	begin
		select a.ID, a.IDDanhMucDonVi, a.IDDanhMucLoaiDoiTuong, a.Ma, a.Ten, 
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, a.CreateDate, a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, a.EditDate 
			from DanhMucDoiTuong a inner join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
				left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		where a.IDDanhMucDonVi = @IDDanhMucDonVi and 
			a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
			and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
		order by a.Ma;
	end;
end
go
create procedure List_DanhMucDoiTuong_ValidMa
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint,
	@Ma nvarchar(128) = null
as
begin
	set nocount on;

	if @Ma is null set @Ma = '%' else set @Ma = '%' + @Ma + '%';

	select a.ID, a.IDDanhMucDonVi, a.IDDanhMucLoaiDoiTuong, a.Ma, a.Ten, 
		a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, a.CreateDate, a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, a.EditDate 
		from DanhMucDoiTuong a inner join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and 
		a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and a.Ma like @Ma
	order by a.Ma;
end
go
create procedure Insert_DanhMucDoiTuong
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		declare @CountID bigint;
		select @CountID = count(ID) from DanhMucDoiTuong where Ma = @Ma and IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong and IDDanhMucDonVi = @IDDanhMucDonVi;
		if @CountID > 0
			raiserror(N'Mã đối tượng đã bị trùng !', 16, 1)
		set @CreateDate = GETDATE();
		exec Insert_AutoID @ID out, @TenBangDuLieu = N'DanhMucDoiTuong';
		insert DanhMucDoiTuong (ID, IDDanhMucDonVi, IDDanhMucLoaiDoiTuong, Ma, Ten, IDDanhMucNguoiSuDungCreate, CreateDate) 
			values (@ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, isnull(@Ma, @ID), isnull(@Ten, @ID), @IDDanhMucNguoiSuDungCreate, @CreateDate);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
create procedure Update_DanhMucDoiTuong
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		declare @CountID bigint;
		select @CountID = count(ID) from DanhMucDoiTuong where Ma = @Ma and IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong and IDDanhMucDonVi = @IDDanhMucDonVi and ID <> @ID;
		if @CountID > 0
			raiserror(N'Mã đối tượng đã bị trùng !', 16, 1)
		set @EditDate = GETDATE();
		update DanhMucDoiTuong set
			Ma = isnull(@Ma, @ID),
			Ten = isnull(@Ten, @ID),
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
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
create procedure Delete_DanhMucDoiTuong
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucDoiTuong	where ID = @ID;
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
create procedure Get_DanhMucDoiTuong_ID
	@IDDanhMucLoaiDoiTuong bigint,
	@Ma nvarchar(128),
	@ID bigint out
as
begin
	set nocount on;
	select @ID = ID from DanhMucDoiTuong where IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong and Ma = @Ma;
end
go
-----------------
create procedure List_DanhMucMenu
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
create procedure Insert_DanhMucMenu
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
create procedure Update_DanhMucMenu
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
create procedure Delete_DanhMucMenu
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
create procedure List_DanhMucMenuLoaiDoiTuong
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
create procedure Insert_DanhMucMenuLoaiDoiTuong
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
create procedure Update_DanhMucMenuLoaiDoiTuong
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
create procedure Delete_DanhMucMenuLoaiDoiTuong
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
create procedure List_DanhMucMenuChungTu
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
create procedure Insert_DanhMucMenuChungTu
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
create procedure Update_DanhMucMenuChungTu
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
create procedure Delete_DanhMucMenuChungTu
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
create procedure List_DanhMucMenuBaoCao
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
create procedure Insert_DanhMucMenuBaoCao
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
create procedure Update_DanhMucMenuBaoCao
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
create procedure Delete_DanhMucMenuBaoCao
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
-----------------
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
go
-----------------
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
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------
-----------------

*/






