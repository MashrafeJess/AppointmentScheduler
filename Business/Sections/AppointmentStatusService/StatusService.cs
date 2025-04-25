using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Database.Model;

namespace Business.Sections.AppointmentStatusService
{
    public class StatusService
    {
        AppointmentSchedulerContext schedulerContext = new AppointmentSchedulerContext();
        Result AddStatus(AppointmentStatus status)
        {
            bool x = schedulerContext.AppointmentStatus.Any(x=>x.StatusName == status.StatusName);
            if (x)
            {
                return new Result(false, "This status is already active");
            }
            schedulerContext.AppointmentStatus.Add(status);
            return Result.DbCommit(schedulerContext, "Successfully Added new role", null, status);
        }
        Result UpdateStatus(AppointmentStatus status)
        {
            bool x = schedulerContext.AppointmentStatus.Any(x => x.StatusId == status.StatusId);
            if (!x)
            {
                return new Result(false, "There is no such status");
            }
            schedulerContext.AppointmentStatus.Update(status);
            return Result.DbCommit(schedulerContext, "Successfully Updated the status", null, status);
        }
        Result DeleteStatus(AppointmentStatus status)
        {
            bool x = schedulerContext.AppointmentStatus.Any(x => x.StatusId == status.StatusId);
            if (!x)
            {
                return new Result(false, "There is no such status");
            }
            schedulerContext.AppointmentStatus.Remove(status);
            return Result.DbCommit(schedulerContext, "Successfully Updated the status", null, status);
        }
        Result AllStatus()
        {
            
            var x = schedulerContext.AppointmentStatus.ToList();
            return new Result(true, "Success", x);
        }
        Result SingleStatus(int id)
        {
            var status = schedulerContext.AppointmentStatus.Where(s=>s.StatusId==id).FirstOrDefault();
            return new Result(true, "Success", status);
        }
    }
}
