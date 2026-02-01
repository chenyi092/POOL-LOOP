using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System.Threading;

public class doortriggerright : MonoBehaviour
{   string userId;
    DatabaseReference reference;
    public GameObject door;
    public float openRot, closeRot, speed;
    public bool isOpen = false;
    bool flag = false;
    Vector3 currentRot;
    
    
    // Start is called before the first frame update
    void Start()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadDatabase();
        Vector3 currentRot = door.transform.localEulerAngles;
        if(isOpen){

            if(currentRot.z < openRot){
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, currentRot.y, openRot), speed * Time.deltaTime);
            }
        }
        else{
            if(currentRot.z > closeRot){
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, currentRot.y, closeRot), speed * Time.deltaTime);
            }
        }
        
    }



    public void ReadDatabase()
    {
         reference.Child("users")
                .Child(userId)
                .Child("door")
                .GetValueAsync().ContinueWith(task =>{
                    DataSnapshot snapshot = task.Result;
                    isOpen = (bool)snapshot.Value;
                    
                });
    }


}
