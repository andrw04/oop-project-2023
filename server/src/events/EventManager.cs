namespace src.events;

public class EventManager
{
    void Subscribe(IEventListener listener)
    {
        listeners.Add(listener);
    }

    void Unsubscribe(IEventListener listener)
    {
        listeners.Remove(listener);
    }

    void Notify(string data)
    {
        foreach (var listener in listeners)
        {
            listener.Update(data);
        }
    }
    private List<IEventListener> listeners = new();
}