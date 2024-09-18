using UnityEngine;


public class HealthCollectible : MonoBehaviour
{
    [SerializeField]private float healthValue;
    [Header("SFX")]
    [SerializeField] private AudioClip pickupsound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(pickupsound);
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }

}
