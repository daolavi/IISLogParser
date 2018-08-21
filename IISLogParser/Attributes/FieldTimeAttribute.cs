using IISLogParser.Convertors;

namespace IISLogParser.Attributes
{
    public class FieldTimeAttribute : FieldBaseAttribute
    {
        public FieldTimeAttribute(string name) : base(name, new TimeConvertor())
        {
        }
    }
}
