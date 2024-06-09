using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Test
{
    public class Table1
    {
        public int IdTable1 { get; set; }
        public string name { get; set; }
    }

    public class Table2
    {
        public int IdTable2 { get; set; }
        public string name { get; set; }
    }

    public class TableModel {
        public Table1 table1 { get; set; }
        public Table2 table2 { get; set; }
    }
}
