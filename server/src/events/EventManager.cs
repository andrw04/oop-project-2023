namespace Events
{
    public class EventManager
    {
        public void Subscribe(IEventListener listener)
        {
            listeners.Add(listener);
        }

        public void Unsubscribe(IEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Notify(string data)
        {
            foreach (var listener in listeners)
            {
                listener.Update(data);
            }
        }

        private List<IEventListener> listeners = new();
    }
}