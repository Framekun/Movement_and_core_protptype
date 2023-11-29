using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] int _priority;
    public int Priority => _priority;
    [SerializeField] CinemachineVirtualCamera _zoneCam;
    public CinemachineVirtualCamera ZoneCam => _zoneCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerCameraManager camManager))
        {
            camManager.EnterZone(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerCameraManager camManager))
        {
            camManager.ExitZone(this);
        }
    }
}
