using System.Collections;
using UnityEngine;

public class treeSpawner : MonoBehaviour
{
    public GameObject[] treePrefabs;
    public float spawnRangeX = 5f;
    public float spawnDuration = 20f;
    public float spawnInterval = 2.5f;

    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectsOverTime());
    }

    IEnumerator SpawnObjectsOverTime()
    {
        while (elapsedTime<spawnDuration)
        {
            //select a random prefab
            GameObject randomObject = treePrefabs[Random.Range(0, treePrefabs.Length)];
            
            //calculate a random position within the spawn range
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                transform.position.y,
                transform.position.z
            );

            //spawn the object
            Instantiate(randomObject, spawnPosition, Quaternion.identity);

            //yield return
            yield return new WaitForSeconds(spawnInterval);

            elapsedTime += spawnInterval;
        }
    }

    private void OnDrawGizmos()
    {
        // Set the color of the Gizmos
        Gizmos.color = Color.green;

        // Draw a line representing the spawn range
        Vector3 leftPoint = new Vector3(transform.position.x - spawnRangeX, transform.position.y, transform.position.z);
        Vector3 rightPoint = new Vector3(transform.position.x + spawnRangeX, transform.position.y, transform.position.z);

        Gizmos.DrawLine(leftPoint, rightPoint);

        // Optionally, draw spheres at the edges for clarity
        Gizmos.DrawSphere(leftPoint, 0.2f);
        Gizmos.DrawSphere(rightPoint, 0.2f);
    }

}
