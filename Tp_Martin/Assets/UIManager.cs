using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    [SerializeField]
    TextMeshProUGUI tutoText;

    public void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void Start()
    {
        SetTutoText("Use ZQSD to move around", 7);
    }

    public void SetTutoText(string textToDisplay, float timer)
    {
        
        tutoText.text = textToDisplay;
        tutoText.gameObject.SetActive(true);
        StartCoroutine(ShowText(timer));
    }

    IEnumerator ShowText(float timer)
    {
        yield return new WaitForSeconds(timer);
        tutoText.gameObject.SetActive(false);

    }

}
