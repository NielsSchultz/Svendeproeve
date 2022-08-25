using RegionSyd.Common.DTOs;

namespace RegionSyd.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<string> Delete(int id);
        Task<UserDTO> GetById(int id);
        Task<UserDTO> Update(UserDTO userDTO);
    }
}