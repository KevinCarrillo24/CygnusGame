using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoss : MonoBehaviour {
    public GameObject explosion;
    public GameObject hit;
    public GameObject playerExplosion;
    public int life;
    public int scoreValue;
    private GameController gameController;
    public static DestroyBoss instace;

    private void Start()
    {
        instace = this;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp"))
        {
            return;
        }
        if (other.tag == "Player")
        {
            PlayerController.instace.health -= 1;
        }


        if (explosion != null)
        {
            Instantiate(hit, transform.position + new Vector3(-3, 1, -4), transform.rotation);
        }

        if (other.tag == "Player" && PlayerController.instace.health == 0)
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
        life--;
        if (life <= 0)
        {
            Instantiate(explosion, transform.position + new Vector3(-3, 1, -3), transform.rotation);
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
            gameController.GameOver();
        }
    }
}
