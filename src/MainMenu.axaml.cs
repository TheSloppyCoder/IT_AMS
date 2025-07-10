using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.Data.SqlClient;


namespace IT_AMS;

public partial class MainMenu : Window
{
    public MainMenu()
    {
        InitializeComponent();
    }
    
    private void Window_OnLoaded(object? sender, RoutedEventArgs e)
    {
        // string connectionString = "Server=FANIE-F15\\ABMS_SQL;Database=TestDB;User Id=sa;Password=Tester123;TrustServerCertificate=true;";
        // using (SqlConnection connection = new SqlConnection(connectionString))
        // {
        //     try
        //     {
        //         connection.Open();
        //         Console.WriteLine("Connection successful!");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("Error: " + ex.Message);
        //     }
        // }

    }

    private void BtnQuickEntry_OnClick(object? sender, RoutedEventArgs e)
    {
        QuickEntryWindow quickEntryWindow = new QuickEntryWindow();
        quickEntryWindow.Show();
    }

    private void ComboHistory_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        switch (ComboHistory.SelectedIndex)
        {
            case 0:
                LblTitle.Content = "Assigned Assets";
                break;
            case 1:
                LblTitle.Content = "Asset History";
                break;
            case 2:
                LblTitle.Content = "Deleted Assets";
                break;
            case 3:
                LblTitle.Content = "Recycled Assets";
                break;
        }
    }

    private void ComboOptions_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        switch (ComboOptions.SelectedIndex)
        {
            case 0:
                ComboOptions.SelectedIndex = -1;
                break;
            case 1:
                break;
        }
    }


}