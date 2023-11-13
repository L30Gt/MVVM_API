using MVVM_API_SampleProject.ViewModels;

namespace MVVM_API_SampleProject.Views;

public partial class UserView : ContentPage
{
	public UserView()
	{
		InitializeComponent();
        BindingContext = new UserViewModel();

    }
}