namespace ChatServerApi.Domain.Entity
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public Guid chanelId { get; set; }
        public DateTime dateTime { get; set; }

    }
}
