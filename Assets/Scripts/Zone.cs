using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Zone : MonoBehaviour
{
    public GameObject pusher;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupzone"))
        {
            GetComponent<PlayerMovement>().isMove = false;
            GetComponent<Rigidbody>().velocity = (Vector3.zero);
            other.gameObject.SetActive(false);
        }
    }
}
