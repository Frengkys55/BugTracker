namespace Tools.Misc;

public static class DateTimeToStringConverter{
    public static string Convert(DateTime input){
        string ConvertedDate = string.Empty;
        #region Month
        if (input.Month == 1)
        {
            ConvertedDate += "January ";
        }
        else if (input.Month == 2)
        {
            ConvertedDate += "February ";
        }
        else if (input.Month == 3)
        {
            ConvertedDate += "March ";
        }
        else if (input.Month == 4)
        {
            ConvertedDate += "April ";
        }
        else if (input.Month == 5)
        {
            ConvertedDate += "May ";
        }
        else if (input.Month == 6)
        {
            ConvertedDate += "June ";
        }
        else if (input.Month == 7)
        {
            ConvertedDate += "July ";
        }
        else if (input.Month == 8)
        {
            ConvertedDate += "August ";
        }
        else if (input.Month == 9)
        {
            ConvertedDate += "September ";
        }
        else if (input.Month == 10)
        {
            ConvertedDate += "October ";
        }
        else if (input.Month == 11)
        {
            ConvertedDate += "November ";
        }
        else if (input.Month == 12)
        {
            ConvertedDate += "December ";
        }
        #endregion Month

        #region Date
        if(input.Day.ToString()[^1] == '1' && input.Day != 11) ConvertedDate += input.Day + "st, ";
        else if(input.Day.ToString()[^1] == '2' && input.Day != 12) ConvertedDate += input.Day + "nd, ";
        else if(input.Day.ToString()[^1] == '3' && input.Day != 13) ConvertedDate += input.Day + "rd, ";
        else ConvertedDate += input.Day + "th, ";
        #endregion Date

        #region Year
        ConvertedDate += input.Year;
        #endregion Year
        return ConvertedDate;
    }
}