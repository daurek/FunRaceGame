using UnityEngine;

public class PlayerState : State
{
    private CameraController cameraController;

    public void SetCameraControllerRef(CameraController _cameraController)
    {
        cameraController = _cameraController;
    }

    public override void Defeat()
    {
        cameraController.ResetToNearestPathPoint(lastCheckpoint);
        base.Defeat();
    }
}
