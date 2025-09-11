using UnityEngine;
using MyUnityPackage.ProgressionSystem;

namespace Showcase
{
     [CreateAssetMenu(fileName = "MayorTalkSO", menuName = "ScriptableObjects/Quest/Villager/MayorTalkSO")]
     public class MayorTalkSO : ObjectiveDataSO
     {
          public override IQuestObjective CreateRuntimeObjective()
          {
               return new VillagerTalkObjective("Talk to the Mayor","The Mayor greets you !",1,PNJ.Mayor);
          }
     }
}

