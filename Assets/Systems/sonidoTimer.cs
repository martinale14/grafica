using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidoTimer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Cube").SendMessage("sonidoReloj");
            Destroy(this.gameObject);
        }
    }
}
