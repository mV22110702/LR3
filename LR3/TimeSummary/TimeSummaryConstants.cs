
namespace LR3.TimeSummary
{
    public static class TimeSummaryConstants
    {
        public enum DayTimeBound
        {
            MORNING_START = 6,
            DAY_START = 12,
            EVENING_START = 18,
            EVENING_END = 23,
            NIGHT_START = 0
        }

        public enum DayTimeName
        {
            MORNING,
            DAY,
            EVENING,
            NIGHT
        }

        public static readonly IDictionary<DayTimeName, string> DayTimeNames = new Dictionary<DayTimeName, string>() {
            { DayTimeName.MORNING, "Зараз ранок" },
            { DayTimeName.DAY, "Зараз день" },
            { DayTimeName.EVENING, "Зараз вечір" },
            { DayTimeName.NIGHT, "Зараз ніч" },
        };
    }
}
