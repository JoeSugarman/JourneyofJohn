using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //sound for player pickup a new checkpoint
    private Transform currentCheckpoint; //the last checkpoint the player touched
    private Health health; //reference to the player's health script
    private UIManager uiManager; //reference to the UI manager script

    private void Awake()
    {
        health = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        //check if check point available
        if(currentCheckpoint == null)
        {
            //show game over screen
            uiManager.GameOver();
            return; //dont execute the rest of the code
        }

        transform.position = currentCheckpoint.position; //move the player to the last checkpoint
        health.Respawn();//restore the player's health and reset the animation

        //move the camera to the player's position
        Camera.main.GetComponent<CameraControl>().MoveToNewRoom(currentCheckpoint.parent);
    }



    //activate checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; //store the checkpoint that we activated as the current one
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; //disable the collider so we can't activate it again
            collision.GetComponent<Animator>().SetTrigger("appear"); //play the animation for the checkpoint
        }
    }

}
