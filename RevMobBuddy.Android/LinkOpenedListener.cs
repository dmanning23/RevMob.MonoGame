using System;

namespace RevMobBuddy.Android
{
	class LinkOpenedListener : BaseRevMobListener
	{
		public LinkOpenedListener()
		{
			Console.WriteLine("CallbackOpenLink");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("Native not received!");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("Native link clicked.");
		}
	}
}