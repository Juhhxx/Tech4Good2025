using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameraList;
    private static GameObject[] _cameraListSttc;
    private static CameraModes _currentCamera = CameraModes.Default;
    private void Start()
    {
        _cameraListSttc = _cameraList;
    }
    public static void SwitchToCamera(CameraModes mode)
    {
        _cameraListSttc[(int)_currentCamera].SetActive(false);
        _cameraListSttc[(int)mode].SetActive(true);
        _currentCamera = mode;
    }

}

public enum CameraModes
{
    Default,
    Missions,
    Minigames
}
