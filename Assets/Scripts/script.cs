using Unity.Cinemachine;
using UnityEngine;

public class script : MonoBehaviour
{

}
public class LockCameraZ : CinemachineExtension
{
    
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_yPosition = -1.842f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.z = m_yPosition;
            state.RawPosition = pos;
        }
    }

}