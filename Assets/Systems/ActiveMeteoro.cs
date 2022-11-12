using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActiveMeteoro : MonoBehaviour
{
    public bool MeteoroActived = false ;
    public float timer = 0;
    private int time = 60; // Cuanto tiempo quiero que dure el timer

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MeteoroActived = true;
        }
    }

	private void Update()
	{
        if (MeteoroActived == true && timer > time * -1) {
            timer -= Time.deltaTime;

            Debug.Log(timer);
            GameObject.Find("timerBar").transform.localScale = new Vector3(4.2f,4.5f+(4.5f*(timer/time)));
        }
        if (timer < time * -1) { 
            /*
             
             Aqui va lo de GameOver cuando del tiempo se acabe
             
             */
        
        }
	}
}
