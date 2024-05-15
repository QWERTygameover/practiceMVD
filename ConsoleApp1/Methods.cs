namespace ConsoleApp1;

public static class Methods
{
    public static List<Data> FillDataClasses(string[] datas)
    {
        List<Data> dates = new List<Data>();
        
        foreach (string data in datas)
        {
            dates.Add(StringConvertToData(data));
        }

        return dates;
    }

    private static Data StringConvertToData(string data)
    {
        Dictionary<string, int> dates = new Dictionary<string, int>()
        {
            {"Jan",1},
            {"Feb",2},
            {"Mar",3},
            {"Apr",4},
            {"May",5},
            {"Jun",6},
            {"Jul",7},
            {"Aug",8},
            {"Sep",9},
            {"Oct",10},
            {"Nov",11},
            {"Dec",12}
        };
        
        string[] strings = data.Split("\n");
    
         int ff;
         int fl;
         int pt;
    
         int lf;
         int ll;
         int tp;
         int tt;
    
         int ffLit;
         int flLit;
         int ptLit;
    
         int lfLit;
         int llLit;
         int tpLit;
         int ttLit;
         
         int day;
         string month;
         int year;
        
        try
        {
            ff = Convert.ToInt32(strings[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            ff = Convert.ToInt32(strings[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }
        
        try
        {
            fl = Convert.ToInt32(strings[3].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            fl = Convert.ToInt32(strings[3].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            pt = Convert.ToInt32(strings[4].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            pt = Convert.ToInt32(strings[4].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            lf = Convert.ToInt32(strings[6].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            lf = Convert.ToInt32(strings[6].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            ll = Convert.ToInt32(strings[7].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            ll = Convert.ToInt32(strings[7].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            tp = Convert.ToInt32(strings[8].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            tp = Convert.ToInt32(strings[8].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            tt = Convert.ToInt32(strings[9].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            tt = Convert.ToInt32(strings[9].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            ffLit = Convert.ToInt32(strings[11].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            ffLit = Convert.ToInt32(strings[11].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            flLit = Convert.ToInt32(strings[12].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            flLit = Convert.ToInt32(strings[12].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            ptLit = Convert.ToInt32(strings[13].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            ptLit = Convert.ToInt32(strings[13].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            lfLit = Convert.ToInt32(strings[15].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            lfLit = Convert.ToInt32(strings[15].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            llLit = Convert.ToInt32(strings[16].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        { 
            llLit = Convert.ToInt32(strings[16].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            tpLit = Convert.ToInt32(strings[17].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            tpLit = Convert.ToInt32(strings[17].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        try
        {
            ttLit = Convert.ToInt32(strings[18].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1]);
        }
        catch
        {
            ttLit = Convert.ToInt32(strings[18].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        }

        day = Convert.ToInt32(strings[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[2]);
        month = strings[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[1];
        year = Convert.ToInt32(strings[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(_=>!string.IsNullOrWhiteSpace(_)).ToArray()[5]);

        DateTime date = DateTime.Parse($"{day}/{dates[month]}/{year}");

        return new Data(ff,fl,pt,lf,ll,tp,tt,ffLit,flLit,ptLit,lfLit,llLit,tpLit,ttLit, date);
    }
}