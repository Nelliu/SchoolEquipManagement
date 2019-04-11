using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipManagement
{
    public class Equipment
    {
        [PrimaryKey, AutoIncrement]
        private int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }     
        public int ClassName { get; set; }

    }
}
