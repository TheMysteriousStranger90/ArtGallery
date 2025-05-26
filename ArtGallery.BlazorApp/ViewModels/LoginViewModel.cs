using System.ComponentModel.DataAnnotations;
using ArtGallery.BlazorApp.Services;

namespace ArtGallery.BlazorApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } = false;
        public bool IsLoading { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;
        public bool ShowPassword { get; set; } = false;
        public string ReturnUrl { get; set; } = string.Empty;
        public int LoginAttempts { get; set; } = 0;
        public DateTime? LastAttempt { get; set; }
        public bool IsAccountLocked { get; set; } = false;

        public AuthenticateCommand ToCommand()
        {
            return new AuthenticateCommand
            {
                Email = Email?.Trim().ToLower(),
                Password = Password
            };
        }

        public void Reset()
        {
            Email = string.Empty;
            Password = string.Empty;
            RememberMe = false;
            IsLoading = false;
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
            ShowPassword = false;
            LoginAttempts = 0;
            LastAttempt = null;
            IsAccountLocked = false;
        }

        public void SetError(string error)
        {
            ErrorMessage = error;
            SuccessMessage = string.Empty;
            IsLoading = false;
            LoginAttempts++;
            LastAttempt = DateTime.Now;

            if (LoginAttempts >= 5)
            {
                IsAccountLocked = true;
                ErrorMessage =
                    "Account temporarily locked due to multiple failed login attempts. Please try again in 15 minutes.";
            }
        }

        public void SetSuccess(string message)
        {
            SuccessMessage = message;
            ErrorMessage = string.Empty;
            IsLoading = false;
            LoginAttempts = 0;
            IsAccountLocked = false;
        }

        public void SetLoading(bool loading)
        {
            IsLoading = loading;
            if (loading)
            {
                ErrorMessage = string.Empty;
                SuccessMessage = string.Empty;
            }
        }

        public bool CanAttemptLogin()
        {
            if (!IsAccountLocked) return true;
            if (LastAttempt.HasValue && DateTime.Now.Subtract(LastAttempt.Value).TotalMinutes >= 15)
            {
                IsAccountLocked = false;
                LoginAttempts = 0;
                return true;
            }

            return false;
        }
    }
}