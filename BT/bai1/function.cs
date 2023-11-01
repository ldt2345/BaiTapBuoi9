using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bai1
{
    class function
    {
        public SqlConnection conn;
        public function()
        {
            conn = new SqlConnection("Data Source=A209PC49\\CSSQL08;Initial Catalog=Quanlylop;Integrated Security=True");
        }
        public function(string strcn)
        {
            conn = new SqlConnection(strcn);
        }
        
    }
}
