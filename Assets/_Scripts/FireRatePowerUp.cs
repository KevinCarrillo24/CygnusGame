using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float duration;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other));
        }

    }

    public IEnumerator Pickup(Collider Player)
    {
        PlayerController.instace.fireRate = 0.10f;
        
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        PlayerController.instace.fireRate = 0.25f;
        Destroy(gameObject);
    }
}
	

