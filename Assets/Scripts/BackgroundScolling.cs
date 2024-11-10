using UnityEngine;

public class BackgroundScolling : MonoBehaviour
{
    public Transform[] backgrounds; //array of all the backgrounds to be scrolled
    private float[] parralaxScales; //proportion of the camera's movement to move the backgrounds by
    [SerializeField] private float smoothing = 1f; //how smooth the parallax is going to be. Make sure to set this above 0

    private Transform cam;
    private Vector3 previousCamPos; //store the position of the camera in the previous frame

    void Awake()
    {
        cam = Camera.main.transform;
    }


    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        parralaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parralaxScales[i] = backgrounds[i].position.z * -1; //set the parralax scales to the z position of the backgrounds
        }
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parralax = (previousCamPos.x - cam.position.x) * parralaxScales[i]; //calculate the parralax amount
            float backgorundTargetPosX = backgrounds[i].position.x + parralax; //calculate the target x position of the background

            //create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgorundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between the current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}