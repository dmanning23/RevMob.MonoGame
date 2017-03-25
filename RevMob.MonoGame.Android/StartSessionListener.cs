using System;

namespace RevMobBuddy.Android
{
	internal class StartSessionListener : BaseRevMobListener
	{
		public StartSessionListener()
		{
			Console.WriteLine("CallbackStartSessionListener");
		}

		public override void OnRevMobSessionStarted()
		{
			Console.WriteLine("Session started");
		}

		public override void OnRevMobSessionNotStarted(String error)
		{
			Console.WriteLine("RevMob session failed to start.");
		}
	}
}