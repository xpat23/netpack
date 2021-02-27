namespace RxCore.ApiModule
{
    public class Message
    {
        public Message(string text, string id = "")
        {
            Id = id;
            Text = text;
        }

        public string Id { get; set; }
        public string Text { get; set; }
    }
}