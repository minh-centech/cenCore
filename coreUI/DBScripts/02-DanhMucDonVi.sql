---------------DANH MỤC ĐƠN VỊ 2019-12-29 16:12
/*
create table DanhMucDonVi
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucDonVi primary key (ID),
	constraint	DanhMucDonVi_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucDonVi unique(Ma)
)
go
*/
create procedure List_DanhMucDonVi
	@ID bigint = null
as
begin
	set nocount on;
	select ID, Ma, Ten, CreateDate, EditDate from DanhMucDonVi where case when @ID is not null then ID else 0 end = ISNULL(@ID, 0) order by Ma;
end
go
alter procedure Insert_DanhMucDonVi
	@ID			bigint out,
	@Ma			nvarchar(128) = null,
	@Ten		nvarchar(255) = null,
	@CreateDate datetime = null out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã đơn vị không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã đơn vị không được dài quá 128 ký tự!', 16, 1);
		return;
	end;

	select @countID = count(ID) from DanhMucDonVi where Ma = @Ma;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã đơn vị ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên đơn vị không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên đơn vị không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

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
	end catch;
end
go
alter procedure Update_DanhMucDonVi
	@ID			bigint,
	@Ma			nvarchar(128) = null,
	@Ten		nvarchar(255) = null,
	@EditDate	datetime = null out
as
begin
	set nocount on;
	
	declare @ErrMsg nvarchar(max), @countID int;

	if @Ma is null or LTRIM(RTRIM(@Ma)) = ''
	begin
		raiserror(N'Mã đơn vị không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ma) > 128
	begin
		raiserror(N'Mã đơn vị không được dài quá 128 ký tự!', 16, 1);
		return;
	end;
	select @countID = count(ID) from DanhMucDonVi where Ma = @Ma and ID <> @ID;
	if @countID > 0
	begin
		set @ErrMsg = N'Mã đơn vị ' + @Ma +  N' đã tồn tại!'
		raiserror(@ErrMsg, 16, 1);
		return;
	end;
	

	if @Ten is null or LTRIM(RTRIM(@Ten)) = ''
	begin
		raiserror(N'Tên đơn vị không được bỏ trống!', 16, 1);
		return;
	end;
	if len(@Ten) > 255
	begin
		raiserror(N'Tên đơn vị không được dài quá 255 ký tự!', 16, 1);
		return;
	end;

	
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