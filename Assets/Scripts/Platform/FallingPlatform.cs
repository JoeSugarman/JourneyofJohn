using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay;
    [SerializeField] private float fallSpeed;
    [SerializeField] private float destroyThreshold = 10f;

    private bool isFalling = false;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.Translate (Vector3.down* fallSpeed * Time.deltaTime);

            if (transform.position.y < destroyThreshold)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("StartFalling", fallDelay);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }


}
