using System.Collections;
using System.Diagnostics;
using MyUnityPackage.Toolkit;
using UnityEngine;

namespace Showcase
{
    public class SpellTarget : MonoBehaviour,ISpellTarget
    {
        private enum TargetState
        {
            IDLE,
            CHANGING
        }
        [Header("Compoenent")]
        BoxCollider boxCollider;
        MeshRenderer meshRenderer;
        [Header("Variable")]
        EElement currentElement;
        TargetState state; 
        [SerializeField] float timeToChange = 3f;
        Vector3 basePos = Vector3.zero;
        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            boxCollider = GetComponent<BoxCollider>();
            state = TargetState.IDLE;
            basePos = transform.position;
            ChangeElement();
        }
        public void OnBeingHit(EElement spellElement)
        {
            MUPLogger.Info(name + " hit by a spell ");
            if(state == TargetState.CHANGING)
                return;
            if(spellElement == currentElement.GetCounterElement())
                StartCoroutine(ChangeState());
        }   
        void ActiveMesh(bool isActive )
        {
            meshRenderer.enabled = isActive;
            boxCollider.enabled = isActive;
        }

        #region ELEMENT_FUNCTION
        IEnumerator ChangeState()
        {
        
            ActiveMesh(false);
            transform.position = basePos + new Vector3(Random.Range(-2,2),Random.Range(-2,2),0);
            state = TargetState.CHANGING;
            ChangeElement();
            yield return new WaitForSeconds(timeToChange);
            
            state = TargetState.IDLE;
            ActiveMesh(true);
        }
        private void ChangeElement()
        {
            currentElement = (EElement)Random.Range(0, (int)EElement.NULL);
            meshRenderer.material = ElementExtensions.materials[(int)currentElement];
        }
        #endregion

        #region DEBUG

        public string DebugElement() => currentElement.ToString();

        #endregion
    
    }

}
