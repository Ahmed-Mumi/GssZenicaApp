namespace GssZenicaApp.Models
{
    public class ActivityMember
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public StationActivity StationActivity { get; set; }
        public int StationActivityId { get; set; }
    }
}
