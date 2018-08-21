using IISLogParser.Convertors;

namespace IISLogParser.Attributes
{
    public class FieldDateAttribute : FieldBaseAttribute
    {
        public FieldDateAttribute(string name) : base(name, new DateTimeOffsetConvertor())
        {
        }
    }
}
