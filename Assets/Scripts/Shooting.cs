using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject target;
    public GameObject bulletPrefab;
    public float shootingForce;
    public GameObject parent;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, target.transform.position, target.transform.rotation, parent.transform);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(target.transform.up * shootingForce, ForceMode.Impulse);
        }
	}

}
