using AccountsManagerApp.Desktop.Extensions;
using AccountsManagerApp.Logic;

using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AccountsManagerApp.Desktop.Windows;

public partial class AuthenticationWindow : Window
{
    public AuthenticationWindow()
    {
        InitializeComponent();
    }

    private async void OnAuthenticationButton(object? sender, RoutedEventArgs args)
    {
        if (AccountRepository.Get(InputEmail.Value) == null)
        {
            await this.ShowErrorBoxAsync("Неправильный email или пароль");
            return;
        }

        await this.ShowInformationBoxAsync("Аутентификация успешна");
    }

    private void OnRecoveryButton(object? sender, RoutedEventArgs args)
    {
        this.JumpTo(new RecoveryWindow());
    }

    private void OnRegistrationButton(object? sender, RoutedEventArgs args)
    {
        this.JumpTo(new RegistrationWindow());
    }
}