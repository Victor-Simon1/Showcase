using UnityEngine;
using MyUnityPackage.ProgressionSystem;

namespace Showcase
{
     [CreateAssetMenu(fileName = "MayorTalkSO", menuName = "ScriptableObjects/Quest/Villager/MayorTalkSO")]
     public class MayorTalkSO : ObjectiveDataSO
     {
          public override IQuestObjective CreateRuntimeObjective()
          {
               return new VillagerTalkObjective(Title,Description,1,EPNJ.Mayor);
          }
     }
}

