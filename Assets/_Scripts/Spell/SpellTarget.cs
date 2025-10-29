using System.Collections;
using MyUnityPackage.Toolkit;
using UnityEngine;

public class SpellTarget : MonoBehaviour,ISpellTarget
{
    private enum TargetState
    {
        IDLE,
        CHANGING
    }
    EElement currentElement;
    TargetState state; 
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        state = TargetState.IDLE;
        ChangeElement();
    }
    public void OnBeingHit()
    {
        MUPLogger.Info(name + " hit by a spell ");
        if(state == TargetState.CHANGING)
            return;
        StartCoroutine(ChangeState());
    }
    IEnumerator ChangeState()
    {
       
        ActiveMesh(false);
        state = TargetState.CHANGING;
        ChangeElement();
        yield return new WaitForSeconds(3);
        
        state = TargetState.IDLE;
        ActiveMesh(true);
    }
    void ActiveMesh(bool isActive )
    {
        meshRenderer.enabled = isActive;
        capsuleCollider.enabled = isActive;
    }
    private void ChangeElement()
    {
        currentElement = (EElement)Random.Range(0, (int)EElement.NULL);
    }
}
