using ProductFake.Application.DTOs.Account.Requests;
using ProductFake.Application.DTOs.Account.Responses;
using ProductFake.Application.Wrappers;
using System.Threading.Tasks;

namespace ProductFake.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
