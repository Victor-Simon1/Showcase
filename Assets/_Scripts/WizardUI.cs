using System.Collections.Generic;
using MyUnityPackage.Toolkit;
using UnityEngine;
using UnityEngine.UI;

public class WizardUI : MonoBehaviour
{
    [SerializeField] GameObject spellUIPrefab;
    [SerializeField] GameObject selectUIPrefab;
    GameObject selectSpellObject;
    List<GameObject> spellsUI;

    public void InitUI(SpellStrategy[] spells)
    {
        //if >0 ui is already init
        if(spellsUI != null)
            return;

        spellsUI = new List<GameObject>();
        for(int i = 0; i < spells.Length;i++)
        {
            GameObject spell = Instantiate(spellUIPrefab,transform.position,Quaternion.identity,transform);
            spell.GetComponentInChildren<Image>().sprite = spells[i].UISpell;
            spellsUI.Add(spell);
            if(i == spells.Length/2)
            {
                selectSpellObject = Instantiate(selectUIPrefab,spell.transform.position,Quaternion.identity,spell.transform);
                //selectSpellObject.transform.SetSiblingIndex(0);
            }
        } 
    }
    public void UpdateUI(int currentSpell)
    {
        MUPLogger.Info("Spell " + currentSpell);
        selectSpellObject.transform.SetParent(spellsUI[currentSpell].transform,false);
       
        //selectSpellObject.transform.SetSiblingIndex(0);
        //selectSpellObject.transform.position = new Vector2(0,0);
    }
    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
}
