using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class PlayerCameraManager : MonoBehaviour
{
    private List<CinemachineVirtualCamera> _allVirtualCams = new List<CinemachineVirtualCamera>();

    private List<CameraChange> _overlappingChangeZones = new List<CameraChange>();

    // Start is called before the first frame update
    void Start()
    {
        _allVirtualCams = FindObjectsOfType<CinemachineVirtualCamera>(true).ToList();
    }

    void UpdateCurrentZone()
    {
        if (_overlappingChangeZones.Count == 0) return;

        _overlappingChangeZones = _overlappingChangeZones.OrderByDescending(x => x.Priority).ToList();

        CinemachineVirtualCamera bestCam = _overlappingChangeZones[0].ZoneCam;

        foreach (CinemachineVirtualCamera aCam in _allVirtualCams)
        {
            if (aCam == bestCam)
            {
                aCam.gameObject.SetActive(true);
            }
            else
            {
                aCam.gameObject.SetActive(false);
            }
        }
    }

    public void EnterZone(CameraChange zone)
    {
        if (_overlappingChangeZones.Contains(zone)) return;

        _overlappingChangeZones.Add(zone);

        UpdateCurrentZone();
    }

    public void ExitZone(CameraChange zone) 
    {
        _overlappingChangeZones.Remove(zone);

        UpdateCurrentZone();
    }
}
