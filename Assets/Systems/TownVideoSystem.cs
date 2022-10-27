using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TownVideoSystem : MonoBehaviour
{
    private VideoPlayer player;
    private GameObject next;
    public string nextRawImage = "";


    void Start()
    {
        player = GetComponent<VideoPlayer>();
        next = GameObject.Find(nextRawImage);
    }
    void Update()
    {
        if (player.time >= Math.Floor(player.length))
        {
            player.Stop();
            GetComponent<RawImage>().enabled = false;
            if (next != null)
            {
                next.GetComponent<VideoPlayer>().Play();
            }
        }
    }
}
