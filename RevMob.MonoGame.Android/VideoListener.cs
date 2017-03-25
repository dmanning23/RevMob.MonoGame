using Android.App;
using Com.Revmob;
using System;

namespace RevMobBuddy.Android
{
	internal class VideoListener : BaseRevMobListener
	{
		public event EventHandler OnVideoLoaded;

		public VideoListener()
		{
			Console.WriteLine("CallbackVideoLoaded");
		}

		public override void OnRevMobAdDismissed()
		{
			Console.WriteLine("Video closed.");
		}

		public override void OnRevMobAdClicked()
		{
			Console.WriteLine("Video clicked.");
		}

		public override void OnRevMobVideoLoaded()
		{
			Console.WriteLine("Video loaded.");
			if (null != OnVideoLoaded)
			{
				OnVideoLoaded(this, new EventArgs());
			}
		}

		public override void OnRevMobVideoStarted()
		{
			Console.WriteLine("Video started.");
		}

		public override void OnRevMobVideoFinished()
		{
			Console.WriteLine("Video finished.");
		}

		public override void OnRevMobVideoNotCompletelyLoaded()
		{
			Console.WriteLine("Video not completely loaded.");
		}

		public override void OnRevMobAdNotReceived(String error)
		{
			Console.WriteLine("Video failed");
		}
	}
}