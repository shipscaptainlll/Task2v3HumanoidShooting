using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintsDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoroyAfterDelay());
    }

    IEnumerator DestoroyAfterDelay()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
