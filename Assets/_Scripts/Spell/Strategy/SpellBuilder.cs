using UnityEngine;

namespace Showcase
{
    public class SpellBuilder 
    {
        public GameObject spellPrefab;
        private float duration;
        private float speed;
        private EElement element = EElement.NULL;
        public SpellBuilder WithSpellPrefab(GameObject _spellPrefab)
        {
            spellPrefab = _spellPrefab; 
            return this;
        }
        public SpellBuilder WithDuration(float _duration)
        {
            duration = _duration;
            return this;
        }
        public SpellBuilder WithSpeed(float _speed)
        {
            speed = _speed;
            return this;
        }
        public SpellBuilder WithElement(EElement _element)
        {
            element = _element;
            return this;
        }
        public GameObject Build(Transform origin,Vector3 direction)
        {
            Vector3 instantiatePos = origin.position;
            
            GameObject spell = GameObject.Instantiate(spellPrefab, instantiatePos,Quaternion.identity);
            if(duration > 0)
            {
                SelfDestruct selfDestruct = spell.AddComponent<SelfDestruct>();
                selfDestruct.Init(duration);
            }
            if(speed > 0)
            {
                Rigidbody rb = spell.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.linearVelocity = speed* direction;
            }
            SpellCollision sc = spell.AddComponent<SpellCollision>();
            if(element != EElement.NULL)
                sc.SetElement(element);
            return spell;
        }
    }
}
