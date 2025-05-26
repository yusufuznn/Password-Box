namespace PasswordBox.Web.Models.ViewModels
{
    public class EditDataRequest
    {
        public Guid Id { get; set; }
        public string WebsiteName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
