using System;
using System.Collections.Generic;
using System.Text;

namespace TUSA.Data
{
    public enum AppointmentSts
    {
        Cancel = 0,
        Booked,
        Confirmed, //Happens when billing done
        NextInQueue,
        In, //Patient enter into doctor room
        ReSchedule,
        NoShow,
        Completed,
        Admitted
    }
}