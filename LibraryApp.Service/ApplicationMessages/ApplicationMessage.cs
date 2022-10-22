namespace LibraryApp.Service.ApplicationMessages
{
    public class ApplicationMessage
    {
        public string Message { get; set; }
        public ApplicationMessage(string message)
        {
            Message = message;
        }
    }
}
