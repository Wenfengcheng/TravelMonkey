using System.Linq;
using TravelMonkey.Effects;
using TravelMonkey.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("TravelMonkey")]
[assembly: ExportEffect(typeof(SafeAreaPaddingEffect_iOS), "SafeAreaPaddingEffect")]
namespace TravelMonkey.iOS.Effects
{
    public class SafeAreaPaddingEffect_iOS : PlatformEffect
    {
        Thickness _padding;
        protected override void OnAttached()
        {
            try
            {
                var effect = (SafeAreaPaddingEffect)Element.Effects.FirstOrDefault(e => e is SafeAreaPaddingEffect);
                if (effect != null && Element is Layout element)
                {
                    if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                    {
                        _padding = element.Padding;
                        var insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets;

                        if (insets.Top > 0)
                        {
                            if (!effect.Revert)
                                element.Padding = new Thickness(_padding.Left + insets.Left, _padding.Top + insets.Top, _padding.Right + insets.Right, _padding.Bottom + insets.Bottom);
                            else
                                element.Padding = new Thickness(_padding.Left - insets.Left, _padding.Top - insets.Top, _padding.Right - insets.Right, _padding.Bottom - insets.Bottom);
                            return;
                        }
                    }
                    if (!effect.Revert)
                        element.Padding = new Thickness(_padding.Left, _padding.Top + 20, _padding.Right, _padding.Bottom + 20);
                    else
                        element.Padding = new Thickness(_padding.Left, _padding.Top - 20, _padding.Right, _padding.Bottom - 20);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }

        }

        protected override void OnDetached()
        {
            if (Element is Layout element)
            {
                element.Padding = _padding;
            }
        }
    }
}