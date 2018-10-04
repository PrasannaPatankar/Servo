using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Animations.Base;
using Rg.Plugins.Popup.Interfaces.Animations;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ServoIO.Animations
{
    class UserAnimation: FadeBackgroundAnimation
    {
        private double _defaultTranslationY;

        public UserAnimation()
        {
            DurationIn = DurationOut = 300;
            EasingIn = Easing.CubicOut;
            EasingOut = Easing.CubicIn;
        }      

    }
}
