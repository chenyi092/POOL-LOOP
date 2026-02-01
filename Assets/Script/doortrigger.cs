using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class doortriggerleft : MonoBehaviour
{   string userId;
    DatabaseReference reference;
    Transform tf;
    public bool isOpen = false;
    bool flag = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadDatabase();
        if(isOpen == flag){
            
        }
        else if(isOpen == true && flag == false){
            OpenDoorMethod();
            flag = true;
        }
        else if(isOpen == false && flag == true){
            CloseDoorMethod();
            flag = false;
        }
        
    }

    public void OpenDoorMethod(){

        tf.Rotate(0, 0, -50);
        Debug.Log("open");
        
    }

    public void CloseDoorMethod(){

        tf.Rotate(0, 0, 50);
        Debug.Log("close");
        
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
