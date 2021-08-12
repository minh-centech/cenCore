---------------DANH MỤC ĐƠN VỊ 2019-12-29 16:12
/*
create table DanhMucNguoiSuDung
(
	ID					bigint			not null,
	IDDanhMucPhanQuyen	bigint			not null,
	Ma					nvarchar(128)	not null,
	Ten					nvarchar(255)	not null,
	Password			nvarchar(128)	not null,
	isAdmin				bit,
	CreateDate			datetime		not null,
	EditDate			datetime,
	constraint	PK_DanhMucNguoiSuDung primary key (ID),
	constraint	DanhMucNguoiSuDung_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucNguoiSuDung unique(Ma),
	constraint	DanhMucPhanQuyen_DanhMucNguoiSuDung foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID)
)
go
*/
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

--KHỞI TẠO ĐƠN VỊ VÀ NGƯỜI SỬ DỤNG
/*
exec Insert_DanhMucDonVi null, '001', N'PAN HAI AN - Dia diem kiem tra tap trung', null
go
exec Insert_DanhMucPhanQuyen null, '001', N'Quản trị hệ thống', null
go
--select * from DanhMucPhanQuyen
exec Insert_DanhMucNguoiSuDung null, 2, 'sa', N'Quản trị', N'9OVzDVe/3TQ=', 1, null
go
---
*/
--select * from DanhMucDonVi