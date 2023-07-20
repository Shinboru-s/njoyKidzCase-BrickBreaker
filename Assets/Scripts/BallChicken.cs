using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChicken : MonoBehaviour, IPower
{
    [SerializeField] private Transform chickSpawnPointParent;
    [SerializeField] private GameObject chickPrefab;
    [SerializeField] private float chickBallForce;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UsePower();
        }
    }

    public void UsePower()
    {
        for (int i = 0; i < chickSpawnPointParent.childCount; i++)
        {
            GameObject chick = Instantiate(chickPrefab, chickSpawnPointParent.GetChild(i).position, Quaternion.identity);
            chick.GetComponent<Rigidbody2D>().AddForce(chickSpawnPointParent.GetChild(i).up * chickBallForce, ForceMode2D.Impulse);
        }
        
    }

    


}
