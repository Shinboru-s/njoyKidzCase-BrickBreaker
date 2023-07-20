using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBarrier : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball"))
        {
            GameObject.FindObjectOfType<GameManager>().LevelComplete();
        }
    }
}
