using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMovementElement : MonoBehaviour
{
    [SerializeField]
    public GameObject[] levelElements;

    bool inPlace = false;


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
