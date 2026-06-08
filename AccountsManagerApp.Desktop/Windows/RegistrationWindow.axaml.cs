using AccountsManagerApp.Desktop.Extensions;
using AccountsManagerApp.Logic;

using Avalonia.Controls;
using Avalonia.Interactivity;

using Validator = AccountsManagerApp.Logic.Validator;

namespace AccountsManagerApp.Desktop.Windows;

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
    }

    private async void OnRegistrationButton(object? sender, RoutedEventArgs args)
    {
        var account = new Account(EmailInput.Value, PasswordInput.Value!);

        if (!Validator.ValidateEmail(account.Email))
        {
            await this.ShowErrorBoxAsync("Неправильно написан email");
            return;
        }

        if (!Validator.ValidatePassword(account.Password))
        {
            await this.ShowErrorBoxAsync("Пароль должен содержать специальные символы, цифры, заглавные и строчные буквы");
            return;
        }

        if (account.Password != RepeatPasswordInput.Value)
        {
            await this.ShowErrorBoxAsync("Пароли не совпадают");
            return;
        }

        AccountRepository.Add(account);
        await this.ShowInformationBoxAsync("Аккаунт создан");
        this.JumpTo(new AuthenticationWindow());
    }

    private void OnAuthenticationButton(object? sender, RoutedEventArgs args)
    {
        this.JumpTo(new AuthenticationWindow());
    }

    private void OnReturnButton(object? sender, RoutedEventArgs args)
    {
        this.JumpTo(new AuthenticationWindow());
    }
}