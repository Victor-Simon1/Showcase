using MyUnityPackage.Toolkit;
using Showcase;
using UnityEngine;

public class Villager : MonoBehaviour
{
    [SerializeField] AuraStrategy[] auras;
    int currentAura = -1;
    GameObject aura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Init auras
        if(auras.Length > 0)
        {
            SetAura();
        }
    }

    public void SetAura()
    {
        MUPLogger.Info("Set aura of villager");
        Destroy(aura);
        if(currentAura == 0)
        {
            aura = auras[1].InvocAura(transform);
            currentAura = 1;
        }
        else
        {
            aura = auras[0].InvocAura(transform);
            currentAura = 0;
        }
        aura.transform.SetParent(transform, true);
        aura.transform.localPosition = new Vector3(0, 2,0);
        Quaternion quat = Quaternion.Euler(-90, 0,0);
        aura.transform.rotation = quat;
    
    }
    public EPNJ GetPNJ() => GetComponent<InteractableVillager>().pnj;
}
