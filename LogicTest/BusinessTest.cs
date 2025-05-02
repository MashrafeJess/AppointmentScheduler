using Business;
using Business.UserModel;
using Business.Sections.UserSection;
using Business.Sections.RoleSection;
using Business.Sections.SlotSection;
using Database.Model;

namespace LogicTest
{
    internal class BusinessTest
    {

        static void Main(string[] args)
        {

            // Call methods
            //Registration();
            //LogIn();
            //Update();
           MakeAppointment();
            //AddRole();
            // AddSlot();
        }

        static void Registration()
        {
            try
            {
                MockForm mockForm = new MockForm();
                Console.WriteLine("Enter Name:");
                mockForm.Name = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                mockForm.Email = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                mockForm.Password = Console.ReadLine();
                Console.WriteLine("Enter Designation:");
                mockForm.Designation = Console.ReadLine();


                Result result = new UserService().Registration(mockForm);
                Console.WriteLine(result.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
        }

        static void LogIn()
        {
            try
            {
                MockLoginForm form = new MockLoginForm();
                Console.WriteLine("Enter Email:");
                form.Email = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                form.Password = Console.ReadLine();

                Result result = new UserService().Login(form);
                Console.WriteLine(result.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
        }

        static void Update()
        {
            try
            {
                MockForm form = new MockForm();
                //Console.WriteLine("Enter Email (for user identification):");
                //form.Email = Console.ReadLine();
                Console.WriteLine("Enter Name (leave blank if not changing):");
                form.Name = Console.ReadLine();
                Console.WriteLine("Enter New Password (leave blank if not changing):");
                form.Password = Console.ReadLine();
                Console.WriteLine("Enter Designation (leave blank if not changing):");
                form.Designation = Console.ReadLine();

                Result result = new UserService().Update(form);
                Console.WriteLine(result.Message);  // Show success or error message
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
            }
        }
        static void MakeAppointment()
        {
            AppointmentForm form = new AppointmentForm();
            form.RequestedBy = Console.ReadLine();
            form.RequestedFor = Console.ReadLine();
            form.AppointTime = TimeOnly.Parse(Console.ReadLine());
            form.Date = DateOnly.Parse(Console.ReadLine());
            Result result = new AppointmentService().Appointment(form);
            Console.WriteLine(result.Message);
        }
        static void AddRole()
        {
            Role role = new Role();
            role.RoleName = Console.ReadLine();
            Result result = new RoleService().Add(role);
            Console.WriteLine(result.Message);
        }
        static void AddSlot()
        {
            Slots slot = new Slots();
            slot.Slot = TimeOnly.Parse(Console.ReadLine());
            slot.UserId = Console.ReadLine();
            Result result = new SlotService().AddSlot(slot);
            Console.WriteLine(result.Message);
        }

    }
}