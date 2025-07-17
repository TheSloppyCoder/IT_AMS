using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.Data.SqlClient;

namespace IT_AMS;

public partial class MainMenuAssetDetailsWindow : Window
{
    public MainMenuAssetDetailsWindow()
    {
        InitializeComponent();
    }
    
    private void Window_Loaded(object? sender, RoutedEventArgs e)
    {
        SQLCon con  = new  SQLCon();
        string sql = "SELECT * FROM EMPLOYEE WHERE EmpID = " + LblEmpId.Content;
        using (SqlConnection connection = new SqlConnection(con.connectionString))
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TxtFullName.Text = reader["FullName"].ToString();
                TxtDepartment.Text = reader["Department"].ToString();
                TxtEmail.Text = reader["Email"].ToString();
            }
            connection.Close();
        }
        
        string sql2 = "SELECT * FROM Asset WHERE AssetID = " + LblAssetId.Content;
        using (SqlConnection connection = new SqlConnection(con.connectionString))
        {
            connection.Open();
            SqlCommand cmd2 = new SqlCommand(sql2, connection);
            var reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                TxtComputerType.Text = reader["ComputerType"].ToString();
                TxtComputerModel.Text = reader["ComputerModel"].ToString();
                TxtComputerName.Text = reader["ComputerName"].ToString();
                TxtSerial.Text = reader["Serial"].ToString();
                TxtCpu.Text = reader["Cpu"].ToString();
                TxtRam.Text = reader["Ram"].ToString();
                TxtComments.Text = reader["Comments"].ToString();
                if (reader["SentinelOne"].ToString() == "NO")
                {
                    ComboSentinel.SelectedIndex = 0;
                }
                else if (reader["SentinelOne"].ToString() == "YES")
                {
                    ComboSentinel.SelectedIndex = 1;
                }
                else
                {
                    ComboSentinel.SelectedIndex = -1;
                }

                if (reader["DNSFilter"].ToString() == "NO")
                {
                    ComboDns.SelectedIndex = 0;
                }
                else if (reader["DNSFilter"].ToString() == "YES")
                {
                    ComboDns.SelectedIndex = 1;
                }
                else
                {
                    ComboDns.SelectedIndex = -1;
                }

                if (reader["Mimecast"].ToString() == "NO")
                {
                    ComboMimecast.SelectedIndex = 0;
                }
                else if (reader["Mimecast"].ToString() == "YES")
                {
                    ComboMimecast.SelectedIndex = 1;
                }
                else
                {
                    ComboMimecast.SelectedIndex = -1;
                }
                TxtM365.Text =  reader["M365License"].ToString();
                TxtWinKey.Text = reader["WinKey"].ToString();
            }
            connection.Close();
        }
    }

    private void BtnUpdateDetails_OnClick(object? sender, RoutedEventArgs e)
    {
        //
    }

    private void BtnReturnAsset_OnClick(object? sender, RoutedEventArgs e)
    {
        //
    }

    private void BtnClose_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}