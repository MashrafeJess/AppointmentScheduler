using Database.Context;
using Database.Model;

namespace Business.Sections.RoleSection
{
    public class RoleService
    {
        AppointmentSchedulerContext schedulerContext = new AppointmentSchedulerContext();
        public Result Add(Role model)
        {
            // 1bool x = schedulerContext.Mode.Any(x => x.Role == model.Role);
            bool y = schedulerContext.Role.Any(y => y.RoleName == model.RoleName);
            if ( y)
            {
                return new Result(false, "This Role Type already exists!");
            }
            Role mode = new Role
            {
                RoleName = model.RoleName
            };
            schedulerContext.Role.Add(mode);
            try
            {
                return Result.DbCommit(schedulerContext, "Successfully Added new role", null, mode);
            }
            catch (Exception ex) 
            {
                return new Result(false, ex.Message);
            }
        }
        public Result Update(Role model)
        {
            Role mode = schedulerContext.Role.Where(x => x.RoleNum == model.RoleNum).FirstOrDefault();
            if (mode == null)
            {
                return new Result(false, "No such Role exists in Database!!");
            }
            if (!string.IsNullOrEmpty(model.RoleName)) mode.RoleName = model.RoleName;
            return Result.DbCommit(schedulerContext, "successfully updated", null, mode);
        }
    }
}
