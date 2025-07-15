using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.Data.SqlClient;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace IT_AMS;

public partial class QuickEntryWindow : Window
{
    public QuickEntryWindow()
    {
        InitializeComponent();
    }

    private void BtnCreateUserAndAsset_OnClick(object? sender, RoutedEventArgs e)
    {
        // Insert Fist the Asset into the Asset Table and get the Inserted Asset ID
        //
        int LastId = 0; // AssetID
        
        //string connectionString = "Server=FANIE-DELLXPS13\\ABMS_SQL_SVR;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
        string connectionString = "Server=FANIE-F15\\ABMS_SQL;Database=TestDB;User Id=sa;Password=Tester@123;TrustServerCertificate=true;";
        
        var selectedItem = ComboComputerType.SelectedItem as ComboBoxItem;
        string selectedText = selectedItem.Content.ToString();

        try
        {
            string sql = @"INSERT INTO Asset (ComputerType, ComputerModel, ComputerName, CPU, RAM, Serial, Comments) 
                        VALUES (@Value1, @Value2,  @Value3, @Value4, @Value5, @Value6, @Value7); 
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
        
            using SqlConnection con = new  SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("@Value1", selectedText);
                cmd.Parameters.AddWithValue("@Value2", TxtComputerModel.Text);
                cmd.Parameters.AddWithValue("@Value3", TxtComputerName.Text);
                cmd.Parameters.AddWithValue("@Value4", TxtCpu.Text);
                cmd.Parameters.AddWithValue("@Value5", TxtRam.Text);
                cmd.Parameters.AddWithValue("@Value6", TxtSerial.Text);
                cmd.Parameters.AddWithValue("@Value7", TxtComments.Text);
            
                con.Open();
                LastId = (int)cmd.ExecuteScalar(); // Get Last Asset ID Inserted into the Asset Table
                con.Close();
            }
        }
        catch (Exception ex)
        {
            MessageBoxManager.GetMessageBoxStandard("Error !", ex.Message, ButtonEnum.Ok,
                MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
        }
        
        
        // Second Command Inserts the User Details (Employee) to the Employee Table and assigns the AssetID.

        try
        {
            string sql = @"INSERT INTO Employee (FullName, Department, Email, AssetID) 
                            VALUES (@Valuee1, @Valuee2, @Valuee3, @Valuee4);";
            using SqlConnection con = new  SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Valuee1", TxtFullName.Text);
                cmd.Parameters.AddWithValue("@Valuee2", TxtDepartment.Text);
                cmd.Parameters.AddWithValue("@Valuee3", TxtEmail.Text);
                cmd.Parameters.AddWithValue("@Valuee4", LastId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            MessageBoxManager.GetMessageBoxStandard("Error !", ex.Message, ButtonEnum.Ok,
                MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
        }
        
        
        // Done Message !
        MessageBoxManager.GetMessageBoxStandard("Success !", "User and Asset Created Successfully. !", ButtonEnum.Ok,
            MsBox.Avalonia.Enums.Icon.Success).ShowAsync();
        
        // Reset all txt boxes.
        TxtFullName.Text = string.Empty;
        TxtDepartment.Text = string.Empty;
        TxtEmail.Text = string.Empty;
        ComboComputerType.SelectedIndex = -1;
        TxtComputerModel.Text = string.Empty;
        TxtComputerName.Text = string.Empty;
        TxtCpu.Text = string.Empty;
        TxtRam.Text = string.Empty;
        TxtSerial.Text = string.Empty;
        TxtComments.Text = string.Empty;
    }

    private void BtnCancel_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}