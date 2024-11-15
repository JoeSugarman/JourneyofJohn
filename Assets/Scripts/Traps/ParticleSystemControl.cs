using System.Collections;
using UnityEngine;

public class ParticleSystemControl : MonoBehaviour
{
    public GameObject particleSystemOne;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision Detected with " + collision.gameObject.name);
            StartCoroutine(PlayParticleEffect());
        }
    }

    private IEnumerator PlayParticleEffect()
    {
        particleSystemOne.SetActive(true);

        yield return new WaitForSeconds(2f);

        particleSystemOne.SetActive(false);
    }
}
