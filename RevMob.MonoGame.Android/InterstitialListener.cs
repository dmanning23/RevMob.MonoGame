using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class InterstitialListener : BaseRevMobListener
	{
		public event EventHandler OnInterstitialLoaded;

		public InterstitialListener()
		{
			Console.WriteLine("CallbackShowLoadFullscreen");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("LoadFullscreen not received!");
		}

		public override void OnRevMobAdReceived()
		{
			Console.WriteLine("LoadFullscreen ad received and ready to be displayed.");
			if (null != OnInterstitialLoaded)
			{
				OnInterstitialLoaded(this, new EventArgs());
			}
		}

		public override void OnRevMobAdDismissed()
		{
			Console.WriteLine("LoadFullscreen dismissed.");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("LoadFullscreen clicked.");
		}

		public override void OnRevMobAdDisplayed()
		{
			Console.WriteLine("loadFullscreen displayed!");
		}
	}
}