using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public List<FoodItem> spawnedFood = new List<FoodItem>();
    public int maxFood = 10;
    public float spawnRadius = 5f;
    public Vector2 boxSize = new Vector2(10f, 10f);
    public LayerMask obstacleLayer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(boxSize.x, boxSize.y, 0f));
    }

    void Start()
    {
        SpawnCycle();
    }

    void SpawnCycle()
    {
        for (int i = 0; i < maxFood; i++)
        {
            SpawnFood();
        }
    }

    void SpawnFood()
    {   
        int index = Random.Range(0, foodPrefabs.Length);

        while (spawnedFood.Contains(foodPrefabs[index].GetComponent<FoodItem>()))
        {
            index = Random.Range(0, foodPrefabs.Length);
        }

        Vector3 randomPos = new Vector3(Random.Range(-boxSize.x / 2, boxSize.x / 2), Random.Range(-boxSize.y / 2, boxSize.y / 2), 0f);

        // Check if the random position collides with the obstacle layer
        Collider2D overlap = Physics2D.OverlapCircle(transform.position + randomPos, 0.1f, obstacleLayer);

        // If the random position collides with the obstacle layer, generate a new random position
        while (overlap != null)
        {
            randomPos = new Vector3(Random.Range(-boxSize.x / 2, boxSize.x / 2), Random.Range(-boxSize.y / 2, boxSize.y / 2), 0f);
            overlap = Physics2D.OverlapCircle(transform.position + randomPos, 0.4f, obstacleLayer);
        }
         
        Instantiate(foodPrefabs[index], transform.position + randomPos, Quaternion.identity);

        spawnedFood.Add(foodPrefabs[index].GetComponent<FoodItem>());
    }
}
