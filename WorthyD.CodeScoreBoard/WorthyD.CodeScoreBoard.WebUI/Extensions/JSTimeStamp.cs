using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorthyD.CodeScoreBoard.WebUI.Extensions
{
    public static class JSTimeStamp
    {

        //Found this from: http://stackoverflow.com/questions/5116993/jquery-flot-with-asp-net-mvc-and-datetime-properties
        public static long ToJavascriptTimestamp(this DateTime input)
        {
            TimeSpan span = new TimeSpan(new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
            DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
    }
}