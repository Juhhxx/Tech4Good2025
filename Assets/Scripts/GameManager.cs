using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _troops;
    private Dictionary<MissionResources,int> _resources;
    private List<Missions> _currentMission;
    private Queue<Missions> _activeMissions;
}
