using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class CinematicSystemSimple : MonoBehaviour
{
    private VideoPlayer player;
    private GameObject next;
    public string nextRawImage = "";
    public AudioSource audioS;

    
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        next = GameObject.Find(nextRawImage);
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        Cinem();
    }

    void Cinem()
    {
        if (player.time >= Math.Floor(player.length))
        {
            player.Stop();
            
            GetComponent<RawImage>().enabled = false;
            if (next != null)
            {
                audioS.Stop();
                next.GetComponent<VideoPlayer>().Play();
            }
        }
       
    }

}
