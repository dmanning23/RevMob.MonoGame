using System;
using System.Threading.Tasks;

namespace RevMobBuddy
{
	public interface IAdManager
	{
		void Initialize();

		void ShowBannerAd();

		void HideBannerAd();

		void DisplayInterstitialAd();

		void DisplayVideoAd();

		void DisplayRewardedVideoAd();

		event EventHandler OnVideoReward;
	}
}