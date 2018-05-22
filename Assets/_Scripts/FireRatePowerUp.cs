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
        if (other.tag =="Enemy")
        {
            return;
        }

    }

    public IEnumerator Pickup(Collider Player)
    {
        PlayerController.instace.fireRate = 0.10f;
        
        GetComponent<Collider>().enabled = false;
        GameObject.Find("Circle01").SetActive(false);
        GameObject.Find("Particles01").SetActive(false);
        GameObject.Find("ElectricBeam01").SetActive(false);

        yield return new WaitForSeconds(duration);

        PlayerController.instace.fireRate = 0.25f;
        Destroy(gameObject);
    }
}
	

