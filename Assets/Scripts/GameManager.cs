using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _missionsUI;
    [SerializeField] private int _turn;
    public int Turn => _turn;
    [SerializeField] private List<ResourceAmount> _initialResources;
    [SerializeField] private int _manpower;
    public int Manpower => _manpower;
    private Dictionary<Resources,int> _resources;
    public Dictionary<Resources,int> Resources => _resources;
    [SerializeField] private List<MissionType> _possibleMissions;
    [SerializeField] private GameObject _missionPrefab;
    [SerializeField] private HorizontalLayoutGroup _missionLayoutGroup;
    [SerializeField] private int _missionsPerTurn;
    private List<Missions> _currentMissions;
    private List<Missions> _activeMissions;
    public int ActiveMissions => _activeMissions.Count;
    private List<GameObject> _prefabDeleteList;
    private List<Resources> _allResources = new List<Resources>() {global :: Resources.Building, 
                                                                global :: Resources.Food,
                                                                global :: Resources.Medicine,
                                                                global :: Resources.Water};
    private MinigameManager _minigames;
    private bool _inTurn = false;

    private void Start()
    {
        // _possibleMissions   = new List<MissionType>();
        _currentMissions    = new List<Missions>();
        _activeMissions     = new List<Missions>();
        _prefabDeleteList   = new List<GameObject>();
        _resources          = new Dictionary<Resources, int>();
        _minigames          = GetComponent<MinigameManager>();
        SetInitialResources();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_inTurn && !_minigames.IsPLaying)
        {
            CameraSwitch.SwitchToCamera(CameraModes.Missions);
            _missionsUI.SetActive(true);
            StartTurn();
        }
    }

    // Turn Control
    private void StartTurn()
    {
        _inTurn = true;
        _turn++;
        RepostMissions();
    }
    public void EndTurn()
    {
        CheckMissions();
        GetRandomResource();
        _missionsUI.SetActive(false);
        _inTurn = false;
    }

    // Resources
    private void SetInitialResources()
    {
        Debug.Log("Initializing Resources");
        foreach (ResourceAmount ra in _initialResources)
        {
            AddResources(ra);
        }
    }
    private void AddResources(ResourceAmount ra)
    {
        Debug.Log($"Adding {((Resources)ra["resource"]).ToString()}");

        if (!_resources.ContainsKey((Resources)ra["resource"]))
            _resources.Add((Resources)ra["resource"], (int)ra["amount"]);
        else
        {
            _resources[(Resources)ra["resource"]] += (int)ra["amount"];

            if (_resources[(Resources)ra["resource"]] > 100)
                _resources[(Resources)ra["resource"]] = 100;
        }
    }
    private void RemoveResources(ResourceAmount ra)
    {
        _resources[(Resources)ra["resource"]] -= (int)ra["amount"];
    }
    private void GetRandomResource()
    {
        Resources r = _allResources.RandomElement();
        int a = Random.Range(1,6) * 5;

        AddResources(new ResourceAmount(r, a));
    }
    
    // Missions
    private Missions GenerateMission()
    {
        MissionType gn = _possibleMissions.RandomElement();
        Debug.Log(gn.Name);

        Missions mission = gn.InstantiateMissions(_turn);

        _currentMissions.Add(mission);

        InstantiateMissionPrefab(mission);

        // Debug.Log(mission.ToString());

        return mission;
    }
    private void InstantiateMissionPrefab(Missions m)
    {
        GameObject newM = Instantiate(_missionPrefab,_missionLayoutGroup.transform);
        
        Button btt          = newM.GetComponent<Button>();
        Image bttImg        = newM.GetComponent<Image>();
        TextMeshProUGUI tmp = newM.GetComponentInChildren<TextMeshProUGUI>();
        HoverText hv        = newM.GetComponent<HoverText>();

        hv.Mission = m;
        btt.onClick.AddListener(() => AcceptMission(m,bttImg,btt));
        tmp.text = m.ToString();
    }
    public void AcceptMission(Missions mission, Image bttImage, Button btt)
    {
        if (_resources[(Resources)mission.Cost["resource"]] > (int)mission.Cost["amount"] && _manpower > mission.ManpowerReq)
        {
            _currentMissions.Remove(mission);
            _activeMissions.Add(mission);

            _manpower -= mission.ManpowerReq;
            RemoveResources(mission.Cost);

            Debug.Log($"{mission.Name} mission accepted");
            bttImage.color = new Color( 1, 1, 1, 0.5f);
            _prefabDeleteList.Add(bttImage.gameObject);
        }
        else
        {
            // btt.
        }
    }
    private void CheckMissions()
    {
        for (int i = 0; i < _activeMissions.Count; i++)
        {
            Missions m = _activeMissions[i];

            m.PassTurnActive();

            if (m.TurnsPassedA == m.TurnCost)
            {
                _activeMissions.Remove(m);
                _manpower += m.ManpowerReturn;
                AddResources(m.Reward);
            }
            else
            {
                _minigames.StartMinigame(m);
            }
        }
        for (int i = 0; i < _currentMissions.Count; i++)
        {
            Missions m = _currentMissions[i];

            m.PassTurnWaiting();

            if (m.TurnsPassedW == m.TurnDuration)
            {
                _currentMissions.Remove(m);
                // Debug.Log(idx);
                Destroy(_missionLayoutGroup.transform.GetChild(i).gameObject);
            }
            else
            {
                TextMeshProUGUI tmp = _missionLayoutGroup.transform.GetChild(i).gameObject.GetComponentInChildren<TextMeshProUGUI>();
                tmp.text = m.ToString();
            }
        }
        for (int i = 0; i < _prefabDeleteList.Count; i++)
        {
            Destroy(_prefabDeleteList[i]);
        }
    }
    private void RepostMissions()
    {
        int curM = _currentMissions.Count;

        if (curM < _missionsPerTurn)
        {
            int missing = _missionsPerTurn - curM;

            Debug.Log($"{missing} missions missing");

            if (missing > 0)
            {
                for (int i = 0; i < missing; i++)
                {
                    GenerateMission();
                }
            }
        }
    }
    
}
