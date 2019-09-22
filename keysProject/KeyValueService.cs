using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace keysProject
{
    public class KeyValueService
    {
        public Dictionary<string, Dictionary<AttributeKey, string>> dataStore;
        public Dictionary<string, AttributeTypeEnum> typeStore;

        public KeyValueService()
        {
            InitializeDataStore();

            InitializeTypeStore();
        }

        public void InitializeDataStore()
        {
            if (dataStore == null)
            {
                dataStore = new Dictionary<string, Dictionary<AttributeKey, string>>();
            }
        }

        public void InitializeTypeStore()
        {
            if (typeStore == null)
            {
                typeStore = new Dictionary<string, AttributeTypeEnum>();
            }
        }


        public void HandleQueryOnAttributeValue(string printAttrName, string printAttrVal)
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

        public void HandleDeleteKeyCase(string delkey)
        {
            var exists = dataStore.ContainsKey(delkey);

            if (!exists)
            {
                Console.WriteLine($"Key {delkey} does not exists");
            }

            dataStore.Remove(delkey);

            Console.WriteLine($"Key {delkey} deleted");
        }

        public void HandlePrintValueCase(string printkey)
        {
            var attrPrintList = dataStore[printkey];

            foreach (KeyValuePair<AttributeKey, string> kvp in attrPrintList)
            {
                Console.WriteLine($"Key = {kvp.Key.name}, Type = {kvp.Key.type}, CreateTime = {kvp.Key.createTimestamp},  Value = {kvp.Value}");
            }
            Console.WriteLine();
        }

        public void HandleNewKeyCase(string key)
        {
            var attributeList = new Dictionary<AttributeKey, string>();
            dataStore.Add(key, attributeList);
        }

        public void HandleAddAttributeCase(string key, string attrkey, string attrValue)
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

        public bool IsValidAttribute(string attrkey, string attrValue, out AttributeTypeEnum attrType)
        {
            attrType = AttributeType.GetType(attrValue);

            if (typeStore.ContainsKey(attrkey))
            {
                return typeStore[attrkey] == attrType;
            }

            typeStore.Add(attrkey, attrType);

            return true;
        }
    }
}
