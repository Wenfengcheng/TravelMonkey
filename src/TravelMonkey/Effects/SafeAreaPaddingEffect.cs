using Xamarin.Forms;

namespace TravelMonkey.Effects
{
    public class SafeAreaPaddingEffect : RoutingEffect
    {
        public bool Revert { get; set; }

        public SafeAreaPaddingEffect() : base("TravelMonkey.SafeAreaPaddingEffect")
        {
        }
    }
}