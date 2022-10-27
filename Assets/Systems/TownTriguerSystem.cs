using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TownTriguerSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("RawImageTown").GetComponent<RawImage>().enabled = true;
            GameObject.Find("RawImageTown").GetComponent<VideoPlayer>().Play();
        }
    }
}
