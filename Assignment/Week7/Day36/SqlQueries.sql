--Query1
select ProductName,CategoryName
from Products p join 
Categories c on
p.CategoryID=c.CategoryID

--Query2
select OrderID,CompanyName
from Orders o join
Customers c on 
o.CustomerID=c.CustomerID

--Query3
select ProductName,CompanyName
from Products p join 
Suppliers s on
p.SupplierID=s.SupplierID

--Query4
select OrderID,OrderDate,FirstName
from Orders o join 
Employees e on
o.EmployeeID=e.EmployeeID

--Query5
select OrderID,CompanyName
from Orders o join Shippers s
on o.ShipVia=s.ShipperID
where ShipCountry='France'

--Query6
select CategoryName,Sum(UnitsInStock) as TotalStocks
from Categories c Join 
Products p on c.CategoryID=p.CategoryID
group by CategoryName

--Query7
select CompanyName,Sum(UnitPrice*Quantity) as TotalSpendings
from [Order Details] od join 
Orders o on 
od.OrderID=o.OrderID
join Customers c 
on o.CustomerID=c.CustomerID
group by CompanyName

--Query8
select LastName,Count(OrderID) as TotalOrders
from Employees e join Orders o on 
e.EmployeeID=o.EmployeeID
group by LastName

--Query9
select Sum(Freight) as TotalFreight,CompanyName
from Orders o join 
Shippers s
on o.ShipVia=s.ShipperID
group by CompanyName

--Query10
select top 5  ProductName,Sum(Quantity) as TotalQuantitySold
from Products p join 
[Order Details] od on
p.ProductID=od.ProductID
group by ProductName
order by Sum(Quantity) desc

--Query11
select ProductName
from Products
where UnitPrice> (select avg(UnitPrice) from Products)

-- Query12
select 
    e.FirstName + ' ' + e.LastName as EmployeeName,
    m.FirstName + ' ' + m.LastName as ManagerName
from Employees e
left join Employees m
    on e.ReportsTo = m.EmployeeID

-- Query13
select CompanyName
from Customers c
where not exists (
    select 1
    from Orders o
    where o.CustomerID = c.CustomerID
)

-- Query14
select OrderID
from [Order Details]
group by OrderID
having sum(UnitPrice * Quantity * (1 - Discount)) >
(
    select avg(OrderTotal)
    from (
        select sum(UnitPrice * Quantity * (1 - Discount)) as OrderTotal
        from [Order Details]
        group by OrderID
    ) as OrderTotals
)

-- Query15
select ProductName
from Products p
where not exists (
    select 1
    from [Order Details] od
    join Orders o on od.OrderID = o.OrderID
    where od.ProductID = p.ProductID
    and year(o.OrderDate) > 1997
)

-- Query16
select e.FirstName, e.LastName, r.RegionDescription
from Employees e
join EmployeeTerritories et on e.EmployeeID = et.EmployeeID
join Territories t on et.TerritoryID = t.TerritoryID
join Region r on t.RegionID = r.RegionID

-- Query17
select c.CompanyName as Customer,
       s.CompanyName as Supplier,
       c.City
from Customers c
join Suppliers s on c.City = s.City

-- Query18
select c.CompanyName
from Customers c
join Orders o on c.CustomerID = o.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
group by c.CompanyName
having count(distinct p.CategoryID) > 3

-- Query19
select sum(od.UnitPrice * od.Quantity * (1 - od.Discount)) as TotalRevenue
from [Order Details] od
join Products p on od.ProductID = p.ProductID
where p.Discontinued = 1

-- Query20
select c.CategoryName,
       p.ProductName,
       p.UnitPrice
from Products p
join Categories c on p.CategoryID = c.CategoryID
where p.UnitPrice =
(
    select max(UnitPrice)
    from Products
    where CategoryID = p.CategoryID
)
