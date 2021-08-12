---------------DANH MỤC PHÂN QUYỀN 2019=12-29 15:57:00
/*
create table DanhMucPhanQuyen
(
	ID			bigint			not null,
	Ma			nvarchar(128)	not null,
	Ten			nvarchar(255)	not null,
	CreateDate	datetime		not null,
	EditDate	datetime,
	constraint	PK_DanhMucPhanQuyen primary key (ID),
	constraint	DanhMucPhanQuyen_AutoID foreign key (ID) references AutoID(ID),
	constraint	Ma_DanhMucPhanQuyen unique(Ma)
)
go
create table DanhMucPhanQuyenDonVi
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucDonVi		bigint		not null,
	Xem					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenDonVi primary key (ID),
	constraint	DanhMucPhanQuyenDonVi_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenDonVi foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucDonVi_DanhMucPhanQuyenDonVi foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID)
)
go
create table DanhMucPhanQuyenLoaiDoiTuong
(
	ID						bigint		not null,
	IDDanhMucPhanQuyen		bigint		not null,
	IDDanhMucLoaiDoiTuong	bigint		not null,
	Xem						bit,
	Them					bit,
	Sua						bit,
	Xoa						bit,
	CreateDate				datetime	not null,
	EditDate				datetime,
	constraint	PK_DanhMucPhanQuyenLoaiDoiTuong primary key (ID),
	constraint	DanhMucPhanQuyenLoaiDoiTuong_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenLoaiDoiTuong foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucPhanQuyenLoaiDoiTuong foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID)
)
go
create table DanhMucPhanQuyenChungTu
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucChungTu	bigint		not null,
	Xem					bit,
	Them				bit,
	Sua					bit,
	Xoa					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenChungTu primary key (ID),
	constraint	DanhMucPhanQuyenChungTu_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenChungTu foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucChungTu_DanhMucPhanQuyenChungTu foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID)
)
go
create table DanhMucPhanQuyenBaoCao
(
	ID					bigint		not null,
	IDDanhMucPhanQuyen	bigint		not null,
	IDDanhMucBaoCao		bigint		not null,
	Xem					bit,
	CreateDate			datetime	not null,
	EditDate			datetime,
	constraint	PK_DanhMucPhanQuyenBaoCao primary key (ID),
	constraint	DanhMucPhanQuyenBaoCao_AutoID foreign key (ID) references AutoID(ID),
	constraint	DanhMucPhanQuyen_DanhMucPhanQuyenBaoCao foreign key (IDDanhMucPhanQuyen) references DanhMucPhanQuyen(ID),
	constraint	DanhMucBaoCao_DanhMucPhanQuyenBaoCao foreign key (IDDanhMucBaoCao) references DanhMucBaoCao(ID)
)
go
*/
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