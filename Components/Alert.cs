using Microsoft.AspNetCore.SignalR;

public class Alert{

    public string alertType {get; set;}
    public string alertDescription {get; set;}
    public int Severity {get; set;}
    public Alert(string t, string a, int i){
        alertType = t; 
        alertDescription = a;
        Severity = i; 
    }
}