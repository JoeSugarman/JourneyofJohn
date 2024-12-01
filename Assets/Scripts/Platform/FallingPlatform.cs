using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 2.0f;
    private float destroyDelay = 2.0f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject vanishEffect;
    private bool destroyStarted;
    private Vector3 initPosition;

    void Start()
    {
        initPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(destroyStarted) return;
        if (!collision.otherCollider.usedByEffector) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        destroyStarted = true;
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        Instantiate(vanishEffect, transform.position, Quaternion.identity);
        Reset();
    }

    private async void Reset()
    {
        gameObject.SetActive(false);
        await Task.Delay(5000);
        try { 
            destroyStarted = false;
            rb.bodyType = RigidbodyType2D.Static;
            gameObject.transform.position = initPosition;
            gameObject.SetActive(true);
        }
        catch { }
    }

}


