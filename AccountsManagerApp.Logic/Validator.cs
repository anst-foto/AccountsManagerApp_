using System.Text.RegularExpressions;

namespace AccountsManagerApp.Logic;

public static partial class Validator
{
    [GeneratedRegex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]).{8,}$")]
    private static partial Regex PasswordPattern();
    
    public static bool ValidatePassword(string password)
    {
        return password.Length >= 8 && PasswordPattern().IsMatch(password);
    }
    
    public static bool ValidateEmail(string email)
    {
        return email.Contains('@') && email.Contains('.');
    }
}