using System;
using System.Globalization;

namespace IISLogParser.Convertors
{
    public class TimeConvertor : ITextConvertor
    {
        public dynamic Convert(string text) => DateTimeOffset.ParseExact(text, "HH':'mm':'ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    }
}
