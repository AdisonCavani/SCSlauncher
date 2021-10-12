using System.Windows;
using System.Windows.Controls.Primitives;

namespace SCSlauncher
{
    public class Toggle : ToggleButton
    {

        static Toggle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Toggle), new FrameworkPropertyMetadata(typeof(Toggle)));
        }
    }
}
