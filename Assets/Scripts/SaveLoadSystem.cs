using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SaveLoadSystem : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject player;
    int i;
    public bool isSave = false;
    private void Awake()
    {
        if (isSave == true)
        {
            PlayerPrefs.DeleteAll();
        }

        i = PlayerPrefs.GetInt("i");
        levels[i].SetActive(true);
    }
    public void GetLevel()
    {
        if (PlayerPrefs.GetInt("Level") >= levels.Length && i >= levels.Length)
        {
            PlayerPrefs.SetInt("Level", levels.Length - 1);
            i = levels.Length - 1;
            PlayerPrefs.SetInt("i", i);
        }
        else
        {
            if (PlayerPrefs.GetInt("Level") == i)
            {
                StartCoroutine(SetPlayerPos());

                // FindObjectOfType<UIManageer>().TapToStartPanel();
            }
        }
    }
    IEnumerator SetPlayerPos()
    {
        levels[i].SetActive(false);
        player.transform.DOMoveZ(-25f, 3f);

        yield return new WaitForSeconds(3.21f);
        PlayerPrefs.SetInt("Level", i + 1);

        levels[i + 1].SetActive(true);
        FindObjectOfType<PlayerMovement>().isMove = true;
        i++;
        PlayerPrefs.SetInt("i", i);
    }
}
