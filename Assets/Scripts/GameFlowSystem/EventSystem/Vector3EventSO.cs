using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Vector3 event", menuName = MENU_PLACE + "New Vector3 event")]
public class Vector3EventSO : GameEventSO
{
    [Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }

    public Vector3Event vector3Event;

    public void AddListener(UnityAction<Vector3> listener)
    {
        vector3Event.AddListener(listener);
    }
    public void RemoveListener(UnityAction<Vector3> listener)
    {
        vector3Event.RemoveListener(listener);

    }

    public void RaiseEvent(Vector3 input)
    {
        vector3Event.Invoke(input);
    }
}
