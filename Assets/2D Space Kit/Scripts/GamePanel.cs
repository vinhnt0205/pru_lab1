using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float destroyTime = 10f;
    void Start()
    {
        InvokeRepeating("InstantiateEnemy", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateEnemy()
    {
        Vector3 enemypos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 70);
        GameObject enemy = Instantiate(enemyPrefab, enemypos, Quaternion.identity);
        Destroy(enemy, destroyTime);

    }
}
