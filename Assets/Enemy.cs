using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    public Transform Character;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;




    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Character);

        if (Vector3.Distance(transform.position, Character.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Character.position) <= MaxDist)
            {
                // add something when u add more code to the player code
            }

        }
    }
}