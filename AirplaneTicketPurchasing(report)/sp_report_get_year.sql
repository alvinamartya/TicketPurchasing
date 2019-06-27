USE [TicketPurchasing]
GO

/****** Object:  StoredProcedure [dbo].[sp_report_get_year]    Script Date: 27-Jun-19 3:29:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_report_get_year]
as
begin
select
	distinct(DATEPART(YEAR, transactionDate)) as 'year'
from tickets
end
GO

