
use Company
--1--
with Amount as (
select PositionID, count(*) as AmountOfWorkers from ProjectPositions
group by PositionID
)

select a.PositionID, p.PositionName, AmountOfWorkers from Positions p join Amount a on a.PositionID = p.PositionID;

--2--
with Nobody as (
select PositionID from Positions
except
select distinct PositionID from ProjectPositions
)

select n.PositionID, p.PositionName from Nobody n join Positions p on p.PositionID = n.PositionID;

--3--
with PositionsOnProject as
(
select ProjectID, PositionID, count(*) as Amount from ProjectPositions
group by ProjectID, PositionID
)

select p1.ProjectID, p2.ProjectName, p3.PositionName, p1.Amount 
from PositionsOnProject p1 join Projects p2 on p2.ProjectID = p1.ProjectID join Positions p3 on p3.PositionID = p1.PositionID;

--4--
with TaskOnWorker as
(
select ProjectID, EmployeeID, count(*) as Amount from Tasks 
group by ProjectID, EmployeeID
),
 AvgTask as
(
select ProjectID, Avg(Amount) as Amount from TaskOnWorker
group by ProjectID
)
select a.ProjectID,p.ProjectName, a.Amount  from AvgTask a join Projects p on p.ProjectID = a.ProjectID;

--5--
select ProjectID, ProjectName, datediff(day, StartDate, FinishDate) as 'Working time(days)' from Projects;

--6--
with NotClosed as
(
select EmployeeID, count(TaskID) as Amount from Tasks
where TaskID in(
select TaskID from Statuses
where StatusName != 'closed')
group by EmployeeID
),
MinNotClosed as
(
select min(Amount) as MinValue from NotClosed 
)
select n.EmployeeID, m.MinValue from NotClosed n inner join MinNotClosed m on m.MinValue=n.Amount;

--7--
with NotClosed as
(
select EmployeeID, count(TaskID) as Amount from Tasks
where TaskID in(
select TaskID from Statuses
where StatusName != 'closed') and (Term > '2019-01-10')
group by EmployeeID
),
MaxNotClosed as
(
select max(Amount) as MaxValue from NotClosed 
)
select n.EmployeeID, m.MaxValue from NotClosed n inner join MaxNotClosed m on m.MaxValue=n.Amount;

--8--
UPDATE Tasks
SET Term = dateadd(day, 5, Term)
WHERE TaskID IN (select TaskID from Statuses where StatusName != 'closed');

select * from Tasks;

--9--
with OpenedTasks as
(
select  ProjectID , count(TaskID) as Amount from Tasks
where TaskID in (select TaskID from Statuses where StatusName = 'opened')
group by ProjectID
)
select o.ProjectID, p.ProjectName, o.Amount from OpenedTasks o join Projects p on p.ProjectID = o.ProjectID;

--10--
with ProjectTasksCount as (
	select ProjectID, count(*) as Amount from Tasks
	group by ProjectID),
ClosedTasksCount as (
	select ProjectID, count(TaskID) as Closed from Tasks
	where TaskID in(select TaskID from Statuses where StatusName = 'closed')
	group by ProjectID),
LastTasks as (
	select top 1 max(t.Term) as LastClosed, c.ProjectID from Tasks t 
	inner join ClosedTasksCount c on c.ProjectID = t.ProjectID
	inner join ProjectTasksCount a on a.ProjectID = c.ProjectID
	where a.Amount - c.Closed = 0 
	group by c.ProjectID
	order by max(t.Term))
update Projects 
SET Status = 'closed', FinishDate = lt.LastClosed
FROM Projects pr inner join LastTasks lt on pr.ProjectID = lt.ProjectID;

--11--
with AllClosed as (
	select EmployeeID, ProjectID, count(*) as Amount from Tasks
	where TaskID = ALL(select TaskID from Statuses where StatusName = 'closed')
	group by ProjectID, EmployeeID)
select a.ProjectID, a.EmployeeID, e.EmployeeName, e.EmployeeSurname from AllClosed a
inner join Employees e on e.EmployeeID = a.EmployeeID
order by ProjectID, EmployeeID;

--12--
create procedure ChangeWorker
@taskname nvarchar(255)
as
begin
	declare @employee int = ( select top 1 EmployeeID from Tasks
						where EmployeeID is not null
						group by EmployeeID order by count(*) asc )
	update Tasks set EmployeeID = @employee
	where Task = @taskname;
end;

exec ChangeWorker 'download visual studio';