namespace ShouterMVC.Services.Tools
{
    using System;
    using Models;

    public static class RelativeTimeCalculator
    {
        public static string Calculate(Shout shout)
        {
            TimeSpan timeSpan = shout.CalculateLifespan();
            if (timeSpan.TotalSeconds < 1)
            {
                return "less than a second";
            }
            else if (timeSpan.TotalMinutes < 1)
            {
                return "less than a minute";
            }
            else if (timeSpan.TotalHours < 1)
            {
                return $"{(int)timeSpan.TotalMinutes} minutes ago";
            }
            else if (timeSpan.TotalDays < 1)
            {
                return $"{(int)timeSpan.TotalHours} hours ago";
            }
            else if (timeSpan.TotalDays < 30)
            {
                return $"{(int)timeSpan.TotalDays} days ago";
            }
            else if (timeSpan.TotalDays < 365)
            {
                return $"{(int)timeSpan.TotalDays / 30} months ago";
            }
            else
            {
                return "more than a year";
            }
        }
    }
}
