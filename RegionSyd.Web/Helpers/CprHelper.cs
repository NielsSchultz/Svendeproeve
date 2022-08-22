namespace RegionSyd.Web.Helpers
{
    public class CprHelper
    {
        public static string HideLastDigits(int cpr)
        {
            var cprString = cpr.ToString();
            cprString = cprString.Substring(0, cprString.Length - 4);
            cprString = cprString + "-XXXX";
            return cprString;
        }
    }
}
