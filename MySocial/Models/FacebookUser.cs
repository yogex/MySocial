namespace MySocial.Models
{
    public class FacebookUser : User
    {
        public string FacebookUserToken { get; set; }

        public string FacebookUserId { get; set; }

        public string FacebookUsername { get; set; }

        public string FacebookUrl { get; set; }
    }
}