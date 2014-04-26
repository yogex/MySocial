using ReactiveUI;

namespace MySocial.ViewModels
{
    public interface INotificationViewModel : IRoutableViewModel
    {
        string Message { get; set; }

        ReactiveCommand Hide { get; }

        ReactiveCommand Show { get; }
    }
}