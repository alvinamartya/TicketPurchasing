USE [TicketPurchasing]
GO

/****** Object:  StoredProcedure [dbo].[sp_view_transaction_tickets]    Script Date: 23-Jun-19 4:09:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_view_transaction_tickets]
	@bookingRef nchar(6)
as
begin
	SELECT
		c1.Name as 'deptCity',
		c2.Name as 'arrivalCity',
		s.DepartureDate as 'deptDate',
		s.DepartureTime as 'deptTime',
		a.Name as 'airName',
		CAST(ISNULL(s.Price + (s.Price* ad1.addPrice/100),'0')AS money) AS 'EconomyPrice',
		CAST(ISNULL(s.Price + (s.Price* ad2.addPrice/100),'0')AS money) AS 'BusinessPrice',
		CAST(ISNULL(s.Price + (s.Price* ad3.addPrice / 100),'0') as Money) as 'FirstPrice',
		ac.Photo as 'photo',
		t.ID as 'ticketID',
		t.ScheduleID as 'scheduleID',
		a.ID as 'aircraft',
		t.TotalPrice as 'totalPrice'

	FROM Tickets t
	JOIN Schedules s on t.ScheduleID = s.ID
	JOIN Cities c1 on s.DepartureCityID = c1.ID
	JOIN Cities c2 on s.ArrivalCityID = c2.ID
	JOIN Aircrafts a on s.AircraftID = a.ID
	JOIN AircraftCompanies ac on a.AircraftCompanyID = ac.ID
	LEFT JOIN AircraftDetails ad1 on a.ID = ad1.AircraftID AND ad1.CabinType ='Economy Class'
	LEFT JOIN AircraftDetails ad2 on a.ID = ad2.AircraftID AND ad2.CabinType = 'Business Class'
	LEFT JOIN AircraftDetails ad3 on a.ID = ad3.AircraftID AND ad3.CabinType = 'First Class'
	WHERE t.Status = 'P' AND t.BookingRef = @bookingRef
end
GO

