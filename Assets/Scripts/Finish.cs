using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            GetComponent<PlayerMovement>().isMove = false;
            GetComponent<Rigidbody>().velocity = (Vector3.zero);
            other.gameObject.SetActive(false);
            GameObject.Find("Confetti").GetComponent<ParticleSystem>().Play();
        }
    }
}
