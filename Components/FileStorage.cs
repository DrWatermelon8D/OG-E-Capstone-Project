using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using MyApplication.Components;
using MyApplication.Components.Pages;
using MudBlazor;
public class FileStorage{
    public static bool isFileUploaded = false;
    public static string FileName = "";
    public static List<ReaderEvent> masterList = new List<ReaderEvent>();
    public static Dictionary<int, List<ReaderEvent>> ReaderDictionary = new Dictionary<int, List<ReaderEvent>>();
    public static Dictionary<string, List<ReaderEvent>> HashDictionary = new Dictionary<string, List<ReaderEvent>>();
    public static Dictionary<string, List<ReaderEvent>> DateDictionary = new Dictionary<string, List<ReaderEvent>>();
    public static List<ReaderEvent> duplicateEvents = new List<ReaderEvent>();


    public static void ProcessFile()
    {
        string ErrorMessage = "";
        string? line;
        string previousLine = ""; 
        string[] rawLine;
        try{
            StreamReader sr = new StreamReader(FileName);
            line = sr.ReadLine();
            while(line != null)
            {

                line = sr.ReadLine();
                
                if(line != null)
                {
                    rawLine = line.Split(",");  
                    if(line != previousLine){      
                        masterList.Add(new ReaderEvent(DateTime.Parse(rawLine[0]), rawLine[1], rawLine[2], rawLine[3], Int32.Parse(rawLine[4]), Int32.Parse(rawLine[5])));
                    }else{
                        duplicateEvents.Add(new ReaderEvent(DateTime.Parse(rawLine[0]), rawLine[1], rawLine[2], rawLine[3], Int32.Parse(rawLine[4]), Int32.Parse(rawLine[5])));
                    }
                }
                previousLine = line; 

            }

        }
        catch(Exception e)
        {
            ErrorMessage = e.ToString();
        }
        CreateDictionaries();
    }


    public static void CreateDictionaries()
    {
        foreach(ReaderEvent r in masterList)
        {
            int keyNum = r.DevID + r.MachineID;
            if(ReaderDictionary.ContainsKey(keyNum))
            {
                ReaderDictionary[keyNum].Add(r);
            }else{
                ReaderDictionary.Add(keyNum, new List<ReaderEvent>());
                ReaderDictionary[keyNum].Add(r);
            }

            if(HashDictionary.ContainsKey(r.IDHash))
            {
                HashDictionary[r.IDHash].Add(r);
            }else{
                HashDictionary.Add(r.IDHash, new List<ReaderEvent>());
                HashDictionary[r.IDHash].Add(r);
            }
            string date = r.EventTimeStamp.ToString("MMM dd");
            if(DateDictionary.ContainsKey(date))
            {
                DateDictionary[date].Add(r);
            }else{
                DateDictionary.Add(date, new List<ReaderEvent>());
                DateDictionary[date].Add(r);
            }
        }
        Home.DictionariesCreated = true;
    }
}