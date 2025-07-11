using Microsoft.Identity.Client;

namespace IT_AMS;

public class AssetDataModel
{
    public string Computertype {get; set;}
    public string ComputerModel {get; set;}
    public string ComputerName {get; set;}
    public string CPU {get; set;}
    public string RAM {get; set;}
    public string Serial  {get; set;}
    public string Comments {get; set;}
    public string SentinelOne {get; set;}
    public string DNSFilter {get; set;}
    public string Mimecast {get; set;}
    public string M365License {get; set;}
    public string WinKey {get; set;}
}