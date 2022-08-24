namespace RegionSyd.Web.Helpers
{
    public class CprHelper
    {
        public static string HideLastDigits(string cpr)
        {
            cpr = cpr.Substring(0, cpr.Length - 4);
            cpr = cpr + "-XXXX";
            return cpr;
        }
    }
}
