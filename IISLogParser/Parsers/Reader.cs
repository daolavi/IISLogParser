using IISLogParser.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace IISLogParser.Parsers
{
    public sealed class Reader
    {
        public String Software { get; private set; }
        private TextReader TextReader { get; }

        private const string commentFields = "#Fields";

        public Reader(TextReader textReader)
        {
            TextReader = textReader;
        }

        void ParseHeader(string line, Action<string> fieldsBlock)
        {
            if (line.StartsWith(commentFields, StringComparison.OrdinalIgnoreCase))
            {
                fieldsBlock(line.Substring(commentFields.Length + 2));
            }
        }

        public IEnumerable<LogEvent> Read()
        {
            var itemParser = new ItemsParser();
            var fieldMap = (FieldMap)null;
            var line = (string)null;

            while ((line = TextReader.ReadLine()) != null)
            {
                if (line.StartsWith("#", StringComparison.OrdinalIgnoreCase))
                {
                    ParseHeader(line, (fieldsLine) =>
                    {
                        fieldMap = new FieldsParser().Parse(fieldsLine);
                    });
                    continue;
                }

                if (fieldMap == null)
                    continue;

                yield return itemParser.Parse(line, fieldMap);
            }
        }
    }
}
