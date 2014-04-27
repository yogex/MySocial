namespace MySocial.Test
{
    public class BaseTest
    {
        public ISettings Settings
        {
            get
            {
                return FakeObjectFactory.Get<ISettings>();
            }
        }
    }
}