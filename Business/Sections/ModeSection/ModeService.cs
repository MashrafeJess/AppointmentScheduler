using Database.Context;
using Database.Model;

namespace Business.Sections.RoleSection
{
    public class ModeService
    {
        AppointmentSchedulerContext schedulerContext = new AppointmentSchedulerContext();
        public Result Add(Mode model)
        {
            bool x = schedulerContext.Mode.Any(x => x.Role == model.Role);
            bool y = schedulerContext.Mode.Any(y => y.ModeName == model.ModeName);
            if (x || y)
            {
                return new Result(false, "This Role Type already exists!");
            }
            Mode mode = new Mode
            {
                Role = model.Role,
                ModeName = model.ModeName
            };
            schedulerContext.Mode.Add(mode);
            return Result.DbCommit(schedulerContext, "Successfully Added new role", null, mode);
        }
        public Result Update(Mode model)
        {
            Mode mode = schedulerContext.Mode.Where(x => x.Role == model.Role).FirstOrDefault();
            if (mode == null)
            {
                return new Result(false, "No such Role exists in Database!!");
            }
            if (model.Role.HasValue) mode.Role = model.Role;
            if (!string.IsNullOrEmpty(model.ModeName)) mode.ModeName = model.ModeName;
            return Result.DbCommit(schedulerContext, "successfully updated", null, mode);
        }
    }
}
