using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public int number;
    public float spawnRadius;
    public bool spawnOnStart = true;
    //public GameObject ragDollPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart)
        {
            CreateAllZombies();
        }

    }

    private void CreateAllZombies()
    {
        for (int i = 0; i < number; i++)
        {

            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;
            
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                int r = Random.Range(0, zombiePrefabs.Length);
                Instantiate(zombiePrefabs[r], randomPoint, Quaternion.identity);

            }
            else
                i--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!spawnOnStart && other.gameObject.tag == "Player")
        {
            CreateAllZombies();
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyUp(KeyCode.R))
        {
            Instantiate(ragDollPrefab, this.transform.position, Quaternion.identity);

            return;
        }*/
    }
}