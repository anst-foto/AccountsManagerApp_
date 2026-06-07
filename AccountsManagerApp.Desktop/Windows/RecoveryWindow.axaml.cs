using AccountsManagerApp.Logic;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AccountsManagerApp.Desktop.Windows;

public partial class RecoveryWindow : Window
{
    public RecoveryWindow()
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

    private void OnChangePasswordButton(object? sender, RoutedEventArgs args)
    {
        var account = new Account(EmailInput.Value, PasswordInput.Value!);

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

        if (AccountRepository.UpdatePassword(account.Email, account.Password))
        {
            ShowError("Пароль сменился");
        }
        else
        {
            ShowError("Почта на найдена");
        }
    }

    private void OnReturnButton(object? sender, RoutedEventArgs args)
    {
        var window = GetTopLevel(this) as Window;
        var newWindow = new AuthenticationWindow();

        newWindow.Show();

        window!.Close();
    }
}