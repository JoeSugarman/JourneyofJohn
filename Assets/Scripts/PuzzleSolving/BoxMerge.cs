using Unity.VisualScripting;
using UnityEngine;

public class BoxMerge : MonoBehaviour
{
    public GameObject mergedBoxPrefab; //precreate a box for replacing the two boxes

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {

            if (this.gameObject.GetInstanceID() < collision.gameObject.GetInstanceID()) 
            {
                Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
                //get reference to both boxes
                GameObject box1 = this.gameObject;
                GameObject box2 = collision.gameObject;

                //calculate the new size
                Vector2 size1 = box1.GetComponent<SpriteRenderer>().size;
                Vector2 size2 = box2.GetComponent<SpriteRenderer>().size;
                Vector2 newSize = size1 + size2;

                //calculate the new position
                Vector2 newPosition = (box1.transform.position + box2.transform.position) / 2;

                //create the new box
                GameObject mergedBox = Instantiate(mergedBoxPrefab, newPosition, Quaternion.identity);

                // Set the size of the merged box
                SpriteRenderer mergedRenderer = mergedBox.GetComponent<SpriteRenderer>();
                if (mergedRenderer != null)
                {
                    mergedRenderer.size = newSize;
                }
                else
                {
                    Debug.LogError("Merged box prefab is missing a SpriteRenderer.");
                }

                // Destroy the old boxes
                Destroy(box1);
                Destroy(box2);
            }




            ////set the new size
            //mergedBox.GetComponent<SpriteRenderer>().size = newSize;

            //Destroy(box1);
            //Destroy(box2);
        }
    }

    
}
