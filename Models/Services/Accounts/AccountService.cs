using SsttekAcademyHomeWork.Models.Commons;
using SsttekAcademyHomeWork.Models.Repositories.Users;
using SsttekAcademyHomeWork.Models.ViewModels.Auth;

namespace SsttekAcademyHomeWork.Models.Services.Accounts;

public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<AccountViewModel>> GetProfileAsync(string userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult<AccountViewModel>.ErrorResult("Kullanıcı bulunamadı.");

            var account = new AccountViewModel
            {
                Username = user.UserName,
                Email = user.Email
            };

            return ServiceResult<AccountViewModel>.SuccessResult(account);
        }

        public async Task<ServiceResult> UpdateProfileAsync(string userId, AccountViewModel account)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            user.UserName = account.Username;
            user.Email = account.Email;

            var result = await _userRepository.UpdateUserAsync(user);
            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Profil güncellenemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult("Profil başarıyla güncellendi.");
        }

        public async Task<ServiceResult> ChangePasswordAsync(string userId, ChangePasswordViewModel model)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return ServiceResult.ErrorResult("Kullanıcı bulunamadı.");

            var result = await _userRepository.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
                return ServiceResult.ErrorResult("Şifre değiştirilemedi.", result.Errors.Select(e => e.Description).ToList());

            return ServiceResult.SuccessResult("Şifre başarıyla değiştirildi.");
        }
    }