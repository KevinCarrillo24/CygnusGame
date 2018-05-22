using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUps : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Bolt")
        {
            return;
        }
        PlayerController.instace.health += 1;
        GameObject.Find("Circle01").SetActive(false);
        GameObject.Find("Particles01").SetActive(false);
        GameObject.Find("ElectricBeam01").SetActive(false);
        Destroy(gameObject);
    }
}
