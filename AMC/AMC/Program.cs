using AMC.Models;
using AMC.Models.ConfigElement;
using AMC.Models.InnerCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMC
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfElelement = new List<ChildrenConfigElement>() {
                new ChildrenConfigElement() { CityName = "Lahore", SchoolName = "City School Lahore" },
                new ChildrenConfigElement() { CityName = "Karachi", SchoolName = "City School Karachi" }
            };
            var chilCollection = new ChildrenCollection() { DefaultValue = -2, FullName = "Children Name 2", Enabled = true };
            listOfElelement.ForEach(r => chilCollection.Add(r));
            IChildren setting = new Children() { Name = "Fahad", FatherName = "Anwar UL Haq", childrenCollection = chilCollection };
            //Setting setting2 = new Setting(setting);
            IChildren setting3 = Children.MapProfile(setting);
            Console.WriteLine("Source Object Values are... ");
            /////////////////////////////////////////////////////////////////////
            ////            Setting 1                                        ///
            /////////////////////////////////////////////////////////////////////
            //PrintProperties(setting, 1);
            //Console.WriteLine("/////////////////////////////////////////////////");
            ///////////////////////////////////////////////////////////////////////
            //////            Setting 2 After Generic Map                      ///
            ///////////////////////////////////////////////////////////////////////
            //PrintProperties(setting2, 1);
            Console.WriteLine("/////////////////////////////////////////////////");
            /////////////////////////////////////////////////////////////////////
            ////            Setting 3 After Assembly Map                              ///
            /////////////////////////////////////////////////////////////////////
            PrintProperties(setting3, 1);
            Console.ReadLine();
        }
        public static void PrintProperties(object obj, int indent)
        {
            if (obj == null) return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                var elems = propValue as IList;
                if (elems != null)
                {
                    foreach (var item in elems)
                    {
                        PrintProperties(item, indent + 3);
                    }
                }
                else
                {
                    // This will not cut-off System.Collections because of the first check
                    if (property.PropertyType.Assembly == objType.Assembly)
                    {
                        Console.WriteLine("{0}{1}:", indentString, property.Name);

                        PrintProperties(propValue, indent + 2);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                    }
                }
            }
        }
    }
}
