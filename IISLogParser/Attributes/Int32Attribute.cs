using IISLogParser.Convertors;

namespace IISLogParser.Attributes
{
    public class Int32Attribute : FieldBaseAttribute
    {
        public Int32Attribute(string name) : base(name, new Int32Convertor())
        {
        }
    }
}
