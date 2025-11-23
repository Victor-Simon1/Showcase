using MyUnityPackage.Toolkit;
using UnityEngine;

namespace Showcase
{
    public class SpellCollision : MonoBehaviour
    {
        EElement currentElement;

        public void SetElement(EElement element)
        {
            this.currentElement = element;
        }
        void DestroySpell()
        {
            Destroy(gameObject);
        }
        void OnCollisionEnter(Collision collision)
        {
            MUPLogger.Info("OnCollisionEnter ");
            SpellTarget st = collision.gameObject.GetComponent<SpellTarget>();
            if (st != null)
            {
                MUPLogger.Info("SpellTarget of type " + st.DebugElement() + " has been touch by spell of type " + currentElement.ToString());
                st.OnBeingHit(currentElement);
                DestroySpell();
            }
        }
    }
}

