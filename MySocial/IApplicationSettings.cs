namespace MySocial
{
    public interface IApplicationSettings
    {
        string FacebookAppKey { get; }

        string FacebookAppSecret { get; }

        string TwitterAppKey { get; }

        string TwitterAppSecret { get; }
    }
}