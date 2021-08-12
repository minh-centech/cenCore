---------------NHẬT KÝ DỮ LIỆU
/*
drop table NhatKyDuLieu
create table NhatKyDuLieu
(
	ID						bigint identity(1, 1) not null,
	Ngay					date not null,
	Gio						time not null,
	IDDanhMucNguoiSuDung	bigint,
	MaDanhMucNguoiSuDung	nvarchar(128) not null,
	TenDanhMucNguoiSuDung	nvarchar(255) not null,
	AutoID					bigint not null,	--ID bản ghi sửa
	AutoIDChungTu			bigint,				--ID chứng từ 
	AutoIDChungTuChiTiet	bigint,				--ID chứng từ chi tiết
	ThaoTac					nvarchar(128) not null, 
	TenBangDuLieu			nvarchar(255) not null,
	DuLieu					nvarchar(max) not null,
	DuLieuGoc				nvarchar(max),
	constraint	PK_NhatKyDuLieu primary key (ID),
	constraint	DanhMucNguoiSuDung_NhatKyDuLieu foreign key (IDDanhMucNguoiSuDung) references DanhMucNguoiSuDung(ID)
)
go
*/
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
--create procedure Update_NhatKyDuLieu
--	@ID			bigint,
--	@Ma			nvarchar(128),
--	@Ten		nvarchar(255),
--	@EditDate	datetime = null out
--as
--begin
--	set nocount on;
--	declare @ErrMsg nvarchar(max);
--	begin tran
--	begin try
--		set @EditDate = GETDATE();
--		update NhatKyDuLieu set
--			Ma = @Ma,
--			Ten = @Ten,
--			EditDate = @EditDate
--		where ID = @ID;
--	commit tran
--	end try
--	begin catch
--		if @@TRANCOUNT > 0 rollback tran;
--		select @ErrMsg = ERROR_MESSAGE()
--		raiserror(@ErrMsg, 16, 1)
--	end catch
--end
--go
--create procedure Delete_NhatKyDuLieu
--	@ID			bigint
--as
--begin
--	set nocount on;
--	declare @ErrMsg nvarchar(max);
--	begin tran
--	begin try
--		delete DanhMucPhanQuyenDonVi where IDNhatKyDuLieu = @ID;
--		delete NhatKyDuLieu	where ID = @ID;
--		delete AutoID where ID = @ID;
--	commit tran
--	end try
--	begin catch
--		if @@TRANCOUNT > 0 rollback tran;
--		select @ErrMsg = ERROR_MESSAGE()
--		raiserror(@ErrMsg, 16, 1)
--	end catch
--end