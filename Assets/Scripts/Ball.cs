using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballForce;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private bool canColide = true;
    [HideInInspector] public bool canBounce = true;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        BallAddForce();

    }

    private void Update()
    {
        Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude == 0)
            BallAddForce();
    }
    private void LateUpdate()
    {
        lastVelocity = rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canColide == false)
            return;
        canColide = false;
        
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.GetComponent<Block>().BounceEvent();
        }


        if (canBounce == false)
            return;

        if (collision.gameObject.tag == "Bar")
        {
            Vector2 barBounceDirection = BarBounce(collision);
            Vector2 bounceDirection = BounceDirection(collision);
            Vector2 finalDirection = bounceDirection + barBounceDirection;
            ApplyBounceVelocity(finalDirection);

        }
        else
        {
            Vector2 bounceDirection = BounceDirection(collision);
            ApplyBounceVelocity(bounceDirection);
        }


        canColide = true;

    }

    // reflection func
    Vector3 ReflectedBounce(Collision2D collision)
    {
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        return direction;
    }
    //set velocity func

    //bar func
    Vector2 BarBounce(Collision2D collision)
    {
        Vector2 barObjectCenter = collision.gameObject.transform.position;
        Vector2 contactPoint = collision.contacts[0].point;
        Vector2 direction = contactPoint - barObjectCenter;
        direction *= new Vector2(0.5f, 1);

        return direction;
    }

    Vector2 BounceDirection(Collision2D collision)
    {
        Vector3 direction = ReflectedBounce(collision);
        return direction;
    }
    void ApplyBounceVelocity(Vector3 direction)
    {
        float currentSpeed = lastVelocity.magnitude;
        rb.velocity = direction * Mathf.Max(currentSpeed, 0f);
        rb.velocity = rb.velocity.normalized * ballForce;
    }


    void BallAddForce()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(gameObject.transform.up * ballForce, ForceMode2D.Impulse);
    }
}
