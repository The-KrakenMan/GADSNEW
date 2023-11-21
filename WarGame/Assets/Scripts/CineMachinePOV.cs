using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CineMachinePOV : CinemachineExtension
{
    private PlayerController Controller;
    private Vector3 StartingRotation;

    [SerializeField]
    private float clampAngle = 60f;

    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;

    protected override void Awake()
    {
        Controller = PlayerController.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (StartingRotation == null) 
                {
                    StartingRotation = transform.localRotation.eulerAngles;
                }
                Vector2 deltaInput = Controller.getTurn();
                StartingRotation.x += deltaInput.x * verticalSpeed* Time.deltaTime;
                StartingRotation.y += deltaInput.y * horizontalSpeed* Time.deltaTime;
                StartingRotation.y = Mathf.Clamp(StartingRotation.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler( -StartingRotation.y,StartingRotation.x,0f);
            }
        }
    }

    // Start is called before the first frame update
  
}
