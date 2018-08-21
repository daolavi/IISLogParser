using IISLogParser.Convertors;

namespace IISLogParser.Attributes
{
    public class FieldAttribute : FieldBaseAttribute
    {
        public FieldAttribute(string name) : base(name, new StringConvertor())
        {
        }
    }
}
