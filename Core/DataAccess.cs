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
    }
}