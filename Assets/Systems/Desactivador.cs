using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desactivador : MonoBehaviour
{
    public GameObject Desactivate1;
    public GameObject Desactivate2;
    public GameObject Desactivate3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Desactivate1.SetActive(false);
            Desactivate2.SetActive(false);
            Desactivate3.SetActive(false);

        }
    }
}
