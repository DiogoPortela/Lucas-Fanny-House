using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public GameObject light;
    private bool isOn = true;

    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            light.SetActive(isOn);
        }
	}
}
