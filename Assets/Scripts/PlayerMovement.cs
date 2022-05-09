using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        
    }
   
}

