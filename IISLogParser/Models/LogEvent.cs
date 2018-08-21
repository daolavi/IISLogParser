using IISLogParser.Attributes;
using System;

namespace IISLogParser.Models
{
    public class LogEvent
    {
        [FieldDate("date")]
        public DateTimeOffset Date;

        [FieldTime("time")]
        public DateTimeOffset Time;

        [Field("s-ip")]
        public string ServerIpAddress;

        [Field("cs-method")]
        public string Method;

        [Field("cs-uri-stem")]
        public string UriStem;

        [Field("cs-uri-query")]
        public string UriQuery;

        [Int32("s-port")]
        public int Port;

        [Field("cs-username")]
        public string Username;

        [Field("c-ip")]
        public string ClientIpAddress;

        [Field("cs(User-Agent)")]
        public string Agent;

        [Field("cs(Referer)")]
        public string Referer;

        [Int32("sc-status")]
        public int Status;

        [Int32("sc-substatus")]
        public int SubStatus;

        [Int32("sc-win32-status")]
        public int Win32Status;

        [Int32("time-taken")]
        public int TimeTaken;

        [Int32("sc-bytes")]
        public int BytesSent;

        [Int32("cs-bytes")]
        public int BytesReceived;

        [Field("host")]
        public string Host;
    }
}
