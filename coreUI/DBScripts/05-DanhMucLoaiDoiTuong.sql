---------------DANH MỤC LOẠI ĐỐI TƯỢNG
/*
create table DanhMucLoaiDoiTuong
(
	ID				bigint			not null,
	Ma				nvarchar(128)	not null,
	Ten				nvarchar(255)	not null,
	TenBangDuLieu	nvarchar(128)	not null,
	CreateDate		datetime		not null,
	EditDate		datetime,
	constraint		PK_DanhMucLoaiDoiTuong primary key (ID),
	constraint		DanhMucLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint		Ma_DanhMucLoaiDoiTuong unique(Ma)
)
go
*/
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