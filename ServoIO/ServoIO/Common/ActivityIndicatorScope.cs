using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServoIO.Common
{
    public class ActivityIndicatorScope : IDisposable
    {
        private bool showIndicator;
        private ActivityIndicator indicator;
        private Task indicatorDelay;
        private RelativeLayout Rlayout = new RelativeLayout();

        public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
        {
            this.indicator = indicator;
            this.showIndicator = showIndicator;

            if (showIndicator)
            {
                indicatorDelay = Task.Delay(2000);
                SetIndicatorActivity(true);
            }
            else
            {
                indicatorDelay = Task.FromResult(0);
            }
        }

        public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator, RelativeLayout RLayout)
        {
            this.indicator = indicator;
            this.showIndicator = showIndicator;
            Rlayout = RLayout;

            if (showIndicator)
            {
                indicatorDelay = Task.Delay(2000);
                SetIndicatorActivity(true);
            }
            else
            {
                indicatorDelay = Task.FromResult(0);
            }
        }

        private void SetIndicatorActivity(bool isActive)
        {
            this.indicator.IsVisible = isActive;
            this.indicator.IsRunning = isActive;
            Rlayout.IsVisible = isActive;
        }

        public void Dispose()
        {
            if (showIndicator)
            {
                indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}
