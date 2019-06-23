using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchasing.Class
{
    class AircraftAmenities
    {
        private int id;
        private string amenitiesid;
        private string amenities;
        private string cabin;
        private int status;

        public AircraftAmenities(string amenitiesid, string amenities, string cabin, int status)
        {
            this.id = 0;
            this.amenitiesid = amenitiesid;
            this.amenities = amenities;
            this.cabin = cabin;
            this.status = status;
        }

        public AircraftAmenities(int id, string amenitiesid, string amenities, string cabin, int status)
        {
            this.id = id;
            this.amenitiesid = amenitiesid;
            this.amenities = amenities;
            this.cabin = cabin;
            this.status = status;
        }

        public AircraftAmenities(int id, string amenitiesid, string amenities, int status)
        {
            this.id = id;
            this.amenitiesid = amenitiesid;
            this.amenities = amenities;
            this.status = status;
        }

        public AircraftAmenities(string amenitiesid, string amenities, int status)
        {
            this.amenitiesid = amenitiesid;
            this.amenities = amenities;
            this.status = status;
        }

        public int ID { get { return id; } set { id = value; } }
        public string AmenitiesID { get { return amenitiesid; } set { amenitiesid = value; } }
        public string Amenities { get { return amenities; } set { amenities = value; } }
        public string Cabin { get { return cabin; } set { cabin = value; } }
        public int Status { get { return status; } set { status = value; } }

    }
}
