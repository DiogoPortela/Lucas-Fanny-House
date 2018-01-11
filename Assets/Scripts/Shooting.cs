using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject target;
    public GameObject bulletPrefab;
    public float shootingForce;
    public GameObject parent;

    private static List<GameObject> bullets;

    private void Start()
    {
        bullets = new List<GameObject>();
    }

    public static void RemoveFromList(GameObject obj)
    {
        if (bullets.Contains(obj))
        {
            bullets.Remove(obj);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, target.transform.position, target.transform.rotation, parent.transform);
            bullets.Add(newBullet);
        }

        foreach (GameObject obj in bullets)
        {
            obj.transform.position += obj.transform.up * shootingForce;
        }

    }

}
