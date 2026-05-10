using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared
{
    public class EventLogger
    {
        static string source = "DVLD Application";
        public static void LogEvent(Exception ex)
        {
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }

            EventLog.WriteEntry(source, ex.ToString(), EventLogEntryType.Error);

        }

    }
}
