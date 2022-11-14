using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHud2 : MonoBehaviour
{
    public Image imageUI;
    private GameObject graphImage;

    private void Start()
    {
        graphImage = GameObject.FindGameObjectWithTag("rockGraphImg");
        imageUI = GameObject.Find("PiedrasImg").GetComponent<Image>();
        imageUI.color = new Color(255, 255, 255, 1);
        graphImage.SetActive(false);
        

    }
    public void mostrarGraficaA()
    {
        Debug.Log("A");
        graphImage.SetActive(true);
        imageUI = GameObject.Find("PiedrasImg").GetComponent<Image>();
        imageUI.sprite = Resources.Load<Sprite>("hud/icons/piedraA");
    }
    public void mostrarGraficaB()
    {
        Debug.Log("B");
        graphImage.SetActive(true);
        imageUI = GameObject.Find("PiedrasImg").GetComponent<Image>();
        imageUI.sprite = Resources.Load<Sprite>("hud/icons/piedraB");
    }
    public void mostrarGraficaC()
    {
        Debug.Log("C");
        graphImage.SetActive(true);
        imageUI = GameObject.Find("PiedrasImg").GetComponent<Image>();
        imageUI.sprite = Resources.Load<Sprite>("hud/icons/piedraC");
    }

    public void salirDeLaImagen()
    {
        graphImage.SetActive(false);
    }
}
