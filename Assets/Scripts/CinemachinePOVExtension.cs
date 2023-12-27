using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{

    [SerializeField]
    private float clampAngleUp = 80f;
    [SerializeField]
    private float clampAngleDown = 60f;
    [SerializeField]
    private float horizantalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;

    private Vector3 startingRotation; 
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {

        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = InputManager.Instance.GetMouseDelta();
                startingRotation.x += deltaInput.x * verticalSpeed * deltaTime;
                startingRotation.y += deltaInput.y * horizantalSpeed * deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngleDown, clampAngleUp);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x,0f);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if (startingRotation == null)
        {
            startingRotation = transform.localRotation.eulerAngles;
        }
    }

}

