namespace MySocial.Services
{
    public class BaseService : IBaseService
    {
        public BaseService(ISettings settings)
        {
            Settings = settings;
        }

        public ISettings Settings { get; set; }
    }
}