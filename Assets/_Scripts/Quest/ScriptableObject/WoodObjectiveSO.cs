using MyUnityPackage.ProgressionSystem;
using UnityEngine;


namespace Showcase
{
    [CreateAssetMenu(fileName = "WoodObjectiveSO", menuName = "ScriptableObjects/Quest/Pickable/WoodObjectiveSO")]
    public class WoodObjectiveSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new WoodObjective("Get Wood" , "Get Wood", 5);
        }
    }
}
