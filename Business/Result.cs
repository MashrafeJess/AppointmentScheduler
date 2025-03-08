using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;

namespace Business
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "Successful";
        public object? Data { get; set; }
        public Result() { }
        public Result(bool Success, string Message, object? Data = null)
        {
            this.Success = Success;
            this.Message = Message;
            this.Data = Data;
        }
        public static Result DbCommit(AppointmentSchedulerContext schedulerContext, string message, string? FailedMessage = null, object? Data = null)
        {
            try
            {
                schedulerContext.SaveChanges();
                return new Result(true, message, Data);
            }
            catch (Exception ex)
            {
                return new Result(false, FailedMessage ?? ex.Message);
            }
        }
    }
}
