using System;
using System.Collections.Generic;
using System.Text;

namespace keysProject
{
    public class AttributeType
    {
        public static AttributeTypeEnum GetType(string val)
        {
            int outputInt;
            if (int.TryParse(val, out outputInt))
            {
                return AttributeTypeEnum.integerType;
            }

            double outputDouble;
            if (Double.TryParse(val, out outputDouble))
            {
                return AttributeTypeEnum.doubleType;
            }

            bool outputBool;
            if (bool.TryParse(val, out outputBool))
            {
                return AttributeTypeEnum.booleanType;
            }

            return AttributeTypeEnum.stringType;
        }
    }


    public enum AttributeTypeEnum
    {
        integerType,
        doubleType,
        booleanType,
        stringType
    }
}
