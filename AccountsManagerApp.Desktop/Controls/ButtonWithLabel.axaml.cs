using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AccountsManagerApp.Desktop.Controls;

public partial class ButtonWithLabel : UserControl
{
    public static readonly StyledProperty<string?> LabelProperty =
        AvaloniaProperty.Register<ButtonWithLabel, string?>(nameof(Label), defaultValue: "");

    public static readonly StyledProperty<object> ButtonContentProperty =
        AvaloniaProperty.Register<ButtonWithLabel, object>(nameof(ButtonContent));

    public static readonly StyledProperty<double> ButtonWidthProperty =
        AvaloniaProperty.Register<ButtonWithLabel, double>(nameof(ButtonWidth));

    public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
        RoutedEvent.Register<ButtonWithLabel, RoutedEventArgs>(nameof(OnButtonClick), RoutingStrategies.Bubble);

    public string? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);

    }

    public object ButtonContent
    {
        get => GetValue(ButtonContentProperty);
        set => SetValue(ButtonContentProperty, value);
    }
    
    public double ButtonWidth
    {
        get => GetValue(ButtonWidthProperty);
        set => SetValue(ButtonWidthProperty, value);
    }

    private void OnButtonClick(object? sender, RoutedEventArgs args)
    {
        var newArgs = new RoutedEventArgs(ClickEvent);
        
        RaiseEvent(newArgs);

        args.Handled = true;
    }

    public ButtonWithLabel()
    {
        InitializeComponent();
    }
}