using MyUnityPackage.ProgressionSystem;
using MyUnityPackage.Toolkit;
using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "MayorSecondTalkSO", menuName = "ScriptableObjects/Quest/MayorSecondTalkSO")]
    public class MayorSecondTalkSO : ObjectiveDataSO
    {
        public override IQuestObjective CreateRuntimeObjective()
        {
            var villagerTalkObjective = new VillagerTalkObjective(title, "", 1);
            villagerTalkObjective.OnCompleted += EndDialog;
            return villagerTalkObjective;
        }
        private void EndDialog()
        {
            ServiceLocator.GetService<QuestManager>().ActivateQuest("Quest2");
        }
    }
}
