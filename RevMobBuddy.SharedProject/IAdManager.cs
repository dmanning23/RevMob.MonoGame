using System;
using System.Threading.Tasks;

namespace RevMobBuddy
{
	public interface IAdManager
	{
		void Initialize(string apiKey);

		void ShowBannerAd();

		void HideBannerAd();

		void DisplayInterstitialAd();

		void DisplayVideoAd();

		void DisplayRewardedVideoAd();

		event EventHandler<RewardedVideoEventArgs> OnVideoReward;
	}
}