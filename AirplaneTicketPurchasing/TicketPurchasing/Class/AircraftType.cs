using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPurchasing
{
    class AircraftType
    {
        private int id;
        private string cabin;
        private int seat;
        private int status;

        public AircraftType(string cabin, int seat, int status)
        {
            this.id = 0;
            this.cabin = cabin;
            this.seat = seat;
            this.status = status;
        }

        public AircraftType(int id, string cabin, int seat, int status)
        {
            this.id = id;
            this.cabin = cabin;
            this.seat = seat;
            this.status = status;
        }

        public int ID { get { return id; } set { id = value; } }
        public string Cabin { get { return cabin; } set { cabin = value; } }
        public int Seat { get { return seat; } set { seat = value; } }
        public int Status { get { return status; } set { status = value; } }
    }
}
