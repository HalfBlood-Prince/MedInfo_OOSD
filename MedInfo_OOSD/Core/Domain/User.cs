namespace MedInfo_OOSD.Core.Domain
{
    public class User
    {
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public string ConnectionId { get; set; }

        public string ChatGroup { get; set; }

        public bool IsAvailable { get; set; }
    }
}