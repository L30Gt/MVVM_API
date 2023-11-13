using MVVM_API_SampleProject.ViewModels;

namespace MVVM_API_SampleProject.Views;

public partial class PhotoView : ContentPage
{
	public PhotoView()
	{
		InitializeComponent();
        BindingContext = new PhotoViewModel();
    }
}