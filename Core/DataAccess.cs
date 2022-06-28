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
            return EquipmentAccountingEntities.GetContext().Devices.Where(x => !x.IsDeleted).ToList();
        }
        public static List<Employee> GetEmployees()
        {
            return EquipmentAccountingEntities.GetContext().Employees.Where(x => !x.IsDeleted).ToList();
        }
        public static List<Subdivision> GetSubdivisions()
        {
            return EquipmentAccountingEntities.GetContext().Subdivisions.Where(x => !x.IsDeleted).ToList();
        }

        public static List<Transfer> GetTransfers()
        {
            return EquipmentAccountingEntities.GetContext().Transfers.Where(x => !x.IsDeleted).ToList();
        }

        public static List<User> GetUsers()
        {
            return EquipmentAccountingEntities.GetContext().Users.ToList();
        }

        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public static bool SaveSubdivision(Subdivision subdivision)
        {
            try
            {
                if (GetSubdivisions().FirstOrDefault(s => s.Id == subdivision.Id) == null)
                    EquipmentAccountingEntities.GetContext().Subdivisions.Add(subdivision);

                EquipmentAccountingEntities.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public static bool SaveDevice(Device device)
        {
            try
            {
                if (GetDevices().FirstOrDefault(d => d.Id == device.Id) == null)
                    EquipmentAccountingEntities.GetContext().Devices.Add(device);

                EquipmentAccountingEntities.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public static bool SaveTransfer(Transfer transfer)
        {
            try
            {
                if (GetTransfers().FirstOrDefault(t => t.Id == transfer.Id) == null)
                    EquipmentAccountingEntities.GetContext().Transfers.Add(transfer);

                EquipmentAccountingEntities.GetContext().SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public static bool SaveEmployee(Employee employee)
        {
            try
            {
                if (GetEmployees().FirstOrDefault(e => e.Id == employee.Id) == null)
                    EquipmentAccountingEntities.GetContext().Employees.Add(employee);

                EquipmentAccountingEntities.GetContext().SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool RegisterUser(User user)
        {
            try 
            {
                EquipmentAccountingEntities.GetContext().Users.Add(user);
            
                return Convert.ToBoolean(EquipmentAccountingEntities.GetContext().SaveChanges());
            }
            catch
            { return false; }
        }
    }
}