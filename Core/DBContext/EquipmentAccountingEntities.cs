using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class EquipmentAccountingEntities
    {
        private static EquipmentAccountingEntities _context;

        public static EquipmentAccountingEntities GetContext()
        { 
            if(_context == null)
                _context = new EquipmentAccountingEntities();
            return _context;
        }

    }
}
