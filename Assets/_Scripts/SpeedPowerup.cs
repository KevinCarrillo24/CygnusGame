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

    }

    public IEnumerator Pickup(Collider Player)
    {
        PlayerController.instace.speed = 25;

        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        PlayerController.instace.speed = 10;
        Destroy(gameObject);
    }
}
