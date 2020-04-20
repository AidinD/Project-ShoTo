using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private GameObject[] enemies;
    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
        StartCoroutine(Spawn(spawnRate));
    }

    private IEnumerator Spawn(float spawnRate)
    {
        float spawnPosition = Random.Range(-screenBounds.x, screenBounds.x);
        yield return new WaitForSeconds(spawnRate);
        Instantiate(enemies[0], new Vector2(spawnPosition, screenBounds.y), Quaternion.identity);
        StartCoroutine(Spawn(spawnRate));

    }
}
