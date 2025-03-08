using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.UserModel;
using Database.Context;
using Database.Model;

namespace Business.Sections.UserSection
{
    public class MakeAppointment
    {
        AppointmentSchedulerContext schedulercontext = new AppointmentSchedulerContext();
        public Result Appointment(AppointmentForm form)
        {
            bool x = schedulercontext.Appointment.Any(a => a.RequestedBy == form.RequestedBy && a.AppointTime == form.AppointTime);
            bool y = schedulercontext.Appointment.Any(a => a.RequestedTo == form.RequestedTo && a.AppointTime == form.AppointTime);
            if (x)
            {
                return new Result(false, "User has an appointment on this time");
            }
            else if (y)
            {
                return new Result(false, "Requested person has an appointment on this time");
            }
            Appointment appointment = new Appointment
            {
                RequestedTo = form.RequestedTo,
                RequestedBy = form.RequestedBy,
                AppointTime = form.AppointTime,
                Duration = form.Duration,
                RoomNo = form.RoomNO,
                Status = "Running"
            };
            schedulercontext.Appointment.Add(appointment);
            schedulercontext.SaveChanges();
            return Result.DbCommit(schedulercontext, "Successfully registered", null, appointment);
        }
    }
}
