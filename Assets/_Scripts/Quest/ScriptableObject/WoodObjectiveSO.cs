using MyUnityPackage.ProgressionSystem;
using UnityEngine;


namespace Showcase
{
    [CreateAssetMenu(fileName = "WoodObjectiveSO", menuName = "ScriptableObjects/WoodObjectiveSO")]
    public class WoodObjectiveSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new WoodObjective();
        }
    }
}
