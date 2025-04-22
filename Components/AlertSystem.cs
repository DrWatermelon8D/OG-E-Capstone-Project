using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using MyApplication.Components;
using MyApplication.Components.Pages;
using MudBlazor;

public class AlertSystem{

    public static List<Alert> findAlerts(){
        List<Alert> alertList = new List<Alert>();

        foreach(ReaderEvent r in FileStorage.masterList)
        {

        }


        return alertList;
    }

}