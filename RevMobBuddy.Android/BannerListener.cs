using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class BannerListener : BaseRevMobListener
	{
		public BannerListener()
		{
			Console.WriteLine("CallbackShowBanner");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("Banner not received!");
		}

		public override void OnRevMobAdReceived()
		{
			Console.WriteLine("Banner ad received and ready to be displayed.");
		}

		public override void OnRevMobAdDismissed()
		{
			Console.WriteLine("Banner dismissed!");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("Banner clicked!");
		}

		public override void OnRevMobAdDisplayed()
		{
			Console.WriteLine("Banner displayed!");
		}
	}
}