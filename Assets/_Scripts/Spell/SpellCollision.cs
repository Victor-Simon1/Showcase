using MyUnityPackage.Toolkit;
using UnityEngine;

public class SpellCollision : MonoBehaviour
{

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
            st.OnBeingHit();
            DestroySpell();
        }
    }
}
