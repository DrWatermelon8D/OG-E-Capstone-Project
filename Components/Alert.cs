using Microsoft.AspNetCore.SignalR;

public class Alert{

    public string alertType {get; set;}
    public string alertDescription {get; set;}

    public Alert(string t, string a){
        alertType = t; 
        alertDescription = a;
    }
}