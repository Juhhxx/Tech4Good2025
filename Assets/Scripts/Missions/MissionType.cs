using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "MissionType", menuName = "Scriptable Objects/MissionType")]
public class MissionType : ScriptableObject
{
    public string Name;
    public List<MissionResources> Cost;
    public List<MissionResources> Rewards;

    public Missions InstantiateMissions(int currentTurn)
    {
        int missionLevel = currentTurn;
        
        MissionResources cost = Cost.RandomElement();
        MissionResources reward = Rewards.RandomElement();

        int costAmount      = Random.Range( 1, 11 + missionLevel) * 5;
        int rewardAmount    = Random.Range( 1, 1 + (costAmount / 5)) * 5;

        ResourceAmount resourceCost     = new ResourceAmount( cost, costAmount);
        ResourceAmount resourceReward   = new ResourceAmount( reward, rewardAmount);

        int manpowerReq = 5 + costAmount / 2;

        int turnCost = 1 + (int)Mathf.Ceil(manpowerReq / 10);

        int turnDuration = Random.Range( 1, 3);
        
        return new Missions( Name, manpowerReq, resourceCost, resourceReward, turnCost, turnDuration);
    }
}
