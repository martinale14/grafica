using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TownTriguerSystem : MonoBehaviour
{

    public GameObject Activate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Activate.SetActive(true);
            GameObject.Find("RawImageTown").GetComponent<RawImage>().enabled = true;
            GameObject.Find("RawImageTown").GetComponent<VideoPlayer>().Play();
          
        }
    }
}
