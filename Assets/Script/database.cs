using Firebase;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class database : MonoBehaviour
{
    string userId;
    DatabaseReference reference;
    string txtnumber;
    bool flag = false;
    string msg = "";

    void Start()
    {
        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        

        InvokeRepeating("UpdateValue", 0f, 2f);
    }

    void UpdateValue(){
        
        ReadDatabase();
        Debug.Log(msg);

    }


    public void ReadDatabase()
    {   
        reference.Child("users")
                .Child(userId)
                .Child("textnumber")
                .GetValueAsync().ContinueWith(task =>{
                    DataSnapshot snapshot = task.Result;
                    msg = snapshot.Value.ToString();
                });
    }



}
