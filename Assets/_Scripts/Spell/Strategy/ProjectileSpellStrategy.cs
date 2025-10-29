using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSpellStrategy", menuName = "ScriptableObjects/Spell/ProjectilepawnerStrategy")]
public  class ProjectileSpellStrategy : SpellStrategy
{
    public float speed;
    public float duration;
    public override void InvocSpell(Transform origin)
    {
        GameObject aura = new SpellBuilder()
        .WithSpellPrefab(spellPrefab)
        .WithSpeed(speed)
        .WithDuration(duration)
        .Build(origin);
    }
}
