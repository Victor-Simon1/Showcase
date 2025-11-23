using UnityEngine;

namespace Showcase
{
    [CreateAssetMenu(fileName = "ProjectileSpellStrategy", menuName = "ScriptableObjects/Spell/ProjectilepawnerStrategy")]
    public  class ProjectileSpellStrategy : SpellStrategy
    {
        public float speed;
        public float duration;
        public override void InvocSpell(Transform origin,Vector3 direction,EElement element)
        {
            GameObject aura = new SpellBuilder()
            .WithSpellPrefab(spellPrefab)
            .WithSpeed(speed)
            .WithDuration(duration)
            .WithElement(element)
            .Build(origin,direction);
        }
    }

}
