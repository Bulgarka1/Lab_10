using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
     interface ICheck
     {
        public static bool Check1(Person person)
        {
            bool bool1 = false;
            if (person.Check > person.Points && person.Points != 0)
            {
                bool1 = true;
            }
            return bool1;
        }

     }
}
