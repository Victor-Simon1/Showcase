using UnityEngine;

public class SpellBuilder 
{
    public GameObject auraPrefab;
    private float duration;
    private float speed;
    public SpellBuilder WithSpellPrefab(GameObject _auraPrefab)
    {
        auraPrefab = _auraPrefab; 
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
    public GameObject Build(Transform origin)
    {
        Vector3 instantiatePos = origin.position;

        GameObject spell = GameObject.Instantiate(auraPrefab, instantiatePos,Quaternion.identity);
        if(duration > 0)
        {
            SelfDestruct selfDestruct = spell.AddComponent<SelfDestruct>();
            selfDestruct.Init(duration);
        }
        if(speed > 0)
        {
            Rigidbody rb = spell.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.linearVelocity = speed* origin.forward;
        }
        spell.AddComponent<SpellCollision>();
        return spell;
    }
}