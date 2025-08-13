using UnityEngine;
using MyUnityPackage.ProgressionSystem;

[CreateAssetMenu(fileName = "MayorObjectiveSO", menuName = "ScriptableObjects/Quest/MayorObjectiveSO")]
public class MayorObjectiveSO : ObjectiveDataSO
{
    public override IQuestObjective CreateRuntimeObjective()
    {
         return new MayorObjectObjective();
    }
}
