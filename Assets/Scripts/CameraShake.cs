using UnityEngine;

using Unity.Cinemachine;
using System.Collections;
using TreeEditor;
public class CameraShake : MonoBehaviour
{
    private CinemachineCamera CinemachineVirtualCamera;
    public float ShakeAccelerationMultiplier = .2f;
    public float maxShake = 4f;


    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        CinemachineVirtualCamera = GetComponent<CinemachineCamera>();
        _cbmcp = GetComponent<CinemachineBasicMultiChannelPerlin>();
        ResetIntensity();

    }
    public void ShakeCamera(float shakeIntensity, float shakeTime)
    {
       _cbmcp.AmplitudeGain = shakeIntensity;
        StartCoroutine (WaitTime(shakeTime));
    }
    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        
    }
    

    void ResetIntensity()
    {
        _cbmcp.AmplitudeGain = 0.1f;
    }
   
}
