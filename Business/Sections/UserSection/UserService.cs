using Business.UserModel;
using Database.Context;
using Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Sections.UserSection
{
    public class UserService
    {

        AppointmentSchedulerContext schedulerContext = new AppointmentSchedulerContext();

        public Result Registration(MockForm user)
        {
            bool x = schedulerContext.UserInfo.Any(x => x.Email == user.Email);
            if (x)
            {
                return new Result(false, "This email already exists!");
            }
            UserInfo userInfo = new UserInfo
            {
                Email = user.Email,
                Name = user.Name,
                PasswordHash = new PasswordHasher<object>().HashPassword(user, user.Password),
                Designation = user.Designation,
                RoomNum = user.RoomNumber,
                Mode = user.Mode,
                CreatedBy = user.CreatedBy,
                UpdatedBy = user.UpdatedBy,
                UpdatedDate = user.UpdatedDate // Eita automatic hoye jawar kotha na!!!
            };
            schedulerContext.UserInfo.Add(userInfo);
            return Result.DbCommit(schedulerContext, "Successfully registered", null, user);
        }

        public Result Login(MockForm user)
        {
            UserInfo? userInfo = schedulerContext.UserInfo?.Where(x => x.Email == user.Email).FirstOrDefault();

            if (userInfo == null) return new Result(false, "Register First", null);

            PasswordVerificationResult HashResult = new PasswordHasher<UserInfo>().VerifyHashedPassword(userInfo, userInfo.PasswordHash, user.Password);
            if (HashResult != PasswordVerificationResult.Failed)
            {
                return new Result(true, $"Logged in successfully", user);
            }
            else
            {
                return new Result(false, "Incorrect Password");
            }
        }

        public Result Update(MockForm user)
        {
            UserInfo? userInfo = schedulerContext.UserInfo.Where(x => x.Email == user.Email).FirstOrDefault();

            if (!string.IsNullOrEmpty(user.Name)) userInfo.Name = user.Name;
            if (!string.IsNullOrEmpty(user.Password))
            {
                userInfo.PasswordHash = new PasswordHasher<object>().HashPassword(user, user.Password);
            }
            if (!string.IsNullOrEmpty(user.Designation)) userInfo.Designation = user.Designation;
            if (user.RoomNumber.HasValue) userInfo.RoomNum = user.RoomNumber;

            return Result.DbCommit(schedulerContext, "successfully updated", null, user);
        }
        public Result List()
        {
            var Users = schedulerContext.UserInfo.ToList();
            try
            {
                return new Result(true, "Success", Users);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        public Result Single(string Id)
        {
            try
            {
                var User = schedulerContext.UserInfo.Where(x => x.UserId == Id).FirstOrDefault();
                return new Result(true, "Success", User);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
