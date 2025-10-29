using UnityEngine;

[CreateAssetMenu(fileName = "SpellStrategy", menuName = "ScriptableObjects/Spell/SpellSpawnerStrategy")]
public class SpellSpawnerStrategy : SpellStrategy
{
    public float duration;
    public override void InvocSpell(Transform origin)
    {
        GameObject aura = new SpellBuilder()
        .WithSpellPrefab(spellPrefab)
        .WithDuration(duration)
        .Build(origin);
    }
}
