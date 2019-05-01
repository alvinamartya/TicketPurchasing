CREATE TABLE AircraftAmenities (ID int IDENTITY NOT NULL, AmenitiesID nchar(5) NOT NULL, CabinTypeID int NOT NULL, AircraftID nchar(5) NOT NULL, PRIMARY KEY (ID));
CREATE TABLE AircraftCompanies (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, Address nvarchar(255) NULL, TelpNumber nvarchar(15) NULL, Photo nvarchar(255) NULL, PRIMARY KEY (ID));
CREATE TABLE AircraftDetails (ID int IDENTITY NOT NULL, Price money NULL, AircraftID nchar(5) NOT NULL, CabinTypeID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE Aircrafts (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, AircraftCompanyID nchar(5) NOT NULL, AircraftTypeID nchar(5) NOT NULL, PRIMARY KEY (ID));
CREATE TABLE AircraftTypeDetails (ID int IDENTITY NOT NULL, Seat int NULL, CabinTypeID int NOT NULL, AircraftTypeID nchar(5) NOT NULL, PRIMARY KEY (ID));
CREATE TABLE AircraftTypes (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, MakeMolde nvarchar(100) NULL, TotalSeats int NULL, PRIMARY KEY (ID));
CREATE TABLE Amenities (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, Qty int NULL, Unit nvarchar(100) NULL, PRIMARY KEY (ID));
CREATE TABLE CabinTypes (ID int IDENTITY NOT NULL, Name nvarchar(100) NULL, PRIMARY KEY (ID));
CREATE TABLE Cities (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, CountryID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE Countries (ID int IDENTITY NOT NULL, Name nvarchar(100) NULL, PRIMARY KEY (ID));
CREATE TABLE Customers (ID nchar(5) NOT NULL, Name nvarchar(255) NULL, IdentityNumber nvarchar(50) NULL, PassportNumber nvarchar(20) NULL, DateofBirth date NULL, Sex nchar(1) NULL, Address nvarchar(255) NULL, TelpNumber nvarchar(15) NULL, Email nvarchar(100) NULL, CountryID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE DetailTickets (ID int IDENTITY NOT NULL, SeatNumber int NULL, Price money NULL, TicketID nchar(6) NOT NULL, CustomerID nchar(5) NOT NULL, CabinTypeID int NOT NULL, PRIMARY KEY (ID));
CREATE TABLE Employees (ID nchar(5) NOT NULL, Name nvarchar(100) NULL, Username nvarchar(20) NULL, Password nvarchar(16) NULL, Photo nvarchar(255) NULL, DateofBirth date NULL, Sex nchar(1) NULL, Address nvarchar(255) NULL, TelpNumber nvarchar(15) NULL, Role nvarchar(20) NULL, Status nchar(1) NULL, PRIMARY KEY (ID));
CREATE TABLE RefundDetails (ID int IDENTITY NOT NULL, DateTime datetime NULL, TotalRefund money NULL, RefundID int NOT NULL, TicketID nchar(6) NOT NULL, PRIMARY KEY (ID));
CREATE TABLE Refunds (ID int IDENTITY NOT NULL, Hours int NULL, Reduced money NULL, PRIMARY KEY (ID));
CREATE TABLE Schedules (ID nchar(5) NOT NULL, DepartureDate date NULL, DepartureTime time NULL, Price money NULL, FlightTime int NULL, DepartureCityID nchar(5) NOT NULL, ArrivalCityID nchar(5) NOT NULL, AircraftID nchar(5) NOT NULL, PRIMARY KEY (ID));
CREATE TABLE Tickets (ID nchar(6) NOT NULL, TransactionDate date NULL, BookingRef nchar(6) NULL, Status nchar(1) NULL, EmployeeID nchar(5) NOT NULL, ScheduleID nchar(5) NOT NULL, PRIMARY KEY (ID));
ALTER TABLE RefundDetails ADD CONSTRAINT FKRefundDeta275374 FOREIGN KEY (RefundID) REFERENCES Refunds (ID);
ALTER TABLE RefundDetails ADD CONSTRAINT FKRefundDeta502401 FOREIGN KEY (TicketID) REFERENCES Tickets (ID);
ALTER TABLE Tickets ADD CONSTRAINT FKTickets972020 FOREIGN KEY (EmployeeID) REFERENCES Employees (ID);
ALTER TABLE Customers ADD CONSTRAINT FKCustomers824127 FOREIGN KEY (CountryID) REFERENCES Countries (ID);
ALTER TABLE DetailTickets ADD CONSTRAINT FKDetailTick822072 FOREIGN KEY (TicketID) REFERENCES Tickets (ID);
ALTER TABLE DetailTickets ADD CONSTRAINT FKDetailTick302683 FOREIGN KEY (CustomerID) REFERENCES Customers (ID);
ALTER TABLE Cities ADD CONSTRAINT FKCities975222 FOREIGN KEY (CountryID) REFERENCES Countries (ID);
ALTER TABLE Schedules ADD CONSTRAINT FKSchedules167554 FOREIGN KEY (DepartureCityID) REFERENCES Cities (ID);
ALTER TABLE Schedules ADD CONSTRAINT FKSchedules433980 FOREIGN KEY (ArrivalCityID) REFERENCES Cities (ID);
ALTER TABLE Tickets ADD CONSTRAINT FKTickets626131 FOREIGN KEY (ScheduleID) REFERENCES Schedules (ID);
ALTER TABLE Aircrafts ADD CONSTRAINT FKAircrafts721738 FOREIGN KEY (AircraftCompanyID) REFERENCES AircraftCompanies (ID);
ALTER TABLE AircraftTypeDetails ADD CONSTRAINT FKAircraftTy377547 FOREIGN KEY (CabinTypeID) REFERENCES CabinTypes (ID);
ALTER TABLE AircraftTypeDetails ADD CONSTRAINT FKAircraftTy116729 FOREIGN KEY (AircraftTypeID) REFERENCES AircraftTypes (ID);
ALTER TABLE Aircrafts ADD CONSTRAINT FKAircrafts163957 FOREIGN KEY (AircraftTypeID) REFERENCES AircraftTypes (ID);
ALTER TABLE AircraftDetails ADD CONSTRAINT FKAircraftDe930955 FOREIGN KEY (AircraftID) REFERENCES Aircrafts (ID);
ALTER TABLE AircraftDetails ADD CONSTRAINT FKAircraftDe57774 FOREIGN KEY (CabinTypeID) REFERENCES CabinTypes (ID);
ALTER TABLE AircraftAmenities ADD CONSTRAINT FKAircraftAm970715 FOREIGN KEY (AmenitiesID) REFERENCES Amenities (ID);
ALTER TABLE AircraftAmenities ADD CONSTRAINT FKAircraftAm664191 FOREIGN KEY (CabinTypeID) REFERENCES CabinTypes (ID);
ALTER TABLE AircraftAmenities ADD CONSTRAINT FKAircraftAm675461 FOREIGN KEY (AircraftID) REFERENCES Aircrafts (ID);
ALTER TABLE Schedules ADD CONSTRAINT FKSchedules350114 FOREIGN KEY (AircraftID) REFERENCES Aircrafts (ID);
ALTER TABLE DetailTickets ADD CONSTRAINT FKDetailTick440297 FOREIGN KEY (CabinTypeID) REFERENCES CabinTypes (ID);
