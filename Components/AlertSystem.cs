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



        return alertList;
    }

}