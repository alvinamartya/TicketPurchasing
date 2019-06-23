USE [TicketPurchasing]
GO

/****** Object:  StoredProcedure [dbo].[sp_view_transaction_customer_seat]    Script Date: 23-Jun-19 4:09:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_view_transaction_customer_seat]
@ticketID nchar(6)
as
begin
SELECT
	dt.CabinType as 'cabin',
	dt.SeatNumber as 'seat',
	c.Name as 'name',
	c.PassportNumber as 'passport',
	c.ID
FROM DetailTickets dt
JOIN Customers c on dt.CustomerID = c.ID
WHERE dt.TicketID = @ticketID
end
GO

