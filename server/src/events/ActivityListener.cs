namespace Events
{
    public class ActivityListener : IEventListener
    {
        public void Update(string data)
        {
            logList.Add(data);
        }

        private List<string> logList = new();
    }
}