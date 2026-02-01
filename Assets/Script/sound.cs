using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class sound : MonoBehaviour
{
    public static sound Instance;
    private void Awake(){
        Instance = this;
    }


    public AudioClip se;
    void Start(){
    }

   
    public void playSound(Vector3 pos){
        AudioSource.PlayClipAtPoint(se, pos);
    }

    

  
}