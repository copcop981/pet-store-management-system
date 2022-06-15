dbcc checkident ('[Userr]', reseed, 0)
dbcc checkident ('[Customer]', reseed, 0)
dbcc checkident ('[Product]', reseed, 0)
dbcc checkident ('[Cash]', reseed, 0)
dbcc checkident ('[TemporaryData]', reseed, 0)

delete dbo.Userr
delete dbo.Product
delete dbo.Customer
delete dbo.Cash
delete dbo.TemporaryData

select * from dbo.Userr
select * from dbo.Customer
select * from dbo.Product
select * from dbo.Cash
select * from dbo.TemporaryData

insert dbo.Userr values(N'admin', N'Đà Nẵng, Việt Nam', '0905111459', 'Administrator', '1999-09-09', 'admin')
insert dbo.Userr values(N'cashier', N'Đà Nẵng, Việt Nam', '', 'Cashier', '2011/4/19', 'cashier')
insert dbo.Userr values(N'employee', N'Đà Nẵng, Việt Nam', '', 'Employee', '2020-3-21', '')
insert dbo.Userr values(N'employee2', N'Đà Nẵng, Việt Nam', '', 'Employee', '2020-3-21', '')

insert dbo.Customer values (N'Lê Bảo Phúc', N'Đà Nẵng, Việt Nam', '0905111459')
insert dbo.Customer values (N'Hoàng Trọng Quân', N'Đà Nẵng, Việt Nam', '')
insert dbo.Customer values (N'Nguyễn Đặng Hoàng Lâm', N'Đà Nẵng, Việt Nam', '')

insert dbo.Product values (N'Pug', N'Pug', N'Dog', 10, 10000)
insert dbo.Product values (N'Cỏ', N'Cỏ', N'Dog', 5, 10000)
insert dbo.Product values (N'Betta', N'Betta', N'Fish', 10, 20000)

SELECT CashId, TransactionNo, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier 
                                    FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid 
                                    WHERE TransactionNo LIKE '%%'
select Cid from dbo.Customer where Cname = N'Lê Bảo Phúc'

select * from dbo.Userr where Role = 'Employee'

create trigger total
on dbo.Cash
for insert, update, delete
as
begin
	update dbo.Cash set Total = Quantity * Price
end

create trigger total2
on dbo.TemporaryData
for insert, update, delete
as
begin
	update dbo.TemporaryData set Total = Quantity * Price
end

insert dbo.TemporaryData values ('11', '11', '11', 5, 20000, 0, 1, '1')
insert dbo.Cash values ('11', '11', '11', 7, 8000, 0, 1, '1')


create proc getAll
as
begin
	select * from Userr
end

exec dbo.GetAll



