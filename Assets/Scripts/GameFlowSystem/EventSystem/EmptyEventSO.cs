using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="New empty event", menuName =MENU_PLACE + "New empty event")]
public class EmptyEventSO : GameEventSO
{
    public UnityEvent emptyEvent;

    public void AddEmptyListener (UnityAction listner)
    {
        emptyEvent.AddListener(listner);
    }
    public void RemoveEmptyListener(UnityAction listener)
    {
        emptyEvent.RemoveListener(listener);
    }

    public void RaiseEmptyEvent()
    {
        emptyEvent.Invoke();
    }
}
