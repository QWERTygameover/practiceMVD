using System.Net.Http.Json;
using System.Text.Json;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;
using ConsoleApp1;

StreamReader configReader = null;
string configURL;

bool isCorrectURL;

do
{
    try
    {
        Console.WriteLine("Введите путь до конфиг-файла");
        configURL = Console.ReadLine().Trim();
        configReader = new StreamReader(configURL);
        isCorrectURL = true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        isCorrectURL = false;
    }
} while (!isCorrectURL);

string[] allConfig = configReader.ReadToEnd().Split('\n');

string readPath = allConfig[1].Trim();

string savePath = allConfig[3].Trim();

string connectionString = allConfig[5].Trim();

DateTime dateTime;

try
{
    do
    {
        dateTime = DateTime.Today;
        
        StreamReader reader = new StreamReader(readPath);

        string text = reader.ReadToEnd();

        reader.Close();

        string[] allData = Regex.Split(text, @"^\n", RegexOptions.Multiline).Where(_=>_ != string.Empty).ToArray();

        List<Data> dates = Methods.FillDataClasses(allData);

        PortData finalData = new PortData();
        
        finalData.ffMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ff).ff;
        finalData.flMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.fl).fl;
        finalData.ptMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.pt).pt;
        finalData.lfMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.lf).lf;
        finalData.llMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ll).ll;
        finalData.tpMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tp).tp;
        finalData.ttMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tt).tt;
        finalData.fflitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ffLit).ffLit;
        finalData.fllitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.flLit).flLit;
        finalData.ptlitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ptLit).ptLit;
        finalData.lflitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.lfLit).lfLit;
        finalData.lllitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.llLit).llLit;
        finalData.tplitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tpLit).tpLit;
        finalData.ttlitMin = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ttLit).ttLit;

        finalData.ffMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ff).ff;
        finalData.flMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.fl).fl;
        finalData.ptMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.pt).pt;
        finalData.lfMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.lf).lf;
        finalData.llMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ll).ll;
        finalData.tpMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tp).tp;
        finalData.ttMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tt).tt;
        finalData.fflitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ffLit).ffLit;
        finalData.fllitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.flLit).flLit;
        finalData.ptlitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ptLit).ptLit;
        finalData.lflitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.lfLit).lfLit;
        finalData.lllitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.llLit).llLit;
        finalData.tplitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tpLit).tpLit;
        finalData.ttlitMax = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ttLit).ttLit;

        finalData.DateOfReport = dateTime.Date;
        
        string result = $"\n{dateTime.Date} \n" +
                        $"{"Cond", 5} {"Min", 5} {"Max", 5} \n" +
                        $"{"ff", 5} {finalData.ffMin, 5} {finalData.ffMax, 5} \n" +
                        $"{"fl", 5} {finalData.flMin, 5} {finalData.flMax, 5} \n" +
                        $"{"pt", 5} {finalData.ptMin, 5} {finalData.ptMax, 5} \n" +
                        $"{"lf", 5} {finalData.lfMin, 5} {finalData.lfMax, 5} \n" +
                        $"{"ll", 5} {finalData.llMin, 5} {finalData.llMax, 5} \n" +
                        $"{"tp", 5} {finalData.tpMin, 5} {finalData.tpMax, 5} \n" +
                        $"{"tt", 5} {finalData.ttMin, 5} {finalData.ttMax, 5} \n" +
                        $"{"ffLit", 5} {finalData.fflitMin, 5} {finalData.fflitMax, 5} \n" +
                        $"{"flLit", 5} {finalData.fllitMin, 5} {finalData.fllitMax, 5} \n" +
                        $"{"ptLit", 5} {finalData.ptlitMin, 5} {finalData.ptlitMax, 5} \n" +
                        $"{"lfLit", 5} {finalData.lflitMin, 5} {finalData.lflitMax, 5} \n" +
                        $"{"llLit", 5} {finalData.lllitMin, 5} {finalData.lllitMax, 5} \n" +
                        $"{"tpLit", 5} {finalData.tplitMin, 5} {finalData.tplitMax, 5} \n" +
                        $"{"ttLit", 5} {finalData.ttlitMin, 5} {finalData.ttlitMax, 5} \n";
                        
        StreamWriter writer = new StreamWriter(savePath, true);

        writer.Write(result);

        writer.Close();

        PostDataToDB(finalData);
        
        Console.WriteLine("Успешно!");
        
        Thread.Sleep(TimeSpan.FromDays(1));
        
    } while (true);
    
}
catch (Exception e)
{
    Console.WriteLine("Ошибка! Работа прекращена");
    Console.WriteLine(e);
    
    StreamWriter writer = new StreamWriter(savePath, true);

    dateTime = DateTime.Today;
    
    string message = $"\n{dateTime.Date.ToString()}\n" +
                     $"{e.Message}\n";
    
    writer.Write(message);

    writer.Close();
}

void PostDataToDB(PortData finalData)
{
    HttpClient client = new HttpClient();

    JsonContent jsonContent = JsonContent.Create(finalData);
    client.PostAsync("http://localhost:5122/AddData", jsonContent);
}

public class PortData
{
    public int ffMin { get; set; }
    public int ffMax { get; set; }
    public int flMin { get; set; }
    public int flMax { get; set; }
    public int ptMin { get; set; }
    public int ptMax { get; set; }
    public int lfMin { get; set; }
    public int lfMax { get; set; }
    public int llMin { get; set; }
    public int llMax { get; set; }
    public int tpMin { get; set; }
    public int tpMax { get; set; }
    public int ttMin { get; set; }
    public int ttMax { get; set; }
    public int fflitMin { get; set; }
    public int fflitMax { get; set; }
    public int fllitMin { get; set; }
    public int fllitMax { get; set; }
    public int ptlitMin { get; set; }
    public int ptlitMax { get; set; }
    public int lflitMin { get; set; }
    public int lflitMax { get; set; }
    public int lllitMin { get; set; }
    public int lllitMax { get; set; }
    public int tplitMin { get; set; }
    public int tplitMax { get; set; }
    public int ttlitMin { get; set; }
    public int ttlitMax { get; set; }
    public DateTime DateOfReport { get; set; }
}
