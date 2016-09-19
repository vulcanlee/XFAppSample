using Prism.Unity;
using XFDoggy.Views;

namespace XFDoggy
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("LoadingPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoadingPage>();
            Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
