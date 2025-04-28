using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using MyApplication.Components;
using MyApplication.Components.Pages;
using MudBlazor;
using System.Numerics;

public class AlertSystem{

    public static List<Alert> findAlerts(){
        List<Alert> alertList = new List<Alert>();
        
        int total = 0; 
        foreach(List<ReaderEvent> r in FileStorage.ReaderDictionary.Values.ToArray())
        {
            total += r.Count();
        }

        int AverageScans = total/FileStorage.ReaderDictionary.Count();

        foreach(KeyValuePair<int, List<ReaderEvent>> r in FileStorage.ReaderDictionary){
            if(r.Value.Count() - AverageScans >= 1000)
            {
                alertList.Add(new Alert("High Usage", "The Reader " + r.Value[0].ReaderDescription + " is recieving higher amounts of scans and may require mantenence sooner."));
            }
        }

        foreach(KeyValuePair<string, List<ReaderEvent>> r in FileStorage.HashDictionary)
        {
            if(r.Value.Count() < 10)
            {
                alertList.Add(new Alert("Low Scans", "User " + r.Key + " has only " + r.Value.Count() + " scans."));
            }
        }

        Dictionary<int, List<ReaderEvent>> duplicateCounts = new Dictionary<int, List<ReaderEvent>>();
        foreach(ReaderEvent r in FileStorage.duplicateEvents)
        {
            int keyNum = r.DevID + r.MachineID;
            if(duplicateCounts.ContainsKey(keyNum))
            {
                duplicateCounts[keyNum].Add(r);
            }else{
                duplicateCounts.Add(keyNum, new List<ReaderEvent>());
                duplicateCounts[keyNum].Add(r);
            }
        }

        foreach(KeyValuePair<int, List<ReaderEvent>> k in duplicateCounts)
        {
            if(k.Value.Count() > 25)
            {
                alertList.Add(new Alert("High Duplicates", "Reader " + k.Value[0].ReaderDescription + " has a high number of duplicate scans."));
            }
        }

        return alertList;
    }

}