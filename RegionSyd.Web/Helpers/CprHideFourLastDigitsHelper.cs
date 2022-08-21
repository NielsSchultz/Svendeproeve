namespace RegionSyd.Web.Helpers
{
    public class CprHideFourLastDigitsHelper
    {
        public static string GetCprWithHidedDigits(int cpr)
        {
            var cprString = cpr.ToString();
            cprString = cprString.Substring(0, cprString.Length - 4);
            cprString = cprString + "-XXXX";
            return cprString;
        }
    }
}
