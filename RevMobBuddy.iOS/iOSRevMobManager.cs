using Foundation;
using RevmobAds;
using System;

namespace RevMobBuddy.iOS
{
	public class iOSRevMobManager : NSObject, IAdManager
	{
		#region Properties

		public event EventHandler OnVideoReward;

		RevMobFullscreen loadfullscreen;
		RevMobFullscreen video;
		RevMobFullscreen rewardedVideo;
		RevMobBanner banner;

		#endregion //Properties

		#region Methods

		public void Initialize(string apiKey)
		{
			Action<NSError> actionError = revmobSessionDidNotStartWithError;
			Action action = revmobSessionDidStart;
			RevMobAds.StartSessionWithAppID(apiKey, action, actionError);
		}

		public void DisplayInterstitialAd()
		{
			if (RevMobAds.Session != null)
			{
				loadfullscreen = RevMobAds.Session.Fullscreen;
				loadfullscreen.WeakDelegate = this;
				loadfullscreen.LoadAd();
			}
		}

		public void DisplayRewardedVideoAd()
		{
			if (RevMobAds.Session != null)
			{
				rewardedVideo = RevMobAds.Session.Fullscreen;
				rewardedVideo.WeakDelegate = this;
				rewardedVideo.LoadRewardedVideo();
			}
		}

		public void DisplayVideoAd()
		{
			if (RevMobAds.Session != null)
			{
				video = RevMobAds.Session.Fullscreen;
				video.WeakDelegate = this;
				video.LoadVideo();
			}
		}

		public void HideBannerAd()
		{
			if (banner != null)
			{
				banner.ReleaseAd();
				banner = null;
			}
		}

		public void ShowBannerAd()
		{
			if (RevMobAds.Session != null)
			{
				banner = RevMobAds.Session.Banner;
				banner.WeakDelegate = this;
				banner.LoadAd();
			}
		}

		#region Listeners

		#region Session

		public void revmobSessionDidStart()
		{
			Console.WriteLine("revmobSessionDidStart");
		}

		public void revmobSessionDidNotStartWithError(NSError error)
		{
			Console.WriteLine("revmobSessionDidNotStartWithError");
		}

		#endregion //Session

		#region Native

		[Export("revmobUserDidClickOnNative:")]
		public void revmobUserDidClickOnNative(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnNative");
		}

		[Export("revmobNativeDidReceive:")]
		public void revmobNativeDidReceive(String placementId)
		{
			Console.WriteLine("revmobNativeDidReceive");
		}

		[Export("revmobNativeDidFailWithError:")]
		public void revmobNativeDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobNativeDidFailWithError");
		}

		#endregion //Native

		#region Interstitial

		[Export("revmobUserDidClickOnFullscreen:")]
		public void revmobUserDidClickOnFullscreen(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnFullscreen");
		}

		[Export("revmobFullscreenDidReceive:")]
		public void revmobFullscreenDidReceive(String placementId)
		{
			Console.WriteLine("revmobFullscreenDidReceive");
			if (loadfullscreen != null)
			{
				loadfullscreen.ShowAd();
			}
		}

		[Export("revmobFullscreenDidFailWithError:")]
		public void revmobFullscreenDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobFullscreenDidFailWithError");
		}

		[Export("revmobFullscreenDidDisplay:")]
		public void revmobFullscreenDidDisplay(String placementId)
		{
			Console.WriteLine("revmobFullscreenDidDisplay");
		}

		[Export("revmobUserDidCloseFullscreen:")]
		public void revmobUserDidCloseFullscreen(String placementId)
		{
			Console.WriteLine("revmobUserDidCloseFullscreen");
		}

		#endregion //Interstitial

		#region Banner

		[Export("revmobUserDidClickOnBanner:")]
		public void revmobUserDidClickOnBanner(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnBanner");
		}

		[Export("revmobBannerDidReceive:")]
		public void revmobBannerDidReceive(String placementId)
		{
			Console.WriteLine("revmobBannerDidReceive");
			if (banner != null)
			{
				banner.ShowAd();
			}
		}

		[Export("revmobBannerDidFailWithError:")]
		public void revmobBannerDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobBannerDidFailWithError");
		}

		[Export("revmobBannerDidDisplay:")]
		public void revmobBannerDidDisplay(String placementId)
		{
			Console.WriteLine("revmobBannerDidDisplay");
		}

		#endregion //Banner

		#region Video

		[Export("revmobVideoDidLoad:")]
		public void revmobVideoDidLoad(String placementId)
		{
			Console.WriteLine("revmobVideoDidLoad");
			if (video != null)
			{
				video.ShowVideo();
			}
		}

		[Export("revmobVideoDidFailWithError:")]
		public void revmobVideoDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobVideoDidFailWithError");
		}

		[Export("revmobVideoNotCompletelyLoaded:")]
		public void revmobVideoNotCompletelyLoaded(String placementId)
		{
			Console.WriteLine("revmobVideoNotCompletelyLoaded");
		}

		[Export("revmobVideoDidStart:")]
		public void revmobVideoDidStart(String placementId)
		{
			Console.WriteLine("revmobVideoDidStart");
		}

		[Export("revmobVideoDidFinish:")]
		public void revmobVideoDidFinish(String placementId)
		{
			Console.WriteLine("revmobVideoDidFinish");
		}

		[Export("revmobUserDidCloseVideo:")]
		public void revmobUserDidCloseVideo(String placementId)
		{
			Console.WriteLine("revmobUserDidCloseVideo");
		}

		[Export("revmobUserDidClickOnVideo:")]
		public void revmobUserDidClickOnVideo(String placementId)
		{
			Console.WriteLine("revmobUserDidClickOnVideo");
		}

		#endregion //Video

		#region RewardedVideo

		[Export("revmobRewardedVideoDidLoad:")]
		public void revmobRewardedVideoDidLoad(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidLoad");
			if (rewardedVideo != null)
			{
				rewardedVideo.ShowRewardedVideo();
			}
		}

		[Export("revmobRewardedVideoDidFailWithError:")]
		public void revmobRewardedVideoDidFailWithError(NSError error)
		{
			Console.WriteLine("revmobRewardedVideoDidFailWithError");
		}

		[Export("revmobRewardedVideoNotCompletelyLoaded:")]
		public void revmobRewardedVideoNotCompletelyLoaded(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoNotCompletelyLoaded");
		}

		[Export("revmobRewardedVideoDidStart:")]
		public void revmobRewardedVideoDidStart(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidStart");
		}

		[Export("revmobRewardedVideoDidComplete:")]
		public void revmobRewardedVideoDidComplete(String placementId)
		{
			Console.WriteLine("revmobRewardedVideoDidComplete");
			if (null != OnVideoReward)
			{
				OnVideoReward(this, new EventArgs());
			}
		}

		#endregion //RewardedVideo

		#endregion //Listeners

		#endregion //Methods
	}
}
