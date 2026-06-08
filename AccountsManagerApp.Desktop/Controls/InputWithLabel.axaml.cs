using Avalonia;
using Avalonia.Controls;

namespace AccountsManagerApp.Desktop.Controls;

public partial class InputWithLabel : UserControl
{
    public static readonly StyledProperty<double> ControlWidthProperty =
        AvaloniaProperty.Register<InputWithLabel, double>(nameof(ControlWidth), defaultValue: 0.0);
    
    public static readonly StyledProperty<string> LabelProperty =
        AvaloniaProperty.Register<InputWithLabel, string>(nameof(Label), defaultValue: "");
    
    public static readonly StyledProperty<string> UserInputProperty =
        AvaloniaProperty.Register<InputWithLabel, string>(nameof(Value), defaultValue: "");
    
    public static readonly StyledProperty<string?> PasswordCharProperty =
        AvaloniaProperty.Register<InputWithLabel, string?>(nameof(PasswordChar), defaultValue: "");

    public double ControlWidth
    {
        get => GetValue(ControlWidthProperty);
        set => SetValue(ControlWidthProperty, value);
    }
    
    public string Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }
    
    public string Value
    {
        get => GetValue(UserInputProperty);
        set => SetValue(UserInputProperty, value);
    }
    
    public string? PasswordChar
    {
        get => GetValue(PasswordCharProperty);
        set => SetValue(PasswordCharProperty, value);
    }

    public InputWithLabel()
    {
        InitializeComponent();
    }
}