using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;

    public void TakeDammages(float damages)
    {
        Health -= damages;
        if(Health <=  0)
        {
            Debug.Log("dood");
        }
        print("au");
    } 
}
