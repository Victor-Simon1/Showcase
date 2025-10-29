using System.Collections;
using MyUnityPackage.Toolkit;
using Showcase;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField] SpellStrategy[] spells;
    [SerializeField] int currentSpell = 1;
    WizardUI wizardUI;
    float cooldown = 5;
    bool canDoSpell = true;
    void OnTriggerEnter(Collider other)
    {
        ServiceLocator.GetService<PlayerActions>().OnSpell += ManageSpell;
        wizardUI = ServiceLocator.GetService<WizardUI>();

        wizardUI.InitUI(spells);
        wizardUI.ShowUI();
       
    }
    void OnTriggerExit(Collider other)
    {
        ServiceLocator.GetService<PlayerActions>().OnSpell -= ManageSpell;
        wizardUI.HideUI();
    }

    void ManageSpell(int type)
    {
        switch (type)
        {
            case -1:
                currentSpell = currentSpell == 0? 0 : currentSpell-1;
                wizardUI.UpdateUI(currentSpell);
                break;
            case 1:
                currentSpell = currentSpell == (spells.Length-1)? currentSpell : currentSpell+1;
                wizardUI.UpdateUI(currentSpell);
                break;
            case 0:
                InvocSpeel(currentSpell);
                break;
            default:
                MUPLogger.Error("Spell Action not reconize !");
                break;
        }
    }
    void InvocSpeel(int index)
    {
        if(!canDoSpell)
            return;
        spells[index].InvocSpell(transform);
        StartCoroutine(CooldownSpell());
    }
    IEnumerator CooldownSpell()
    {
        canDoSpell = false;
        yield return new WaitForSeconds(cooldown);
        canDoSpell = true;
    }
}
