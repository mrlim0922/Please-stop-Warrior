using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Stage1_enemy;

    public int minCount = 0;
    public int maxCount = 3;

    public bool summon = true;

    public float spawnTime = 7f;

    private void Awake()
    {
        StartCoroutine(SpawnItems1(0f));
    }

    IEnumerator SpawnItems1(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        if (summon)
        {
            Vector3 temp = new Vector3(transform.position.x, transform.position.y, -1);

            int random = Random.Range(minCount, maxCount);

            Instantiate(Stage1_enemy[random], temp, Quaternion.identity);
        }

        StartCoroutine(SpawnItems1(spawnTime));
    }
}
