using System;
using System.Collections.Generic;
using System.Text;

namespace keysProject
{
    public class AttributeKey
    {
        public string name { get; set; }
        public AttributeTypeEnum type { get; set; }
        public DateTime createTimestamp { get; set; }
    }
}
