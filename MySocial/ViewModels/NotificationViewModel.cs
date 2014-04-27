using ReactiveUI;

namespace MySocial.ViewModels
{
    public class NotificationViewModel : BaseViewModel, INotificationViewModel
    {
        private string _message;

        public NotificationViewModel(IScreen screen)
        {
            HostScreen = screen;

            InitData();
            InitCommands();
        }

        public ReactiveCommand Hide { get; protected set; }

        public ReactiveCommand Show { get; protected set; }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                this.RaiseAndSetIfChanged<NotificationViewModel, string>(ref _message, value);
            }
        }

        protected void InitData()
        {
            Message = Properties.Resources.WelcomeMessage;
        }

        protected void InitCommands()
        {
            Hide = new ReactiveCommand();
            Show = new ReactiveCommand();
        }

        public IScreen HostScreen { get; private set; }

        public string UrlPathSegment
        {
            get { return "notification"; }
        }
    }
}