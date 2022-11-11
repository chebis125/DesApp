namespace Findergers1._0.Models.Request
{
    public class ReportDesapEditRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string description { get; set; }
        public DateTime? disappDate { get; set; }
        public byte[]? image { get; set; }
    }
}
