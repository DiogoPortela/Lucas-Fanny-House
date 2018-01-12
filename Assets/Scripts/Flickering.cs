using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {

    public float flicker = 0.5f;
    public Light light;

	// Update is called once per frame
	void Update () {
        float newRandom = Random.value;

        if(newRandom > flicker)
        {
            light.enabled = !light.enabled;
        }
    }
}
