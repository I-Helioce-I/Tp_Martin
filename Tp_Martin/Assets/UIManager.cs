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
    }

    public void SetTutoText(string textToDisplay)
    {
        
        tutoText.text = textToDisplay;
        tutoText.gameObject.SetActive(true);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(5f);
        tutoText.gameObject.SetActive(false);

    }

}
