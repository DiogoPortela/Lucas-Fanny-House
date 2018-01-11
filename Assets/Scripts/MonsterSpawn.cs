using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawn : MonoBehaviour
{

    public GameObject spawner;
    private List<Transform> spawnPoints;

    public GameObject enemyPrefab;
    private static List<GameObject> enemies;

    public GameObject player;
    public GameObject parent;

    private void Start()
    {
        spawnPoints = new List<Transform>();
        enemies = new List<GameObject>();

        foreach (Transform t in spawner.GetComponentsInChildren<Transform>(false))
        {
            if(t != this.transform)
            {
                spawnPoints.Add(t);
            }
        }

        Spawn();
    }

    private void Spawn()
    {
        foreach(Transform t in spawnPoints)
        {
            enemies.Add(Instantiate(enemyPrefab, t.position, t.rotation, parent.transform));
        }
    }

    public static void RemoveFromList(GameObject obj)
    {
        if (enemies.Contains(obj))
            enemies.Remove(obj);
    }

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.SetDestination(player.transform.position);
        }
    }

}
