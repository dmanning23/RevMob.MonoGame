using System;

namespace RevMobBuddy.DesktopGL
{
	public class TestAdManager : IAdManager
	{
		public event EventHandler<RewardedVideoEventArgs> OnVideoReward;

		public virtual void DisplayInterstitialAd()
		{
		}

		public virtual void DisplayRewardedVideoAd()
		{
		}

		public virtual void DisplayVideoAd()
		{
			VideoReward(this, new RewardedVideoEventArgs(true));
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

		protected void VideoReward(object obj, RewardedVideoEventArgs e)
		{
			if (null != OnVideoReward)
			{
				OnVideoReward(obj, e);
			}
		}
	}
}
