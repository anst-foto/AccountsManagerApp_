using AccountsManagerApp.Desktop.Extensions;
using AccountsManagerApp.Logic;

using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AccountsManagerApp.Desktop.Windows;

public partial class RecoveryWindow : Window
{
    public RecoveryWindow()
    {
        InitializeComponent();
    }

    private async void OnChangePasswordButton(object? sender, RoutedEventArgs args)
    {
        var account = new Account(EmailInput.Value, PasswordInput.Value!);

        if (!Validator.ValidatePassword(account.Password))
        {
            await this.ShowErrorBoxAsync(
                "Пароль должен содержать специальные символы, цифры, заглавные и строчные буквы"
            );
            return;
        }

        if (account.Password != RepeatPasswordInput.Value)
        {
            await this.ShowErrorBoxAsync("Пароли не совпадают");
            return;
        }

        if (AccountRepository.UpdatePassword(account.Email, account.Password))
        {
            await this.ShowInformationBoxAsync("Пароль сменился");
            OnReturnButton(sender, args);
        }
        else
        {
            await this.ShowErrorBoxAsync("Почта не найдена");
        }
    }

    private void OnReturnButton(object? sender, RoutedEventArgs args)
    {
        this.JumpTo(new AuthenticationWindow());
    }
}