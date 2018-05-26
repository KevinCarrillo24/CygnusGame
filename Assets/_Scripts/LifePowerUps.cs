using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUps : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
    
        PlayerController.instace.health += 1;
        Destroy(gameObject);
    }
}
