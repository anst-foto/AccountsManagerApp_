using AccountsManagerApp.Desktop.Controls;
using AccountsManagerApp.Logic;

using Avalonia.Controls;
using Avalonia.Interactivity;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AccountsManagerApp.Desktop.Windows;

public partial class AuthenticationWindow : Window
{
    public AuthenticationWindow()
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
    
    private void OnAuthenticationButton(object? sender, RoutedEventArgs args)
    {
        if (AccountRepository.Get(InputEmail.Value) == null)
        {
            ShowError("Неправильный email или пароль");
            return;
        }
        
        ShowError("Аутентификация успешна");
    }

    private void OnChangeWindowButton(object? sender, RoutedEventArgs args, Window newWindow)
    {
        var window = GetTopLevel(this) as Window;
        
        newWindow.Show();
        
        window!.Close();
    }
    private void OnRecoveryButton(object? sender, RoutedEventArgs args)
    {
        OnChangeWindowButton(sender, args, new RecoveryWindow());
    }

    private void OnRegistrationButton(object? sender, RoutedEventArgs args)
    {
        OnChangeWindowButton(sender, args, new RegistrationWindow());
    }
}