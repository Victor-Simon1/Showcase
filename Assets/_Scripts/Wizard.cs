using System.Collections;
using MyUnityPackage.Controller;
using MyUnityPackage.Toolkit;

using UnityEngine;

namespace Showcase
{
    public class Wizard : MonoBehaviour
    {
        [SerializeField] SpellStrategy[] spells;
        [SerializeField] int currentSpell = 1;
        WizardUI wizardUI;
        float cooldown = 5;
        bool canDoSpell = true;
        void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.GetComponent<PlayerController>())
            {
                return;
            }
            ServiceLocator.GetService<PlayerActions>().OnSpell += ManageSpell;
            wizardUI = ServiceLocator.GetService<WizardUI>();

            wizardUI.InitUI(spells);
            wizardUI.ShowUI();
        
        }
        void OnTriggerExit(Collider other)
        {
            if(!other.gameObject.GetComponent<PlayerController>())
            {
                return;
            }
            ServiceLocator.GetService<PlayerActions>().OnSpell -= ManageSpell;
            wizardUI.HideUI();
        }

        void ManageSpell(int type)
        {
            switch (type)
            {
                case -1://Go left
                    currentSpell = currentSpell == 0? 0 : currentSpell-1;
                    wizardUI.UpdateUI(currentSpell);
                    break;
                case 1://Go right
                    currentSpell = currentSpell == (spells.Length-1)? currentSpell : currentSpell+1;
                    wizardUI.UpdateUI(currentSpell);
                    break;
                case 0://Spell
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
            Transform playerTransform = ServiceLocator.GetService<PlayerController>().transform;
            
            Transform cameraTransform = playerTransform.GetChild(0).transform;
            playerTransform.SetPositionAndRotation(playerTransform.position +  Vector3.up/2 + cameraTransform.forward ,playerTransform.rotation);

            spells[index].InvocSpell(playerTransform ,cameraTransform.forward,(EElement)index);
            StartCoroutine(CooldownSpell());
        }
        IEnumerator CooldownSpell()
        {
            canDoSpell = false;
            yield return new WaitForSeconds(cooldown);
            canDoSpell = true;
        }
    }

}
