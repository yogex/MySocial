namespace MySocial
{
    public interface ISettings
    {
        string FacebookAppKey { get; }

        string FacebookAppSecret { get; }

        string TwitterAppKey { get; }

        string TwitterAppSecret { get; }

        string FacebookUserId { get; set; }

        string FacebookUserToken { get; set; }

        string TwitterUserToken { get; set; }

        string TwitterUserTokenSecret { get; set; }
    }
}