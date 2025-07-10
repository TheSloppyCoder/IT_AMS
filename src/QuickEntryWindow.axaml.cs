using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace IT_AMS;

public partial class QuickEntryWindow : Window
{
    public QuickEntryWindow()
    {
        InitializeComponent();
    }

    private void BtnCreateUserAndAsset_OnClick(object? sender, RoutedEventArgs e)
    {
        //
    }

    private void BtnCancel_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}