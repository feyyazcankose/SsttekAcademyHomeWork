using SsttekAcademyHomeWork.Models.Commons;
using SsttekAcademyHomeWork.Models.ViewModels.Auth;

namespace SsttekAcademyHomeWork.Models.Services.Accounts;

public interface IAccountService
{
    Task<ServiceResult<AccountViewModel>> GetProfileAsync(string userId);
    Task<ServiceResult> UpdateProfileAsync(string userId, AccountViewModel account);
    Task<ServiceResult> ChangePasswordAsync(string userId, ChangePasswordViewModel model);
}