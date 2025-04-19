using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Context;
using Business.UserModel;
using Database.Model;

namespace Business.Sections.SlotSection
{
    public class SlotService
    {
        AppointmentSchedulerContext schedulerContext = new AppointmentSchedulerContext();
        public Result AddSlot(Slots slot)
        {
            bool x = schedulerContext.Slots.Any(x => x.Slot == slot.Slot && x.UserId == slot.UserId);
            if (x)
            {
                return new Result(false, "This slot for this user already exists");
            }
            schedulerContext.Slots.Add(slot);
            return Result.DbCommit(schedulerContext, "Successfully added a new slot", null, slot);
        }
        public Result UpdateSlot(Slots slot)
        {
            Slots slots = schedulerContext.Slots.Where(s => s.Slot == slot.Slot && s.UserId == slot.UserId).FirstOrDefault();
            if (slots == null)
            {
                return new Result(false, "No slot found in this time with this user");
            }
            schedulerContext.Slots.Update(slot);
            return Result.DbCommit(schedulerContext, "Succesfully updated",null, slot);
        }
        public Result RemoveSlot(Slots slot)
        {
            bool x = schedulerContext.Slots.Any(x => x.Slot == slot.Slot && x.UserId == slot.UserId);
            if(!x)
            {
                return new Result(false, "No slot found in this time with this user");
            }
            schedulerContext.Slots.Remove(slot);
            return Result.DbCommit(schedulerContext,"Slot successfully removed",null, slot);
        }
        public Result UserSlots(string UserId)
        {
            bool x = schedulerContext.Slots.Any(x=> x.UserId == UserId);
            if (!x)
            {
                return new Result(false,"This user has no slots");
            }
            var slot = schedulerContext.Slots.Where(x=>x.UserId == UserId).ToList();
            return new Result(true, "Success", slot);
        }
        public Result AllSlots()
        {
            var slots = schedulerContext.Slots.ToList();
            return new Result(true, "Successful", slots);
        }
    }
}
