using UnityEngine;

[CreateAssetMenu(fileName = "AuraSpawnerDurationStrategy", menuName = "ScriptableObjects/Aura/AuraSpawnerDurationStrategy")]
public class AuraSpawnerDurationStrategy : AuraSpawnerStrategy
{
    public float duration;
    public override GameObject InvocAura(Transform origin)
    {
        GameObject aura = new AuraBuilder()
        .WithAuraPrefab(auraPrefab)
        .WithDuration(duration)
        .Build(origin);

        return aura;
    }
}
