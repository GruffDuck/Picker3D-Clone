using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    public TextMeshProUGUI congratsText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            GetComponent<PlayerMovement>().isMove = false;
            GetComponent<Rigidbody>().velocity = (Vector3.zero);
            other.gameObject.SetActive(false);
            GameObject.Find("Confetti").GetComponent<ParticleSystem>().Play();
            StartCoroutine(Congrats());
            

        }
    }
    IEnumerator Congrats()
    {
        congratsText.gameObject.SetActive(true);
        congratsText.transform.DOScale(1, 0.3f);
        congratsText.text = FindObjectOfType<Texts>().FinishTexts[0];
        yield return new WaitForSeconds(1);
        congratsText.transform.DOScale(0.1f, 0.3f);
        congratsText.text = "";
        congratsText.gameObject.SetActive(false);
        FindObjectOfType<UIManageer>().GameWin();
       
    }
}
