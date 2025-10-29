using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void Init(float duration)
    {
        StartCoroutine(DestroySelf(duration));
    }
    private IEnumerator DestroySelf(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
