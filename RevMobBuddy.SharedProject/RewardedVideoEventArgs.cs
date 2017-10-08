using System;

namespace RevMobBuddy
{
	/// <summary>
	/// The event argumnets that get fired off when the number is manually edited in a NumEdit using the numpad
	/// </summary>
	public class RewardedVideoEventArgs : EventArgs
	{
		public bool Success { get; set; }

		public RewardedVideoEventArgs(bool success)
		{
			Success = success;
		}
	}
}
