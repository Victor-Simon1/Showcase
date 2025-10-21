using MyUnityPackage.Interactions;
using MyUnityPackage.Toolkit;
using UnityEngine;

public class NameEffect : AEffect
{
    public string VillagerName{get;set;}
    public override void OnDisable()
    {
        
       
    }

    public override void OnEnable()
    {
       
    }

    public override void OnEnter()
    {
         ServiceLocator.GetService<VillagerNameUI>().Show(VillagerName);
    }

    public override void OnExit()
    {
        ServiceLocator.GetService<VillagerNameUI>().Hide();
    }

    public override void OnInteract()
    {
    }


}
