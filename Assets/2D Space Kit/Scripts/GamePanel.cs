using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject starPrefab;
    float rate;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float destroyTime = 10f;
    public float destroyTime2 = 15f;
    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
        InvokeRepeating("InstantiateStar", 1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector2(Random.Range(minInstantiateValue, maxInstantiateValue), 70);
        GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.identity);
        Destroy(enemy, destroyTime);
    }
    void InstantiateStar()
    {
        Vector3 enemypos = new Vector2(Random.Range(minInstantiateValue, maxInstantiateValue), 70);
        GameObject enemy = Instantiate(starPrefab, enemypos, Quaternion.identity);
        Destroy(enemy, destroyTime2);
    }
}
