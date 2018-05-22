using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour {
    private IEnumerator coroutine;
    public float duration;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other));
        }
        if (other.tag == "Enemy")
        {
            return;
        }


    }

    public IEnumerator Pickup(Collider Player)
    {
        PlayerController.instace.speed = 25;
        GetComponent<Collider>().enabled = false;
        GameObject.Find("Circle02").SetActive(false);
        GameObject.Find("Particles02").SetActive(false);
        GameObject.Find("ElectricBeam02").SetActive(false);

        yield return new WaitForSeconds(duration);

        PlayerController.instace.speed = 10;
        Destroy(gameObject);
    }
}
