using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBombs : MonoBehaviour
{
    public bool isGround = false;
    public GameObject obstacles;
    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
        gameObject.SetActive(false);
        obstacles.SetActive(true);
    }
}
   
   
