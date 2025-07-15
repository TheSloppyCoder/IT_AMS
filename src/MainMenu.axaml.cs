using System;
using System.Collections.ObjectModel;
using System.Data;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Microsoft.Data.SqlClient;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;


namespace IT_AMS;

public partial class MainMenu : Window
{
    public MainMenu()
    {
        InitializeComponent();
    }
    
    private void Window_OnLoaded(object? sender, RoutedEventArgs e)
    {
        ComboHistory.SelectedIndex = 0; // Select and load Assigned Assets on the Data Table
    }
    
    private void TxtSearch_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        try
        {
            //string connectionString = "Server=FANIE-DELLXPS13\\ABMS_SQL_SVR;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
            string connectionString = "Server=FANIE-F15\\ABMS_SQL;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
            string sql = "";
            switch (ComboHistory.SelectedIndex)
            {
                case 0: // Assigned Assets
                    sql = "SELECT * FROM Employee INNER JOIN Asset ON Employee.AssetID = Asset.AssetID " +
                          "WHERE FullName LIKE " + "'%" + TxtSearch.Text + "%'" +
                          "OR Serial LIKE " + "'%" + TxtSearch.Text + "%'";
                    break;
            }
                           
            
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
            }

            ObservableCollection<CombinedDataModel> assets = new ObservableCollection<CombinedDataModel>();

            foreach (DataRow row in dt.Rows)
            {
                assets.Add(new  CombinedDataModel
                {
                    EmpId = Convert.ToInt32(row["EmpID"].ToString()),
                    FullName = row["FullName"].ToString(),
                    Department = row["Department"].ToString(),
                    Email = row["Email"].ToString(),
                    ComputerType = row["Computertype"].ToString(),
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
            DataGrid.ItemsSource = assets;
        }
        catch (Exception ex)
        {
            MessageBoxManager.GetMessageBoxStandard("Error !", ex.Message, ButtonEnum.Ok,
                MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
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
                try
                {
                    //string connectionString = "Server=FANIE-DELLXPS13\\ABMS_SQL_SVR;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
                    string connectionString = "Server=FANIE-F15\\ABMS_SQL;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
                    string sql = "SELECT * FROM Employee INNER JOIN Asset ON Employee.AssetID = Asset.AssetID";
            
                    DataTable dt = new DataTable();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        adapter.Fill(dt);
                    }

                    ObservableCollection<CombinedDataModel> assets = new ObservableCollection<CombinedDataModel>();

                    foreach (DataRow row in dt.Rows)
                    {
                        assets.Add(new  CombinedDataModel
                        {
                            EmpId = Convert.ToInt32(row["EmpID"].ToString()),
                            FullName = row["FullName"].ToString(),
                            Department = row["Department"].ToString(),
                            Email = row["Email"].ToString(),
                            ComputerType = row["Computertype"].ToString(),
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
                    DataGrid.ItemsSource = assets;
                }
                catch (Exception ex)
                {
                    MessageBoxManager.GetMessageBoxStandard("Error !", ex.Message, ButtonEnum.Ok,
                        MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
                }
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
            case 0: // Export to Excel
                ComboOptions.SelectedIndex = -1;
                break;
            case 1: // Settings Window
                break;
        }
    }
    
    private void DataGrid_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (DataGrid.SelectedItem is CombinedDataModel item)
        {
            FullAssetWindow fullAssetWindow = new FullAssetWindow();
            fullAssetWindow.Show();
            // quickEntryWindow.TxtFullName.Text = item.EmpId.ToString();
        }
    }
}