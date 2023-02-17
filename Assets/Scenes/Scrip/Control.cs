using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastVelocity;
    public float speedRun =1.5f;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(UnityEngine.Random.Range(-10,10)* 15f, 10f * 15f));
    }
    void Update()
    {
        lastVelocity= rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            var speed = speedRun;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0.2f);
            //Debug.Log("BOUNCE !!!!!!");
        }

    }
}
