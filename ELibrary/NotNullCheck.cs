using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary
{
    public class NotNullCheck
    {
        public static string Check()
        {
            string myString;
            while (true)
            {
                myString = Console.ReadLine();
                if (myString == null)
                {
                    Console.Write("Значение не может быть Null!");
                }
                else
                {
                    break;
                }
            }

            return myString;
        }
    }
}
