USE [TicketPurchasing]
GO

/****** Object:  StoredProcedure [dbo].[sp_report_period_yearly]    Script Date: 27-Jun-19 3:30:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_report_period_yearly]
@dateStart int,
@dateEnd int
as 
begin

select
	year = DATEPART(YEAR, t.TransactionDate),
	count(case when t.status = 'P' then 1 else null end) as 'ticketPurchased',
	count(case when t.status = 'R' then 1 else null end) as 'ticketRefunded',
	SUM(t.TotalPrice) as 'dayIncome',
	SUM(case when t.Status = 'R' then t.TotalPrice else 0 end) as 'refundedCash',
	(SUM(t.TotalPrice) - SUM(case when t.Status = 'R' then t.TotalPrice else 0 end)) as 'totalDailyIncome'
from Tickets t
group by DATEPART(YEAR, t.TransactionDate)
having DATEPART(YEAR, t.TransactionDate) between @dateStart and @dateEnd
end
GO

