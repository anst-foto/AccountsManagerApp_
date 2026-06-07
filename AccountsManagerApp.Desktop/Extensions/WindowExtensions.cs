using System.Threading.Tasks;

using Avalonia.Controls;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace AccountsManagerApp.Desktop.Extensions;

public static class WindowExtensions
{
    extension(Window parentWindow)
    {
        public async Task ShowErrorBoxAsync(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(
                windowStartupLocation: WindowStartupLocation.CenterScreen,
                title: "Ошибка",
                icon: Icon.Error,
                text: message,
                @enum: ButtonEnum.Ok);

            await box.ShowAsPopupAsync(parentWindow);
        }

        public async Task ShowInformationBoxAsync(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(
                windowStartupLocation: WindowStartupLocation.CenterScreen,
                title: "Успех",
                icon: Icon.Success,
                text: message,
                @enum: ButtonEnum.Ok);

            await box.ShowAsPopupAsync(parentWindow);
        }

        public void JumpTo(Window nextWindow)
        {
            nextWindow.Show();
            parentWindow.Close();
        }
    }
}