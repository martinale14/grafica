using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeteoro : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
       //    Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Meteoro"))
        {
            Destroy(other.gameObject,10);
        }
    }
}
   