using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    public int numberOfTreasures = 5;
    public GameObject treasurePrefab;
    public float spawnRadius = 4.5f;
    public float leftBorder = -3f;
    public float rightBorder = 13f;
    public float upBorder = 9f;
    public float downBorder = 0f;

    void Start()
    {
        SpawnTreasures();
    }

    void SpawnTreasures()
    {
        for (int i = 0; i < numberOfTreasures; i++)
        {
            Vector2 randomPosition = GetRandomPositionWithinBorders();

            Instantiate(treasurePrefab, randomPosition, Quaternion.identity);
        }
    }
    Vector2 GetRandomPositionWithinBorders()
    {
        float randomX = Random.Range(leftBorder, rightBorder);
        float randomY = Random.Range(downBorder, upBorder);

        return new Vector2(randomX, randomY);
    }
}
