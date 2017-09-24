using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class CustomBannerListener : BaseRevMobListener
	{
		public CustomBannerListener()
		{
			Console.WriteLine("CallbackShowCustomBanner");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("Custom Banner not received!");
		}

		public override void OnRevMobAdReceived()
		{
			Console.WriteLine("Custom Banner ad received and ready to be displayed.");
		}

		public override void OnRevMobAdDismissed()
		{
			Console.WriteLine("Custom Banner dismissed!");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("Custom Banner clicked!");
		}

		public override void OnRevMobAdDisplayed()
		{
			Console.WriteLine("Custom Banner displayed!");
		}
	}
}