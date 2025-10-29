using MyUnityPackage.ProgressionSystem;
using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "BlacksmithTalkSO", menuName = "ScriptableObjects/Quest/Villager/BlacksmithTalkSO")]
    public class BlacksmithTalkSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new VillagerTalkObjective("Talk to the Blacksmith","The Blacksmith greets you !",1,EPNJ.Blacksmith);
        }
    }
}
