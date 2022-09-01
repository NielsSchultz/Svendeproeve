namespace RegionSyd.Web.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetAccessToken();
    }
}