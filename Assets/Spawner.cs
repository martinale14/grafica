using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int counter = 0;
    public GameObject meteoro;
    public ActiveMeteoro varAM;

    private void Start()
    {
        varAM = FindObjectOfType<ActiveMeteoro>();
        //Debug.Log(varAM.MeteoroActived);
    }
    void Update()
    {
        counter++;
        Debug.Log(varAM.MeteoroActived);
        if (counter >= 30 && varAM.MeteoroActived == true)
        {

            Vector3 ramdomSpawnPosition = new Vector3(Random.Range(-40,-20),5, Random.Range(-7, -23));
            Instantiate(meteoro, ramdomSpawnPosition, Quaternion.identity);
            counter = 0;
        }

    }
}
