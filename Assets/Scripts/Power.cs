using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] private float speed;

    void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed, ForceMode2D.Impulse);
  
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("onTrigger: "+ other.tag);
        if (other.CompareTag("Bar"))
        {
            GameObject.FindObjectOfType<Ball>().gameObject.GetComponent<IPower>().UsePower();
            Destroy(gameObject);
        }


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("onCollision: "+ other.gameObject.tag);
        if (other.gameObject.CompareTag("Bar"))
        {
            GameObject.FindObjectOfType<Ball>().gameObject.GetComponent<IPower>().UsePower();
            Destroy(gameObject);
        }
    }
}