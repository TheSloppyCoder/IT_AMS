using System;
using System.Collections.ObjectModel;
using System.Data;
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
        try
        {
            string connectionString = "Server=FANIE-F15\\ABMS_SQL;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
            string sql = "SELECT * FROM Employee INNER JOIN Asset ON Employee.AssetID = Asset.AssetID";
            
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
            }

            ObservableCollection<CombinedDataModel> employees = new ObservableCollection<CombinedDataModel>();

            foreach (DataRow row in dt.Rows)
            {
                employees.Add(new  CombinedDataModel()
                {
                    FullName = row["FullName"].ToString(),
                    Department = row["Department"].ToString(),
                    Email = row["Email"].ToString(),
                    Computertype = row["Computertype"].ToString(),
                    ComputerModel = row["ComputerModel"].ToString(),
                    ComputerName = row["ComputerName"].ToString(),
                    CPU = row["CPU"].ToString(),
                    RAM = row["RAM"].ToString(),
                    Serial = row["Serial"].ToString(),
                    Comments = row["Comments"].ToString(),
                    SentinelOne = row["SentinelOne"].ToString(),
                    DNSFilter = row["DNSFilter"].ToString(),
                    Mimecast = row["Mimecast"].ToString(),
                    M365License = row["M365License"].ToString(),
                    WinKey = row["WinKey"].ToString()
                });
            }
            DataGrid.ItemsSource = employees;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

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