using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public int maxBatteryInGame;

    [SerializeField]
    GameObject[] levelElements;

    bool inPlace = false;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        StartCoroutine(Initialise());

    }


    private IEnumerator Initialise()
    {

        yield return new WaitForSeconds(1f);

        foreach (GameObject element in levelElements)
        {

            element.GetComponent<MoveLevelElement>().SetInPlaceBool();


            yield return new WaitForSeconds(0.25f);
        }

        inPlace = true;

    }
}
