using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _turn;
    private float _manpower;
    private Dictionary<MissionResources,int> _resources;
    [SerializeField] private List<MissionType> _possibleMissions;
    [SerializeField] private GameObject _missionPrefab;
    [SerializeField] private HorizontalLayoutGroup _MissionLayoutGroup;
    [SerializeField] private int _missionsPerTurn;
    private List<Missions> _currentMissions;
    private List<Missions> _activeMissions;

    private void Start()
    {
        // _possibleMissions   = new List<MissionType>();
        _currentMissions    = new List<Missions>();
        _activeMissions     = new List<Missions>();
        StartTurn();
    }
    private void StartTurn()
    {
        _turn++;

        for (int i = 0; i < _missionsPerTurn; i++)
        {
            GenerateMission();
        }
    }

    [Button(enabledMode: EButtonEnableMode.Editor)]
    private Missions GenerateMission()
    {
        MissionType gn = _possibleMissions.RandomElement();
        Debug.Log(gn.Name);

        Missions mission = gn.InstantiateMissions(_turn);

        _currentMissions.Add(mission);

        InstantiateMissionPrefab(mission);

        Debug.Log(mission.ToString());

        return mission;
    }
    private void InstantiateMissionPrefab(Missions m)
    {
        GameObject newM = Instantiate(_missionPrefab,_MissionLayoutGroup.transform);
        
        Button btt          = newM.GetComponent<Button>();
        Image bttImg        = newM.GetComponent<Image>();
        TextMeshProUGUI tmp = newM.GetComponentInChildren<TextMeshProUGUI>();

        btt.onClick.AddListener(() => AcceptMission(m,bttImg));
        tmp.text = m.ToString();
    }
    public void AcceptMission(Missions mission, Image bttImage)
    {
        _currentMissions.Remove(mission);
        _activeMissions.Add(mission);

        _manpower -= mission.ManpowerReq;
        _resources[(MissionResources)mission.Cost["resource"]] -= (int)mission.Cost["amout"];

        Debug.Log($"{mission.Name} mission accepted");
        bttImage.color = new Color( 1, 1, 1, 0.5f);
    }
}
