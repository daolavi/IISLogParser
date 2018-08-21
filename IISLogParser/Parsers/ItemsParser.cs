using IISLogParser.Models;

namespace IISLogParser.Parsers
{
    public class ItemsParser
    {
        public LogEvent Parse(string line, FieldMap fieldMap)
        {
            var returnValue = new LogEvent();
            var fieldValueIndex = 0;

            foreach (var fieldValue in line.Split(' '))
            {
                if (fieldMap.ContainsKey(fieldValueIndex))
                {
                    var fieldInfo = fieldMap[fieldValueIndex];
                    fieldInfo.FieldInfo.SetValue(returnValue, fieldInfo.Convertor.Convert(fieldValue));
                }
                fieldValueIndex += 1;
            }

            return returnValue;
        }
    }
}
