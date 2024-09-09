using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour
{

    public ParticleSystem leaf;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine("DustShow");
    }

    IEnumerator DustShow()
    {
        var particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
        if (leaf != null)
        {
            leaf.Play();
        }
        yield return new WaitForSeconds(3.0f);
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
        if (leaf != null)
        {
            leaf.Stop();
        }
    }
}
