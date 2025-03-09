using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCameraBase CinemachineVirtualCamera;
    public float ShakeAccelerationMultiplier = .2f;
    public float maxShake = 4f;

    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineVirtualCameraBase>();
        _cbmcp = CinemachineVirtualCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        ResetIntensity();
    }

    public void ShakeCamera(float shakeIntensity, float shakeTime)
    {
        _cbmcp.AmplitudeGain = shakeIntensity;
        StartCoroutine(WaitTime(shakeTime));
    }

    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();
    }

    void ResetIntensity()
    {
        _cbmcp.AmplitudeGain = 0.1f;
    }
}
