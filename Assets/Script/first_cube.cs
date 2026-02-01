using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first_cube : MonoBehaviour
{

    void Start()
    {
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "first_cube")
        {
           
            Vector3 pos= gameObject.transform.position;
            
            sound.Instance.playSound(pos);
        }
    }

    
}
