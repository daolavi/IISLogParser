using IISLogParser.Convertors;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IISLogParser.Models
{
    public class FieldMap
    {
        public class FieldMapInfo
        {
            public readonly ITextConvertor Convertor;
            public readonly FieldInfo FieldInfo;

            public FieldMapInfo(ITextConvertor convertorType, FieldInfo fieldInfo)
            {
                Convertor = convertorType;
                FieldInfo = fieldInfo;
            }
        }

        public readonly Dictionary<int, FieldMapInfo> FieldDictionary = new Dictionary<int, FieldMapInfo>();

        public bool IsEmpty() => !FieldDictionary.Any();

        public bool ContainsKey(int key) => FieldDictionary.ContainsKey(key);

        public FieldMapInfo this[int key] => FieldDictionary[key];

        public void Add(int fieldIndex, ITextConvertor convertorType, FieldInfo fieldInfo)
        {
            FieldDictionary.Add(fieldIndex, new FieldMapInfo(convertorType, fieldInfo));
        }
    }
}
