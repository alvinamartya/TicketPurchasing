USE [TicketPurchasing]
GO

/****** Object:  StoredProcedure [dbo].[sp_update_tickets]    Script Date: 23-Jun-19 4:10:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_update_tickets]
@ticketID nchar(6)
as
begin
update DetailTickets
	set status = 'R'
where TicketID = @ticketID

update Tickets
	set Status = 'R'
where ID = @ticketID

end
GO

