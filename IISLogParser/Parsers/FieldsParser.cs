using IISLogParser.Attributes;
using IISLogParser.Models;
using System;
using System.Linq;
using System.Reflection;

namespace IISLogParser.Parsers
{
    public class FieldsParser
    {
        void GetFieldAttributeByName(string name, FieldInfo[] fields, Action<FieldBaseAttribute, FieldInfo> foundBlock)
        {
            for (var fieldIndexPosition = 0; fieldIndexPosition < fields.Length; fieldIndexPosition++)
            {
                var field = fields[fieldIndexPosition];
                var fieldAttribute = (FieldBaseAttribute)field.GetCustomAttributes(typeof(FieldBaseAttribute), false).FirstOrDefault();
                if (fieldAttribute != null && fieldAttribute.FieldName == name)
                {
                    foundBlock(fieldAttribute, field);
                    break;
                }
            }
        }

        public FieldMap Parse(string line)
        {
            var fieldMap = new FieldMap();
            var fields = typeof(LogEvent).GetFields();
            var lineFields = line.Split(' ');
            var lineFieldsIndex = 0;

            foreach (var lineField in lineFields)
            {
                GetFieldAttributeByName(lineField, fields, (fieldAttribute, fieldInfo) =>
                {
                    fieldMap.Add(lineFieldsIndex, fieldAttribute.Convertor, fieldInfo);
                });
                lineFieldsIndex += 1;
            }
            return fieldMap;
        }
    }
}
