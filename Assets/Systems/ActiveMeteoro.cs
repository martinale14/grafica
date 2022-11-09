using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMeteoro : MonoBehaviour
{
    public bool MeteoroActived = false ;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MeteoroActived = true;
        }
    }
}
