using System;

namespace RtmNet
{
	/// <summary>
	/// DateGranularity, used for setting taken date in <see cref="Rtm.PhotosSetDates(string, DateTime, DateGranularity)"/> 
    /// or <see cref="Rtm.PhotosSetDates(string, DateTime, DateTime, DateGranularity)"/>.
	/// </summary>
	public enum DateGranularity
	{
		/// <summary>
		/// The date specified is the exact date the photograph was taken.
		/// </summary>
		FullDate = 0,
		/// <summary>
		/// The date specified is the year and month the photograph was taken.
		/// </summary>
		YearMonthOnly = 4,
		/// <summary>
		/// The date specified is the year the photograph was taken.
		/// </summary>
		YearOnly = 6
	}
}
