using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class LoadedLinkOpenedListener : BaseRevMobListener
	{
		public LoadedLinkOpenedListener()
		{
			Console.WriteLine("CallbackOpenLoadedLink");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("LoadNative not received!");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("LoadNative link clicked.");
		}
		public override void OnRevMobAdReceived()
		{
			Console.WriteLine("LoadNative link received.");
		}
	}
}