using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThirdCaliburnApp.Helpers
{
   
    class Commons
    {
        internal static bool IsNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        public static readonly string CONNSTRING =
           "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=mysql_p@ssw0rd";
        public static readonly string SELECT_EMPLYEES =
            " SELECT id, EmpName, salary, DeptName, Destination " +
            "   FROM employeestbl " +
            "  ORDER BY id ";

        public static readonly string UPDATE_EMPLYEE =
            "UPDATE employeestbl " +
            "   SET  " +
            "       EmpName = @EmpName, " +
            "       salary  = @salary, " +
            "      DeptName = @DeptName, " +
            "   Destination = @Destination " +
            "      WHERE id = @id ";

        internal static readonly string INSERT_EMPLYEE =
            "INSERT INTO employeestbl " +
            "( " +
            "            EmpName, " +
            "            salary, " +
            "            DeptName, " +
            "            Destination " +
            "         ) " +
            "VALUES " +
            " ( " +
            "           @EmpName, " +
            "           @salary, " +
            "           @DeptName, " +
            "           @Destination " +
            ") ";

        internal static readonly string DELETE_EMPLYEE =
            "DELETE FROM employeestbl " +
            " WHERE id = @id ";
    }
}
