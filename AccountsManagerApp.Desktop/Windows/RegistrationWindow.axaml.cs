using System.ComponentModel.DataAnnotations;

using AccountsManagerApp.Logic;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

using Validator = AccountsManagerApp.Logic.Validator;

namespace AccountsManagerApp.Desktop.Windows;

public partial class RegistrationWindow : Window
{
    public RegistrationWindow()
    {
        InitializeComponent();
    }

    private void ShowError(string message)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(
            title: "Ошибка",
            text: message,
            @enum: ButtonEnum.Ok,
            icon: MsBox.Avalonia.Enums.Icon.Error,
            windowStartupLocation: WindowStartupLocation.CenterScreen);

        box.ShowAsPopupAsync(this);
    }

    private void OnRegistrationButton(object? sender, RoutedEventArgs args)
    {
        var account = new Account(EmailInput.Value, PasswordInput.Value!);

        if (!Validator.ValidateEmail(account.Email))
        {
            ShowError("Неправильно написан email");
            return;
        }

        if (!Validator.ValidatePassword(account.Password))
        {
            ShowError("Пароль должен содержать специальные символы, цифры, заглавные и строчные буквы");
            return;
        }

        if (account.Password != RepeatPasswordInput.Value)
        {
            ShowError("Пароли не совпадают");
            return;
        }

        AccountRepository.Add(account);
        ShowError("Аккаунт создан");
        OnAuthenticationButton(sender, args);
    }

    private void OnAuthenticationButton(object? sender, RoutedEventArgs args)
    {
        var window = GetTopLevel(this) as Window;
        var newWindow = new AuthenticationWindow();

        newWindow.Show();

        window!.Close();
    }

    private void OnReturnButton(object? sender, RoutedEventArgs args)
    {
        OnAuthenticationButton(sender, args);
    }
}