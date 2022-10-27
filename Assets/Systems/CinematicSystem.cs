using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class CinematicSystem : MonoBehaviour
{
    private VideoPlayer player;
    private GameObject preLevel1;
    
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        preLevel1 = GameObject.Find("RawImageLevel1");
        player.Play();
    }

    void Update()
    {
        if (player.time >= Math.Floor(player.length))
        {
            player.Stop();
            GetComponent<RawImage>().enabled = false;
            preLevel1.GetComponent<VideoPlayer>().Play();
        }
    }
}
