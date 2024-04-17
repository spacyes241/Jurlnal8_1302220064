// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public class program
{
    public static void main(String[] args)
    {
        BankTransferConfig konfig = new BankTransferConfig();
        Console.WriteLine("Please insert the amount of money to transfer : ");
        Console.WriteLine("Masukkan jumlah uang yang akan di-transfer :  ");
        int inputMoney = Convert.ToInt32(Console.ReadLine());

        if (inputMoney == konfig.configuration.transfer.threshold || inputMoney <= konfig.configuration.transfer.threshold)
        {
            Console.WriteLine(konfig.configuration.transfer.low_fee);

        }
        else if (inputMoney >= konfig.configuration.transfer.threshold)
        {
            Console.WriteLine(konfig.configuration.transfer.low_fee);
        }



    }
    

class transfer
{
    public int threshold {  get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }

    public transfer() { }

    public transfer(int threshold, int low_fee, int high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }
}

class confirmation
{
    public String en {  get; set; }
    public String id { get; set; }
    public confirmation() { }
    public confirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
}

class Config
{
    public string lang { get; set; }
    
    public List<string> method { get; set; }

    public confirmation confirmation { get; set; }

    public transfer transfer { get; set; }

    public Config() { }

    public Config(string lang, transfer transfer, List<string> method, confirmation confirmation)
    {
        this.lang = lang;
        this.method = method;
        this.confirmation = confirmation;
        this.transfer = transfer;
    }
 }

public class BankTransferConfig
{
    public Config configuration;

    public const String filepath = "E:\\Materi\\SEMESTER 4\\Praktikum KPL\\Module8_1302220064\\bin\\Debug\\net8.0\\bank_transfer_config.json";

    public BankTransferConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            Setdefault();
            Writenewconfigfile();
        }

    }
    public void Setdefault()
    {
        configuration = new Config("en",25000000,6500,15000, "[ “RTO(real - time)”, “SKN”, “RTGS”, “BI FAST”]","yes","ya");
    }

    private Config ReadConfigFile()
    {
        string configJsonData = File.ReadAllText(filepath);
        configuration = JsonSeriallizer.Deserialize<Config>(configJsonData);
        return configuration;
    }

    public void Writenewconfigfile()
    {
        JsonSeriallizerOptions options = new JsonSeriallizerOptions()
        {
            WriteIndented = true
        };

        String jsonstring =JsonSerializer.Serialize(configuration,options);
        File.WriteAllText(filepath,jsonstring);

    }

}




