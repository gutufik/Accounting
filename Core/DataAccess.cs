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

        public static void SaveSubdivision(Subdivision subdivision)
        {
            if (GetSubdivisions().FirstOrDefault(s => s.Id == subdivision.Id) == null)
                EquipmentAccountingEntities.GetContext().Subdivisions.Add(subdivision);

            EquipmentAccountingEntities.GetContext().SaveChanges();
        }

        public static void SaveDevice(Device device)
        {
            if (GetDevices().FirstOrDefault(d => d.Id == device.Id) == null)
                EquipmentAccountingEntities.GetContext().Devices.Add(device);

            EquipmentAccountingEntities.GetContext().SaveChanges();
        }

        public static bool RegisterUser(User user)
        { 
            EquipmentAccountingEntities.GetContext().Users.Add(user);

            return Convert.ToBoolean(EquipmentAccountingEntities.GetContext().SaveChanges());
        }
    }
}