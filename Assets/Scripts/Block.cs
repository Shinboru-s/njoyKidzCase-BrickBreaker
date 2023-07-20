using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int remainingBounce;
    [SerializeField] private Sprite breakingSprite;
    [SerializeField] private SpriteRenderer sr;

    void Awake() 
    {
        GameObject.FindObjectOfType<GameManager>().AddBlockToList(gameObject);
    }

    public void BounceEvent()
    {
        if (remainingBounce <= 0)
        {
            DestroyBlock();
            return;
        }
        sr.sprite = breakingSprite;
        remainingBounce--;
    }

    void DestroyBlock()
    {
        GameObject.FindObjectOfType<PowerController>().RollTheDice(transform);
        GameObject.FindObjectOfType<GameManager>().RemoveBlockFromList(gameObject);
        Destroy(gameObject);
    }
}
