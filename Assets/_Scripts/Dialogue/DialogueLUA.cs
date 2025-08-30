using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class DialogueLUA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Lua.RegisterFunction(
            "AddGoodAnswer",
            this,
            SymbolExtensions.GetMethodInfo(() => AddGoodAnswer())
        );

        Lua.RegisterFunction(
            "AddBadAnswer",
            this,
            SymbolExtensions.GetMethodInfo(() => AddBadAnswer())
);
    }

    void OnDestroy() {
        Lua.UnregisterFunction("AddGoodAnswer");
    
    }

    public void AddGoodAnswer()
    {
        //ServiceProvider.GameManager.CurrentRisk.AddGoodAnswer();
    }  

    public void AddBadAnswer()
    {
        //ServiceProvider.GameManager.CurrentRisk.AddBadAnswer();
    }
}
