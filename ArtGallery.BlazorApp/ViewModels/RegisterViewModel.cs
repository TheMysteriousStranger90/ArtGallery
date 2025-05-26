using System.ComponentModel.DataAnnotations;
using ArtGallery.BlazorApp.Services;

namespace ArtGallery.BlazorApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First name can only contain letters and spaces")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last name can only contain letters and spaces")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must accept the terms and conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
        public bool AcceptTerms { get; set; } = false;

        public bool AcceptPrivacyPolicy { get; set; } = false;
        public bool AcceptMarketing { get; set; } = false;
        public bool IsLoading { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;
        public bool ShowPassword { get; set; } = false;
        public bool ShowConfirmPassword { get; set; } = false;
        public int PasswordStrength { get; private set; } = 0;
        public List<string> PasswordRequirements { get; private set; } = new();
        public Dictionary<string, bool> PasswordCriteria { get; private set; } = new();

        public RegisterCommand ToCommand()
        {
            return new RegisterCommand
            {
                FirstName = FirstName?.Trim(),
                LastName = LastName?.Trim(),
                Email = Email?.Trim().ToLower(),
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
        }

        public void UpdatePasswordStrength()
        {
            PasswordCriteria.Clear();
            PasswordRequirements.Clear();
            PasswordStrength = 0;

            if (string.IsNullOrEmpty(Password))
            {
                PasswordRequirements.Add("Password is required");
                return;
            }

            bool hasLength = Password.Length >= 6;
            PasswordCriteria["length"] = hasLength;
            if (!hasLength) PasswordRequirements.Add("At least 6 characters");
            else PasswordStrength += 20;

            bool hasLower = Password.Any(char.IsLower);
            PasswordCriteria["lowercase"] = hasLower;
            if (!hasLower) PasswordRequirements.Add("One lowercase letter");
            else PasswordStrength += 20;

            bool hasUpper = Password.Any(char.IsUpper);
            PasswordCriteria["uppercase"] = hasUpper;
            if (!hasUpper) PasswordRequirements.Add("One uppercase letter");
            else PasswordStrength += 20;

            bool hasNumber = Password.Any(char.IsDigit);
            PasswordCriteria["number"] = hasNumber;
            if (!hasNumber) PasswordRequirements.Add("One number");
            else PasswordStrength += 20;

            bool hasSpecial = Password.Any(c => !char.IsLetterOrDigit(c));
            PasswordCriteria["special"] = hasSpecial;
            if (!hasSpecial) PasswordRequirements.Add("One special character");
            else PasswordStrength += 20;
        }

        public string GetPasswordStrength()
        {
            return GetPasswordStrengthText();
        }

        public string GetPasswordStrengthText()
        {
            return PasswordStrength switch
            {
                0 => "",
                <= 20 => "Very Weak",
                <= 40 => "Weak",
                <= 60 => "Fair",
                <= 80 => "Good",
                100 => "Strong",
                _ => ""
            };
        }

        public string GetPasswordStrengthClass()
        {
            return PasswordStrength switch
            {
                <= 20 => "text-danger",
                <= 40 => "text-warning",
                <= 60 => "text-info",
                <= 80 => "text-primary",
                100 => "text-success",
                _ => "text-secondary"
            };
        }

        public string GetPasswordStrengthColor()
        {
            return PasswordStrength switch
            {
                <= 20 => "#dc3545",
                <= 40 => "#fd7e14",
                <= 60 => "#17a2b8",
                <= 80 => "#007bff",
                100 => "#28a745",
                _ => "#6c757d"
            };
        }

        public string GetPasswordStrengthCssClass()
        {
            return PasswordStrength switch
            {
                <= 20 => "strength-very-weak",
                <= 40 => "strength-weak",
                <= 60 => "strength-fair",
                <= 80 => "strength-good",
                100 => "strength-strong",
                _ => ""
            };
        }

        public int GetPasswordStrengthPercentage()
        {
            return PasswordStrength;
        }

        public string GetPasswordRequirementsText()
        {
            if (!PasswordRequirements.Any())
                return "All requirements met!";

            return string.Join(", ", PasswordRequirements);
        }

        public void Reset()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            AcceptTerms = false;
            AcceptPrivacyPolicy = false;
            AcceptMarketing = false;
            IsLoading = false;
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
            ShowPassword = false;
            ShowConfirmPassword = false;
            PasswordStrength = 0;
            PasswordRequirements.Clear();
            PasswordCriteria.Clear();
        }

        public void SetError(string error)
        {
            ErrorMessage = error;
            SuccessMessage = string.Empty;
            IsLoading = false;
        }

        public void SetSuccess(string message)
        {
            SuccessMessage = message;
            ErrorMessage = string.Empty;
            IsLoading = false;
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
    }
}