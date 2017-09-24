using RevMobBuddy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMobBuddy.DesktopGL
{
	public class TestAdManager : IAdManager
	{
		public event EventHandler OnVideoReward;

		public virtual void DisplayInterstitialAd()
		{
		}

		public virtual void DisplayRewardedVideoAd()
		{
		}

		public virtual void DisplayVideoAd()
		{
		}

		public virtual void HideBannerAd()
		{
		}

		public virtual void Initialize(string apiKey)
		{
		}

		public virtual void ShowBannerAd()
		{
		}

		protected void VideoReward()
		{
			if (null != OnVideoReward)
			{
				OnVideoReward(this, new EventArgs());
			}
		}
	}
}
