namespace RegionSyd.Web.Helpers
{
    public class FullNameHelper
    {
        public static string GetFullName(string firstname, string middlename, string lastname)
        {
            var fullName = string.Empty;

            middlename = middlename != null ? middlename : "";

            fullName = firstname + " " + middlename + " " + lastname;
            return fullName;
        }
    }
}
