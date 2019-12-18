using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        transform.Rotate(75, 0, 0);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
