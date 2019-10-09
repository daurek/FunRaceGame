using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Base class that handles listener of given game event and triggers a response when that event is raised
/// </summary>
public class GameEventListener : MonoBehaviour
{
    /// <summary>
    /// Given game event (through editor)
    /// </summary>
    public GameEvent gameEvent;

    /// <summary>
    /// Response to trigger (given through editor)
    /// </summary>
    public UnityEvent response;

    /// <summary>
    /// Registers as a listener of given game event on start
    /// </summary>
    public virtual void OnEnable()
    {
        if (gameEvent)
            gameEvent.RegisterListener(this);
    }

    /// <summary>
    /// Unregisters as a listener of given game event on end
    /// </summary>
    public void OnDisable()
    {
        if (gameEvent)
            gameEvent.UnregisterListener(this);
    }

    /// <summary>
    /// Invoke response when event is raised
    /// </summary>
    public virtual void OnEventRaiser()
    {
        response.Invoke();
    }
}
