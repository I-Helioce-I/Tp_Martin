using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField]
    Vector3[] cameraPos;
    [SerializeField]
    GameObject camHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.TryGetComponent(out PlayerController playerController))
        {
            camHolder.transform.position = new Vector3(-5.33f, 0, 35.02f);
            int i = 0;

            foreach (GameObject camera in playerController.cams)
            {
                camera.transform.position = cameraPos[i];

                Debug.Log(camera + cameraPos[i].ToString());

                i++;
            }
        }

        Destroy(gameObject);
    }

    public void SetCam()
    {

    }
}
