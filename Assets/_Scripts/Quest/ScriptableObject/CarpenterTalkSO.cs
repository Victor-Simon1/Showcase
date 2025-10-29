using MyUnityPackage.ProgressionSystem;
using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "CarpenterTalkSO", menuName = "ScriptableObjects/Quest/Villager/CarpenterTalkSO")]
    public class CarpenterTalkSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new VillagerTalkObjective("Talk to the Carpenter","The Carpenter greets you !",1,EPNJ.Carpenter);
        }
    }
}

