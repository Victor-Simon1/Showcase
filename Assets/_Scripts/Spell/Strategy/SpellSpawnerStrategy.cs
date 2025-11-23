using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "SpellStrategy", menuName = "ScriptableObjects/Spell/SpellSpawnerStrategy")]
    public class SpellSpawnerStrategy : SpellStrategy
    {
        public float duration;
        public override void InvocSpell(Transform origin,Vector3 direction,EElement element)
        {
            GameObject aura = new SpellBuilder()
            .WithSpellPrefab(spellPrefab)
            .WithDuration(duration)
            .Build(origin,direction);
        }
    }
}

