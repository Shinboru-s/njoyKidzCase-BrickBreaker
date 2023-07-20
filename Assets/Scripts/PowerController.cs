using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{
    void Awake()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        
        if (ball.GetComponent<IPower>() == null)
            canUsePower = false;
        else
            canUsePower = true;
    }

    [Range(0, 100)][SerializeField] private int powerChance;
    [SerializeField] private GameObject powerPrefab;

    private bool canUsePower;
    public void RollTheDice(Transform blockTransform)
    {
        int randomInt = Random.Range(0, 100);
        if (randomInt > powerChance)
            return;

        Instantiate(powerPrefab, blockTransform.position, Quaternion.identity);
    }
}
