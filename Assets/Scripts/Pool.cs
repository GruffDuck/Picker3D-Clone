using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Pool : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI congratsText;
    private int counter;
    public int count;
    public GameObject elevator;
    string congratsTexts;

    private void Awake()
    {
        text.text = counter.ToString() + "/" + count.ToString();
    }
    private void Start()
    {
        congratsTexts= FindObjectOfType<Texts>().congratsTexts[Random.Range(0, FindObjectOfType<Texts>().congratsTexts.Length)];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (counter < count)
        {
            counter++;
        }

        text.text = counter.ToString() + "/" + count.ToString();
        Destroy(collision.gameObject, 0.2f);
        StartCoroutine(Go());
    }
    private IEnumerator Go()
    {
        yield return new WaitForSeconds(1);
        if (counter >= count)
        {
            elevator.transform.DOMoveY(0, 0.7f);
            yield return new WaitForSeconds(1);
            FindObjectOfType<PlayerMovement>().isMove = true;
            StartCoroutine(Congrats());
        }
    }
    IEnumerator Congrats()
    {
        congratsText.gameObject.SetActive(true);
        congratsText.transform.DOScale(1, 0.3f);
        congratsText.text = congratsTexts;
        yield return new WaitForSeconds(1);
        congratsText.transform.DOScale(0.1f, 0.3f);
        congratsText.text = "";
        congratsText.gameObject.SetActive(false);
        Start();
    }
}
