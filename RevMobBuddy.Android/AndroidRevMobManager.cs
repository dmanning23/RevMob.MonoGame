using Android.Views;
using Android.Widget;
using Com.Revmob;
using Com.Revmob.Ads.Banner;
using Com.Revmob.Ads.Interstitial;
using Microsoft.Xna.Framework;
using System;
using Color = Android.Graphics.Color;

namespace RevMobBuddy.Android
{
	public class AndroidRevMobManager : IAdManager
	{
		#region Properties

		public event EventHandler<RewardedVideoEventArgs> OnVideoReward;

		Game _game;

		LinearLayout _bannerContainer;

		FrameLayout _rootLayout;

		RevMobFullscreen interstitial;
		RevMobFullscreen video;
		RevMobFullscreen rewardedVideo;
		RevMobBanner revmobBanner;

		StartSessionListener startSessionListener;
		InterstitialListener interstitialListener;
		VideoListener videoListener;
		RewardedVideoListener videoRewardedListener;
		BannerListener bannerListener;
		CustomBannerListener customBannerAdListener;
		LinkOpenedListener openLinkListener;
		LoadedLinkOpenedListener openaLoadedLinkListener;

		#endregion //Properties

		#region Methods

		public AndroidRevMobManager(Game game, FrameLayout rootLayout)
		{
			_game = game;
			_rootLayout = rootLayout;

			startSessionListener = new StartSessionListener();
			interstitialListener = new InterstitialListener();
			videoListener = new VideoListener();

			videoRewardedListener = new RewardedVideoListener();
			videoRewardedListener.OnVideoReward += VideoReward;

			bannerListener = new BannerListener();
			customBannerAdListener = new CustomBannerListener();
			openLinkListener = new LinkOpenedListener();
			openaLoadedLinkListener = new LoadedLinkOpenedListener();
		}

		public void Initialize(string apiKey)
		{
			RevMob.StartWithListener(Game.Activity, startSessionListener, apiKey);
		}

		protected void VideoReward(object obj, RewardedVideoEventArgs e)
		{
			if (null != OnVideoReward)
			{
				OnVideoReward(obj, e);
			}
		}

		public void DisplayInterstitialAd()
		{
			if (RevMob.Session() != null)
			{
				interstitial = RevMob.Session().CreateFullscreen(Game.Activity, interstitialListener);
				interstitialListener.OnInterstitialLoaded += InterstitialLoaded;
			}
		}

		public void DisplayRewardedVideoAd()
		{
			if (RevMob.Session() != null)
			{
				rewardedVideo = RevMob.Session().CreateRewardedVideo(Game.Activity, videoRewardedListener);
				videoRewardedListener.OnVideoLoaded += RewardedVideoLoaded;
			}
		}

		public void DisplayVideoAd()
		{
			if (RevMob.Session() != null)
			{
				video = RevMob.Session().CreateVideo(Game.Activity, videoListener);
				videoListener.OnVideoLoaded += VideoLoaded;
			}
		}

		public void HideBannerAd()
		{
			if (null != revmobBanner)
			{
				revmobBanner.Release();
			}
			revmobBanner = null;

			if (null != _bannerContainer)
			{
				_rootLayout.RemoveView(_bannerContainer);
			}
			_bannerContainer = null;
		}

		public void ShowBannerAd()
		{
			if (null != _bannerContainer || null != revmobBanner)
			{
				//There is already a banner ad displayed
				HideBannerAd();
			}

			if (RevMob.Session() != null)
			{
				revmobBanner = RevMob.Session().CreateBanner(Game.Activity, "", bannerListener);
				revmobBanner.SetAutoShow(true);

				// A container to show the add at the bottom of the page
				_bannerContainer = new LinearLayout(Game.Activity);
				_bannerContainer.Orientation = Orientation.Horizontal;
				_bannerContainer.SetGravity(GravityFlags.CenterHorizontal | GravityFlags.Bottom);
				_bannerContainer.SetBackgroundColor(Color.Transparent); // Need on some devices, not sure why

				_rootLayout.AddView(_bannerContainer);
				_bannerContainer.AddView(revmobBanner);
			}
		}

		protected void InterstitialLoaded(object obj, EventArgs e)
		{
			interstitialListener.OnInterstitialLoaded -= InterstitialLoaded;
			if (interstitial != null)
			{
				interstitial.Show();
			}
		}

		protected void RewardedVideoLoaded(object obj, EventArgs e)
		{
			videoRewardedListener.OnVideoLoaded -= RewardedVideoLoaded;
			if (rewardedVideo != null)
			{
				rewardedVideo.ShowRewardedVideo();
			}
		}

		protected void VideoLoaded(object obj, EventArgs e)
		{
			videoListener.OnVideoLoaded -= VideoLoaded;
			if (video != null)
			{
				video.ShowVideo();
			}
		}

		#endregion //Methods
	}
}