using System;
using System.Collections.Generic;
using System.Linq;

namespace keysProject
{
    public class Program
    {
        public static Dictionary<string, Dictionary<AttributeKey, string>> dataStore;
        public static Dictionary<string, AttributeTypeEnum> typeStore;


        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Keys Project!");

            InitializeDataStore();

            InitializeTypeStore();

            string key;
            string option = "1";

            Console.WriteLine("Enter 1st Key : ");
            key = Console.ReadLine();

            var attributeList = new Dictionary<AttributeKey, string>();
            dataStore.Add(key, attributeList);

            while(option != "6")
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

                            HandleAddAttributeCase(key, attrkey, attrValue);
                            break;

                        case "2":

                            Console.WriteLine("Enter New Key :");
                            key = Console.ReadLine();

                            HandleNewKeyCase(key);
                            break;

                        case "3":

                            Console.WriteLine("Enter Key Name :");
                            var printkey = Console.ReadLine();

                            HandlePrintValueCase(printkey);
                            break;

                        case "4":

                            Console.WriteLine("Enter Key Name you want to delete :");
                            var delkey = Console.ReadLine();

                            HandleDeleteKeyCase(delkey);
                            break;

                        case "5":

                            Console.WriteLine("Enter Attribute Name :");
                            var printAttrName = Console.ReadLine();

                            Console.WriteLine("Enter Attribute value :");
                            var printAttrVal = Console.ReadLine();

                            HandleQueryOnAttributeValue(printAttrName, printAttrVal);
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

        private static void HandleQueryOnAttributeValue(string printAttrName, string printAttrVal)
        {
            foreach (KeyValuePair<string, Dictionary<AttributeKey, string>> topKeyVal in dataStore)
            {
                var attributeWithValExists = topKeyVal.Value.Select(a => a.Value == printAttrVal && a.Key.name == printAttrName).FirstOrDefault();

                if (attributeWithValExists)
                {
                    foreach (KeyValuePair<AttributeKey, string> kvp in topKeyVal.Value)
                    {
                        Console.WriteLine($"Key = {topKeyVal.Key}, attributeKey = {kvp.Key.name}, Type = {kvp.Key.type}, Value = {kvp.Value}");
                    }
                }
            }
        }

        private static void HandleDeleteKeyCase(string delkey)
        {
            var exists = dataStore.ContainsKey(delkey);

            if (!exists)
            {
                Console.WriteLine($"Key {delkey} does not exists");
            }

            dataStore.Remove(delkey);

            Console.WriteLine($"Key {delkey} deleted");
        }

        private static void HandlePrintValueCase(string printkey)
        {
            var attrPrintList = dataStore[printkey];

            foreach (KeyValuePair<AttributeKey, string> kvp in attrPrintList)
            {
                Console.WriteLine($"Key = {kvp.Key.name}, Type = {kvp.Key.type}, CreateTime = {kvp.Key.createTimestamp},  Value = {kvp.Value}");
            }
            Console.WriteLine();
        }

        public static void HandleNewKeyCase(string key)
        {
            var attributeList = new Dictionary<AttributeKey, string>();
            dataStore.Add(key, attributeList);
        }

        public static void HandleAddAttributeCase(string key, string attrkey, string attrValue)
        {
            AttributeTypeEnum attrType;

            var valid = IsValidAttribute(attrkey, attrValue, out attrType);

            if (!valid)
            {
                Console.WriteLine("Please enter valid type.");
                return;
            }

            var attrkeyObj = new AttributeKey
            {
                name = attrkey,
                type = attrType,
                createTimestamp = DateTime.Now
            };

            var attrList = dataStore[key];
            attrList.Add(attrkeyObj, attrValue);
            dataStore[key] = attrList;
        }

        public static bool IsValidAttribute(string attrkey, string attrValue, out AttributeTypeEnum attrType)
        {
            attrType = AttributeType.GetType(attrValue);

            if (typeStore.ContainsKey(attrkey))
            {
                return typeStore[attrkey] == attrType;
            }

            typeStore.Add(attrkey, attrType);

            return true;
        }




        public static void InitializeDataStore()
        {
            if(dataStore == null)
            {
                dataStore = new Dictionary<string, Dictionary<AttributeKey, string>>();
            }
        }

        public static void InitializeTypeStore()
        {
            if (typeStore == null)
            {
                typeStore = new Dictionary<string, AttributeTypeEnum>();
            }
        }


    }
}
