using XFDoggy.Infrastructure;
using XFDoggy.iOS.Infrastructure;

[assembly: Xamarin.Forms.Dependency(typeof(DebugMode))]
namespace XFDoggy.iOS.Infrastructure
{
    public class DebugMode : IDebugMode
    {
        public bool IsDebugMode()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
