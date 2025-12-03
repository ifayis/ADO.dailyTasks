using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            managestu data = new managestu();

            Student s1 = new Student
            {
                id = 9,
                name = "leo",
                detailsid = 109
            };
            data.insertdata(s1);

            Console.WriteLine();
        }
    }
}
