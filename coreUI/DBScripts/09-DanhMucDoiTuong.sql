---------------DANH MỤC LOẠI ĐỐI TƯỢNG
/*
create table DanhMucDoiTuong
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	GhiChu						nvarchar(max),
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucDoiTuong primary key (ID),
	constraint	DanhMucDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucDonVi_DanhMucDoiTuong foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	DanhMucNguoiSuDungCreate_DanhMucDoiTuong foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucDoiTuong foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
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