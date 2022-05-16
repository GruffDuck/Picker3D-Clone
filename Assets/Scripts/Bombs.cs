using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public GameObject[] sphereBomb;
    private void Start()
    {
        Explosion();
    }
    public void Explosion()
    {
        StartCoroutine(BombEx());

    }
    IEnumerator BombEx()
    {
        for (int i = 0; i < sphereBomb.Length; i++)
        {
            yield return new WaitForSeconds(3f);
            sphereBomb[i].transform.GetChild(0).GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
