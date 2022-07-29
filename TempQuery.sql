dbcc checkident ('[UserRole]', reseed, 0)
dbcc checkident ('[Userr]', reseed, 0)
dbcc checkident ('[Category]', reseed, 0)
dbcc checkident ('[Product]', reseed, 0)
dbcc checkident ('[Customer]', reseed, 0)
dbcc checkident ('[Cash]', reseed, 0)
dbcc checkident ('[TemporaryData]', reseed, 0)
dbcc checkident ('[Revenue]', reseed, 0)

delete dbo.UserRole
delete dbo.Userr
delete dbo.Category
delete dbo.Product
delete dbo.Customer
delete dbo.Cash
delete dbo.TemporaryData
delete dbo.Revenue

select * from dbo.UserRole
select * from dbo.Userr
select * from dbo.Category
select * from dbo.Product
select * from dbo.Customer
select * from dbo.Cash
select * from dbo.TemporaryData
select * from dbo.Revenue

select * from dbo.Revenue where Date_Time between '17-Jul-22' and '18-Jul/22'
select * from dbo.Revenue where Date_Time between '17-Jul-22' and DATEADD(day, 1, '19-Jul-22')

select * from dbo.Userr where role = N'Administrator'

select * from dbo.Product where Pcategory = N'Bird'

insert dbo.UserRole values (N'All')
insert dbo.UserRole values (N'Administrator')
insert dbo.UserRole values (N'Cashier')
insert dbo.UserRole values (N'Employee')

insert dbo.Userr values(N'admin', N'Đà Nẵng, Việt Nam', '0905111459', 'Administrator', '1999-09-09', 'admin')
insert dbo.Userr values(N'cashier', N'Đà Nẵng, Việt Nam', '', 'Cashier', '2011-4-19', 'cashier')
insert dbo.Userr values(N'employee', N'Đà Nẵng, Việt Nam', '', 'Employee', '2020-3-21', '')
insert dbo.Userr values(N'employee2', N'Đà Nẵng, Việt Nam', '', 'Employee', '2020-3-21', '')

insert dbo.Customer values (N'Lê Bảo Phúc', N'Đà Nẵng, Việt Nam', '0905111459')
insert dbo.Customer values (N'Hoàng Trọng Quân', N'Đà Nẵng, Việt Nam', '0763668789')
insert dbo.Customer values (N'Nguyễn Đặng Hoàng Lâm', N'Đà Nẵng, Việt Nam', '0903335365')

insert dbo.Category values (N'All')
insert dbo.Category values (N'Dog')
insert dbo.Category values (N'Cat')
insert dbo.Category values (N'Fish')
insert dbo.Category values (N'Bird')

insert dbo.Product values (N'Betta', N'Betta', N'Fish', 300, 30000)
insert dbo.Product values (N'Goldfish', N'Goldfish', N'Fish', 100, 20000)
insert dbo.Product values (N'Angelfish', N'Angelfish', N'Fish', 100, 20000)
insert dbo.Product values (N'Wakin Goldfish', N'Goldfish', N'Fish', 200, 30000)
insert dbo.Product values (N'Half Black Angelfish', N'Angelfish', N'Fish', 300, 40000)

insert dbo.Product values (N'Autralian Silky Terrier', N'Terrier', N'Dog', 50, 50000)
insert dbo.Product values (N'Autralian Terrier', N'Terrier', N'Dog', 100, 40000)
insert dbo.Product values (N'German Shepherds', N'Becgie', N'Dog', 200, 50000)
insert dbo.Product values (N'Labrador Retriver', N'Retriver', N'Dog', 250, 50000)

insert dbo.Product values (N'Mumbai Cat', N'Cat', N'Cat', 50, 50000)
insert dbo.Product values (N'The American Bobtail', N'Cat', N'Cat', 200, 40000)

insert dbo.Product values (N'Parrotlets', N'Bird', N'Bird', 100, 70000)
insert dbo.Product values (N'Hyacinth Macaws', N'Bird', N'Bird', 200, 50000)
insert dbo.Product values (N'Quaker', N'Bird', N'Bird', 100, 30000)
insert dbo.Product values (N'Cockatoo', N'Bird', N'Bird', 400, 60000)
insert dbo.Product values (N'Conure', N'Bird', N'Bird', 300, 40000)

update dbo.Product set Pquantity = Pquantity - 1 where Pid = 7

select isnull(sum(Pquantity), 0) from dbo.Product where Pcategory = N'Dog'

SELECT CashId, TransactionNo, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier 
FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid 
WHERE TransactionNo LIKE '%%'

--SELECT CashId, TransactionNo, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier 
--FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid 
--WHERE TransactionNo LIKE '%%'

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

create trigger total3
on dbo.Revenue
for insert, update, delete
as
begin
	update dbo.Revenue set Total = Quantity * Price
end

insert dbo.TemporaryData values ('11', '11', '11', 5, 20000, 0, 1, '1')
insert dbo.Cash values ('11', '11', '11', 7, 8000, 0, 1, '1')


create proc getAll
as
begin
	select * from Userr
end

exec dbo.GetAll





