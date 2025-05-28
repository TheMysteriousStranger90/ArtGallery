using System.ComponentModel.DataAnnotations;

namespace ArtGallery.ClientApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms of service")]
        public bool AcceptTerms { get; set; } = false;

        public bool AcceptPrivacyPolicy { get; set; } = false;
        public bool AcceptMarketing { get; set; } = false;

        public bool ShowPassword { get; set; } = false;
        public bool ShowConfirmPassword { get; set; } = false;
        public bool IsLoading { get; set; } = false;

        public string ErrorMessage { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;

        public List<string> PasswordRequirements { get; set; } = new();

        public void SetLoading(bool loading)
        {
            IsLoading = loading;
            if (loading)
            {
                ErrorMessage = string.Empty;
                SuccessMessage = string.Empty;
            }
        }

        public void SetError(string message)
        {
            ErrorMessage = message;
            SuccessMessage = string.Empty;
            IsLoading = false;
        }

        public void SetSuccess(string message)
        {
            SuccessMessage = message;
            ErrorMessage = string.Empty;
            IsLoading = false;
        }

        public void UpdatePasswordStrength()
        {
            PasswordRequirements.Clear();

            if (string.IsNullOrEmpty(Password))
                return;

            if (Password.Length < 6)
                PasswordRequirements.Add("At least 6 characters");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Password, @"[a-z]"))
                PasswordRequirements.Add("At least one lowercase letter");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Password, @"[A-Z]"))
                PasswordRequirements.Add("At least one uppercase letter");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Password, @"\d"))
                PasswordRequirements.Add("At least one number");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Password, @"[^\w\s]"))
                PasswordRequirements.Add("At least one special character");
        }

        public string GetPasswordStrengthText()
        {
            if (string.IsNullOrEmpty(Password)) return "None";
            
            var score = GetPasswordScore();
            return score switch
            {
                >= 4 => "Strong",
                >= 3 => "Good",
                >= 2 => "Fair",
                >= 1 => "Weak",
                _ => "Very Weak"
            };
        }

        public string GetPasswordStrengthClass()
        {
            if (string.IsNullOrEmpty(Password)) return "text-muted";
            
            var score = GetPasswordScore();
            return score switch
            {
                >= 4 => "text-success",
                >= 3 => "text-primary",
                >= 2 => "text-info",
                >= 1 => "text-warning",
                _ => "text-danger"
            };
        }

        public string GetPasswordStrengthCssClass()
        {
            if (string.IsNullOrEmpty(Password)) return "";
            
            var score = GetPasswordScore();
            return score switch
            {
                >= 4 => "strength-strong",
                >= 3 => "strength-good",
                >= 2 => "strength-fair",
                >= 1 => "strength-weak",
                _ => "strength-very-weak"
            };
        }

        public string GetPasswordStrengthColor()
        {
            if (string.IsNullOrEmpty(Password)) return "#424242";
            
            var score = GetPasswordScore();
            return score switch
            {
                >= 4 => "#2e7d32",
                >= 3 => "#388e3c",
                >= 2 => "#fbc02d",
                >= 1 => "#f57c00",
                _ => "#d32f2f"
            };
        }

        public int GetPasswordStrengthPercentage()
        {
            if (string.IsNullOrEmpty(Password)) return 0;
            
            var score = GetPasswordScore();
            return score switch
            {
                >= 4 => 100,
                >= 3 => 80,
                >= 2 => 60,
                >= 1 => 40,
                _ => 20
            };
        }

        private int GetPasswordScore()
        {
            if (string.IsNullOrEmpty(Password)) return 0;

            int score = 0;

            if (Password.Length >= 6) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(Password, @"[a-z]")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(Password, @"[A-Z]")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(Password, @"\d")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(Password, @"[^\w\s]")) score++;

            return score;
        }
    }
}