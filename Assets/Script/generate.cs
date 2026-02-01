using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour {

public GameObject Instantiate_Position;

public GameObject Box;

void Start () {

Instantiate(Box, Instantiate_Position.transform.position,Instantiate_Position.transform.rotation);

}

}
