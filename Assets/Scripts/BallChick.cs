using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChick : MonoBehaviour
{
    
    void Awake()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.GetComponent<Block>().BounceEvent();
        }
        
        Destroy(gameObject);
    }
}
