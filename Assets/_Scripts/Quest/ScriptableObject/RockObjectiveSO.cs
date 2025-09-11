using MyUnityPackage.ProgressionSystem;
using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "RockObjectiveSO", menuName = "ScriptableObjects/Quest/Pickable/RockObjectiveSO")]
    public class RockObjectiveSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new RockObjective("Rock" , "Rock", 5);
        }
    }
}
