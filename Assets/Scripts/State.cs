using UnityEngine;

public class State : MonoBehaviour
{
    public Movement movement;

    protected Vector3 lastCheckpoint;
    public int playerIndex;

    public virtual void Defeat()
    {
        movement.SetPosition(lastCheckpoint);
    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        lastCheckpoint = checkpoint;
    }
}
