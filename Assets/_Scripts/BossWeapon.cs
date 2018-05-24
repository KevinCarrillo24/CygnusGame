using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    private AudioSource audiosource;

    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawnTwo;
    public Transform shotSpawnThree;
    public Transform shotSpawnFour;
    public float fireRate;
    public float delay;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        Instantiate(shot, shotSpawnTwo.position, shotSpawnTwo.rotation);
        //audiosource.Play();
        if(DestroyBoss.instace.life <=100)
        {
            Instantiate(shot, shotSpawnThree.position, shotSpawnThree.rotation);
            Instantiate(shot, shotSpawnFour.position, shotSpawnFour.rotation);
        }

    }
}
