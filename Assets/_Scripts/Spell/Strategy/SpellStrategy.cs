
using UnityEngine;
using UnityEngine.UI;

public abstract class SpellStrategy : ScriptableObject
{
    public GameObject spellPrefab;
    public Sprite UISpell;    
    public EElement element;
    public abstract void InvocSpell(Transform origin);
}
