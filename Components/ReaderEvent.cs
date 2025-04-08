public class ReaderEvent{
        public DateTime EventTimeStamp {get; set;}
        public string EventLocation {get; set;}
        public string ReaderDescription {get; set;}
        public string IDHash {get; set;}
        public int DevID {get; set;}
        public int MachineID {get; set;}

        public ReaderEvent(DateTime d, string e, string r, string i, int v, int m)
        {
            EventTimeStamp = d; 
            EventLocation = e;
            ReaderDescription = r; 
            IDHash = i;
            DevID = v; 
            MachineID = m;
        }
    }