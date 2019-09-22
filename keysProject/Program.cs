using System;
using System.Collections.Generic;
using System.Linq;

namespace keysProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Keys Project!");

            var service = new KeyValueService();

            string key;
            string option = "1";

            Console.WriteLine("Enter 1st Key : ");
            key = Console.ReadLine();

            //adding first key
            service.HandleNewKeyCase(key);

            while (option != "6")
            {
                PrintAllOptions();

                try
                {
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "6":
                            break;

                        case "1":

                            Console.WriteLine("Enter Attribute Key :");
                            var attrkey = Console.ReadLine();

                            Console.WriteLine("Enter Attribute Value : ");
                            var attrValue = Console.ReadLine();

                            service.HandleAddAttributeCase(key, attrkey, attrValue);
                            break;

                        case "2":

                            Console.WriteLine("Enter New Key :");
                            key = Console.ReadLine();

                            service.HandleNewKeyCase(key);
                            break;

                        case "3":

                            Console.WriteLine("Enter Key Name :");
                            var printkey = Console.ReadLine();

                            service.HandlePrintValueCase(printkey);
                            break;

                        case "4":

                            Console.WriteLine("Enter Key Name you want to delete :");
                            var delkey = Console.ReadLine();

                            service.HandleDeleteKeyCase(delkey);
                            break;

                        case "5":

                            Console.WriteLine("Enter Attribute Name :");
                            var printAttrName = Console.ReadLine();

                            Console.WriteLine("Enter Attribute value :");
                            var printAttrVal = Console.ReadLine();

                            service.HandleQueryOnAttributeValue(printAttrName, printAttrVal);
                            break;


                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


        private static void PrintAllOptions()
        {
            Console.WriteLine("Press 1 to Enter Attribute : ");
            Console.WriteLine("Press 2 to Enter Another Key : ");
            Console.WriteLine("Press 3 to Get Values for a partikular key : ");
            Console.WriteLine("Press 4 to Delete a Key : ");
            Console.WriteLine("Press 5 to perform secondary index scan : ");
            Console.WriteLine("Press 6 to EXIT : ");
        }
    }
}
