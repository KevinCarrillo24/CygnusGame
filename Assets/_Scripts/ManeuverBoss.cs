using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeuverBoss : MonoBehaviour {

    public float dodge;
    public float smothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;
    private bool wachito;
    public Vector3 finalPosition;

    private float targetManeuver;
    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0;
        StartCoroutine(Evade());
        wachito = false;
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (DestroyBoss.instace.life > 10)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
    void FixedUpdate()
    {
        if (wachito)
        {
            float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smothing);
            rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
            rb.position = new Vector3
                (
                    Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                    0.0f,
                    Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );
            rb.rotation = Quaternion.Euler(0.0f, 180, rb.velocity.x * -tilt);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, Time.deltaTime * 3.0f);
            if(transform.position == finalPosition)
            {
                wachito = true;
            }
        }
    }
}
