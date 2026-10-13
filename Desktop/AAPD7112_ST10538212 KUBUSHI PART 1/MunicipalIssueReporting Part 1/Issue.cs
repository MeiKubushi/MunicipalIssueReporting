using System;

namespace MunicipalIssueReporting
{
    public class Issue
    {
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime ReportedAt { get; set; }

        public override string ToString()
        {
            return $"[{ReportedAt:yyyy-MM-dd HH:mm}] {Category} at {Location}";
        }
    }
}