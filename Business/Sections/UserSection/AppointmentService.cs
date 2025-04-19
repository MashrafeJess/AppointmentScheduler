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
    public class AppointmentService
    {
        AppointmentSchedulerContext schedulercontext = new AppointmentSchedulerContext();
        public Result Appointment(AppointmentForm form)
        {
            DateTime dateTime = form.Date.ToDateTime(form.AppointTime);
            bool x = schedulercontext.Appointment.Any(a => a.RequestedBy == form.RequestedBy && a.AppointTime == dateTime && a.AppointmentStatus == 1);
            bool y = schedulercontext.Appointment.Any(a => a.RequestedFor == form.RequestedFor && a.AppointTime == dateTime && a.AppointmentStatus == 1);
            if (x)
            {
                return new Result(false, "User has an pending appointment on this date & time");
            }
            else if (y)
            {
                return new Result(false, "Requested person has an pending appointment on this date & time");
            }
            UserInfo userinfo = new UserInfo();
            userinfo = schedulercontext.UserInfo.Where(x=>x.Email == form.RequestedFor).FirstOrDefault();
            Appointment appointment = new Appointment
            {
                RequestedFor = form.RequestedFor,
                RequestedBy = form.RequestedBy,
                AppointTime = dateTime,
                RoomNo = userinfo.RoomNum.GetValueOrDefault(0),
                AppointmentStatus = 1
            };
            schedulercontext.Appointment.Add(appointment);
            schedulercontext.SaveChanges();
            return Result.DbCommit(schedulercontext, "Successfully registered", null, appointment);
        }

        public Result UpdateAppointment()
        {

        }
    }
}
