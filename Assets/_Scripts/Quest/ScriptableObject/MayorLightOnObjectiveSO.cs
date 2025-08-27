using UnityEngine;
using MyUnityPackage.ProgressionSystem;


namespace Showcase
{
    [CreateAssetMenu(fileName = "MayorObjectiveSO", menuName = "ScriptableObjects/Quest/MayorObjectiveSO")]
    public class MayorObjectiveSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            return new MayorLightOnObjective("Get the object","The mayor has lost an object in the village, find him and return him to the mayor !",GameObject.FindObjectsOfType<InteractableLight>().Length);
        }
    }
}

