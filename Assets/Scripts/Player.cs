using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject gun;
    public int MaskWin = 1;

    private int HP = 3;
    private static int MaskCount = 0;

    private void Update()
    {
        if (MaskCount == MaskWin && MonsterSpawn.enemies.Count == 0)
        {
            ScoreManager.Win();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            HP--;
            if (HP == 0)
            {
                ScoreManager.Loss();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gun")
        {
            Destroy(other.gameObject);
            gun.SetActive(true);
        }
        else if(other.gameObject.tag == "Mask")
        {
            MaskCount++;
            Destroy(other.gameObject);
            MonsterSpawn.Spawn(3);

        }
    }
}
