using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataAccess
    {
        public static List<Device> GetDevices()
        {
            return EquipmentAccountingEntities.GetContext().Devices.ToList();
        }
        public static List<Employee> GetEmployees()
        {
            return EquipmentAccountingEntities.GetContext().Employees.ToList();
        }
        public static List<Subdivision> GetSubdivisions()
        { 
            return EquipmentAccountingEntities.GetContext().Subdivisions.ToList(); 
        }

        public static List<Transfer> GetTransfers()
        {
            return EquipmentAccountingEntities.GetContext().Transfers.ToList();
        }

        public static List<User> GetUsers()
        {
            return EquipmentAccountingEntities.GetContext().Users.ToList();
        }

        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}