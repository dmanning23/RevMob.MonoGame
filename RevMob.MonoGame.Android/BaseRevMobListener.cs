using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class BaseRevMobListener : RevMobAdsListener
	{
		public override void OnRevMobAdNotReceived(string msg)
		{
			Console.WriteLine(string.Format("There was an error loading the ad: {0}", msg));
		}
	}
}