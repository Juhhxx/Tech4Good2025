using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private int _points;
    private GameObject _minigame;
    private Missions _mission;
    private bool _isPLaying;
    public bool IsPLaying => _isPLaying;
    private float _timeElapsed;
    private float _timeLeft;
    [SerializeField] private float _timeLimit = 15;

    private void Update()
    {
        if (_isPLaying)
        {
            Timer();

            Debug.Log($"{_timeElapsed} >= {_timeLimit} ? {_timeElapsed >= _timeLimit}");

            if (_timeElapsed >= _timeLimit)
            {
                _isPLaying = false;
                FinishMinigame();
                _minigame.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void StartMinigame(Missions m)
    {
        CameraSwitch.SwitchToCamera(CameraModes.Minigames);
        _mission = m;
        _minigame = m.Minigame;
        _minigame.transform.GetChild(0).gameObject.SetActive(true);
        _isPLaying = true;
    }
    private void Timer()
    {
        _timeElapsed += Time.deltaTime;
        _timeLeft = _timeLimit - _timeElapsed;
        Debug.Log($"Time Left: {(int)_timeLeft}");
    }
    private void FinishMinigame()
    {
        _mission.MissionSuccess = _points > 5 ? 1 : 0;
        CameraSwitch.SwitchToCamera(CameraModes.Default);
    }
}
