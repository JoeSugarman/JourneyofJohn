using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    //[SerializeField] private Transform player;
    //[SerializeField] private float parallaxFactor = 0f;
    //[SerializeField] private Vector2 offset = Vector2.zero;

    //private Vector3 lastPlayerPosition;

    //private void Start()
    //{
    //    lastPlayerPosition = player.position;
    //}


    //private void LateUpdate()
    //{
    //    if (player != null)
    //    {
    //        Vector3 delta = player.position - lastPlayerPosition;
    //        transform.position += new Vector3(delta.x * parallaxFactor, delta.y * parallaxFactor, 0);
    //        lastPlayerPosition = player.position;
    //    }
    //}
    [SerializeField] private Transform player;
    [SerializeField] float wrapThreshold = 20f;
    [SerializeField] float wrapOffset = 10f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (player == null) return;

        float distanceMoved = player.position.x - startPosition.x;

        if(Mathf.Abs(distanceMoved) >= wrapThreshold)
        {
            transform.position += new Vector3(Mathf.Sign(distanceMoved) * wrapOffset, 0, 0);

            startPosition += new Vector3(Mathf.Sign(distanceMoved) * wrapOffset, 0, 0);
        }
    }

}
