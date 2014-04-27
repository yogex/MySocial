namespace MySocial.Models
{
    public class TwitterUser : User
    {
        public string TwitterUsername { get; set; }

        public string TwitterUserId { get; set; }

        public string TwitterUserToken { get; set; }

        public string TwitterUrl { get; set; }
    }
}