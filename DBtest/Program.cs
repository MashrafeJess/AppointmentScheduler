using Database.Context;
using Database.Model;
using System;
using System.Linq;

namespace DBtest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AppointmentSchedulerContext();
            UserInfo MyUser = db.UserInfo.Where(x=>x.UserId== "07588ae5-94ef-49be-bba4-91ccfd1881ff").FirstOrDefault();
            MyUser.CreatedDate = DateTime.Now;
            MyUser.CreatedBy = "b8f59e38-ceaf-4bcf-adfe-b05f0d5ecdbc";
            MyUser.UpdatedBy = "b8f59e38-ceaf-4bcf-adfe-b05f0d5ecdbc";
            MyUser.UpdatedDate = DateTime.Now;
            db.SaveChanges();
        }
    }
}