using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject goblinEnemy;

 void Start()
{

    Instantiate(goblinEnemy, new Vector3(15,0,20), Quaternion.identity);
    Instantiate(goblinEnemy, new Vector3(10,0,24), Quaternion.identity);
    Instantiate(goblinEnemy, new Vector3(22,0,24), Quaternion.identity);
    Instantiate(goblinEnemy, new Vector3(33,0,21), Quaternion.identity);
    Instantiate(goblinEnemy, new Vector3(20,0,15), Quaternion.identity);
}

}
