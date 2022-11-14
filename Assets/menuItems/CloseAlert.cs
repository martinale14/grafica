using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAlert : MonoBehaviour
{
    // Start is called before the first frame update
    public void Close()
    {
        GameObject.Find("Alert").SetActive(false);
    }

    public void Open()
    {
        GameObject.Find("Alert").SetActive(false);
    }
}
