using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MissionType", menuName = "Scriptable Objects/MissionType")]
public class MissionType : ScriptableObject
{
    public string Name;
    public List<Resources> Cost;
    public List<Resources> Rewards;
    public GameObject Minigame;
    [TextArea] public string[] Texts;

    public Missions InstantiateMissions(int currentTurn)
    {
        int missionLevel = currentTurn;
        
        Resources cost = Cost.RandomElement();
        Resources reward = Rewards.RandomElement();

        int costAmount      = Random.Range( 1, 6 + missionLevel) * 5;
        int rewardAmount    = Random.Range( 1, 1 + (costAmount / 5)) * 5;

        ResourceAmount resourceCost     = new ResourceAmount( cost, costAmount);
        ResourceAmount resourceReward   = new ResourceAmount( reward, rewardAmount);

        int manpowerReq = 5 + costAmount / 2;

        int turnCost = 1 + (int)Mathf.Ceil(manpowerReq / 10);

        int turnDuration = Random.Range( 1, 5);

        string text = Texts[missionLevel];
        
        return new Missions( Name, manpowerReq, resourceCost, resourceReward, turnCost, turnDuration, text);
    }
}
