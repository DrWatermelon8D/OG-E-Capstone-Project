using Microsoft.AspNetCore.SignalR;

public class Alert{

    public string alertType {get; set;}
    public ReaderEvent alertEvent {get; set;}
    public string alertDescription {get; set;}

    public Alert(ReaderEvent e, string t, string a){
        alertEvent = e; 
        alertType = t; 
        alertDescription = a;
    }
}