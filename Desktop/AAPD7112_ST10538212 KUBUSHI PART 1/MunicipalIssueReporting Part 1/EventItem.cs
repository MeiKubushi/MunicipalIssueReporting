using System;

namespace MunicipalIssueReporting
{
    public class EventItem
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Date:yyyy-MM-dd} | {Title} — {Location}";
        }
    }
}