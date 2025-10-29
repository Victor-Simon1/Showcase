using UnityEngine;

[CreateAssetMenu(fileName = "AuraStrategy", menuName = "ScriptableObjects/Aura/AuraSpawnerStrategy")]
public class AuraSpawnerStrategy : AuraStrategy
{
    public GameObject auraPrefab;

    public override GameObject InvocAura(Transform origin)
    {
        GameObject aura = new AuraBuilder()
        .WithAuraPrefab(auraPrefab)
        .Build(origin);

        return aura;
    }
}
