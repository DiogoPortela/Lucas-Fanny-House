using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(Mathf.Abs((player.transform.position - this.transform.position).magnitude) > 50)
        {
            Destroy(this.gameObject);
            Shooting.RemoveFromList(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Shooting.RemoveFromList(this.gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            MonsterSpawn.RemoveFromList(collision.gameObject);
        }
    }
}
