using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Custom Game Event created for every type of custom event such as when the Player is hit, Enemy dies or Trinket is taken
/// </summary>
[CreateAssetMenu(menuName = "Event/GameEvent")]
public class GameEvent : ScriptableObject
{
    /// <summary>
    /// Stores every listener that is registered for this event
    /// </summary>
    public List<GameEventListener> listeners = new List<GameEventListener>();

    /// <summary>
    /// Raise this event calls every listener on the list
    /// </summary>
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaiser();
        }
    }

    /// <summary>
    /// Registers given listener for this event adding it to the list
    /// </summary>
    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    /// <summary>
    /// Unregisters given listener for this event removing it from the list
    /// </summary>
    public void UnregisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}

// Only on editor
#if UNITY_EDITOR

/// <summary>
/// Custom editor for debugging purposes
/// </summary>
[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // Get current event
        GameEvent gameEvent = (GameEvent)target;
        // Button used to raise the current event through the editor without having to trigger it playing
        if (GUILayout.Button("Raise Event"))
            gameEvent.Raise();
    }
}

#endif
