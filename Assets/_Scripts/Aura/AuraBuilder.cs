using UnityEngine;

public class AuraBuilder 
{
    public GameObject auraPrefab;
    private float duration;
    public AuraBuilder WithAuraPrefab(GameObject _auraPrefab)
    {
        auraPrefab = _auraPrefab; 
        return this;
    }
    public AuraBuilder WithDuration(float _duration)
    {
        duration = _duration;
        return this;
    }
    public GameObject Build(Transform origin)
    {
        Vector3 instantiatePos = origin.position;

        GameObject aura = GameObject.Instantiate(auraPrefab, instantiatePos,Quaternion.identity);
        return aura;
    }
}