using UnityEngine;
using MyUnityPackage.ProgressionSystem;


namespace Showcase
{
     [CreateAssetMenu(fileName = "MayorTalkSO", menuName = "ScriptableObjects/Quest/MayorTalkSO")]
     public class MayorTalkSO : ObjectiveDataSO
     {
          public override IQuestObjective CreateRuntimeObjective()
          {
               return new TalkMayorObjective("Talk to the Mayor","The Mayor greets you !",1);
          }
     }
}

