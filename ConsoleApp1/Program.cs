using System.Text.RegularExpressions;
using ConsoleApp1;

StreamReader configReader = null;
string configURL;

bool isCorrectURL = true;

do
{
    try
    {
        Console.WriteLine("Введите путь до конфиг-файла");
        configURL = Console.ReadLine().Trim();
        configReader = new StreamReader(configURL);
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

DateTime dateTime;
string dateTimeString;

do
{
    Console.WriteLine("Date in format dd/mm/yyyy");
    dateTimeString = Console.ReadLine();
} while (!DateTime.TryParse(dateTimeString, out dateTime));

try
{

    StreamReader reader = new StreamReader(readPath);

    string text = reader.ReadToEnd();

    reader.Close();

    string[] allData = Regex.Split(text, @"^\n", RegexOptions.Multiline).Where(_=>_ != string.Empty).ToArray();

    List<Data> dates = Methods.FillDataClasses(allData);

    Data minff = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ff);
    Data minfl = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.fl);
    Data minpt = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.pt);
    Data minlf = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.lf);
    Data minll = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ll);
    Data mintp = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tp);
    Data mintt = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tt);
    Data minffLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ffLit);
    Data minflLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.flLit);
    Data minptLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ptLit);
    Data minlfLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.lfLit);
    Data minllLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.llLit);
    Data mintpLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.tpLit);
    Data minttLit = dates.Where(_=>_.date == dateTime).ToArray().MinBy(_=>_.ttLit);

    Data maxff = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ff);
    Data maxfl = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.fl);
    Data maxpt = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.pt);
    Data maxlf = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.lf);
    Data maxll = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ll);
    Data maxtp = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tp);
    Data maxtt = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tt);
    Data maxffLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ffLit);
    Data maxflLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.flLit);
    Data maxptLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ptLit);
    Data maxlfLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.lfLit);
    Data maxllLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.llLit);
    Data maxtpLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.tpLit);
    Data maxttLit = dates.Where(_=>_.date == dateTime).ToArray().MaxBy(_=>_.ttLit);

    string result = $"\n{dateTime.Date} \n" +
                    $"{"Cond", 5} {"Min", 5} {"Max", 5} \n" +
                    $"{"ff", 5} {minff.ff, 5} {maxff.ff, 5} \n" +
                    $"{"fl", 5} {minfl.fl, 5} {maxfl.fl, 5} \n" +
                    $"{"pt", 5} {minpt.pt, 5} {maxpt.pt, 5} \n" +
                    $"{"lf", 5} {minlf.lf, 5} {maxlf.lf, 5} \n" +
                    $"{"ll", 5} {minll.ll, 5} {maxll.ll, 5} \n" +
                    $"{"tp", 5} {mintp.tp, 5} {maxtp.tp, 5} \n" +
                    $"{"tt", 5} {mintt.tt, 5} {maxtt.tt, 5} \n" +
                    $"{"ffLit", 5} {minffLit.ffLit, 5} {maxffLit.ffLit, 5} \n" +
                    $"{"flLit", 5} {minflLit.flLit, 5} {maxflLit.flLit, 5} \n" +
                    $"{"ptLit", 5} {minptLit.ptLit, 5} {maxptLit.ptLit, 5} \n" +
                    $"{"lfLit", 5} {minlfLit.lfLit, 5} {maxlfLit.lfLit, 5} \n" +
                    $"{"llLit", 5} {minllLit.llLit, 5} {maxllLit.llLit, 5} \n" +
                    $"{"tpLit", 5} {mintpLit.tpLit, 5} {maxtpLit.tpLit, 5} \n" +
                    $"{"ttLit", 5} {minttLit.ttLit, 5} {maxttLit.ttLit, 5} \n";
                    
    StreamWriter writer = new StreamWriter(savePath, true);

    writer.Write(result);

    writer.Close();
}
catch (Exception e)
{
    StreamWriter writer = new StreamWriter(savePath, true);

    string message = $"\n{dateTime.Date.ToString()}\n" +
                     $"{e.Message}\n";
    
    writer.Write(message);

    writer.Close();
}
