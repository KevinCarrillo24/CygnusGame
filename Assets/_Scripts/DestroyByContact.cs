using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public static DestroyByContact instace;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int life;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        instace = this;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("No se pudo encontrar 'GameController' script");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (other.tag == "Player")
        {
            PlayerController.instace.health -= 1;
        } 

        if (explosion != null)
        {
            Instantiate (explosion, transform.position, transform.rotation);
        }

        if(other.tag == "Player" && PlayerController.instace.health == 0)
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
        life--;
        if (life == 0)
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }        
    }
}
