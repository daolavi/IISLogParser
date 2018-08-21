using IISLogParser.Convertors;
using System;

namespace IISLogParser.Attributes
{
    public abstract class FieldBaseAttribute : Attribute
    {
        public readonly string FieldName;
        public readonly ITextConvertor Convertor;

        protected FieldBaseAttribute(string name)
        {
            FieldName = name;
        }

        protected FieldBaseAttribute(string name, ITextConvertor convertor)
        {
            FieldName = name;
            Convertor = convertor;
        }
    }
}
