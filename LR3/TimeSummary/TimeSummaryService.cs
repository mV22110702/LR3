namespace LR3.TimeSummary
{
    public class TimeSummaryService: ITimeSummaryService
    {
        public string GetTimeSummary(DateTime? dateTime)
        {
            dateTime = dateTime ?? DateTime.Now;


            return dateTime.Value.Hour switch
            {
                >= (int)TimeSummaryConstants.DayTimeBound.NIGHT_START and
                < (int)TimeSummaryConstants.DayTimeBound.MORNING_START => 
                TimeSummaryConstants.DayTimeNames[TimeSummaryConstants.DayTimeName.NIGHT],

                >= (int)TimeSummaryConstants.DayTimeBound.MORNING_START and
                < (int)TimeSummaryConstants.DayTimeBound.DAY_START =>
                TimeSummaryConstants.DayTimeNames[TimeSummaryConstants.DayTimeName.MORNING],

                >= (int)TimeSummaryConstants.DayTimeBound.DAY_START and
                < (int)TimeSummaryConstants.DayTimeBound.EVENING_START =>
                TimeSummaryConstants.DayTimeNames[TimeSummaryConstants.DayTimeName.DAY],

                _ => TimeSummaryConstants.DayTimeNames[TimeSummaryConstants.DayTimeName.EVENING]
            };
        }
    }
}
