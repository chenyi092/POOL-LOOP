using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Database;



public class final : MonoBehaviour
{   

    public TMP_FontAsset font;
    public Color textColor = Color.red;
    public TextMeshPro textMeshPro;
    public GameObject Instantiate_Position;
    public GameObject Box;
    public PhysicMaterial physicMaterial;
    string userId;
    DatabaseReference reference;
    string textnumber = "";
    bool flag ;
    string filepath;
    string text;
    int tempLen;

    
    void Start()
    {
        //firebase setting
        userId = SystemInfo.deviceUniqueIdentifier; 
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {   
        IsPressed();
        if(flag == true){
            ReadDatabase();
            if(textnumber != ""){ 
            UpdateDatabase();
            readtext(textnumber);
            GenerateCube();
            }
        }

        
        

    }

    //read database of text number
    public void ReadDatabase()
    {
         reference.Child("users")
                .Child(userId)
                .Child("textnumber")
                .GetValueAsync().ContinueWith(task =>{
                    DataSnapshot snapshot = task.Result;
                    textnumber = snapshot.Value.ToString();
                });
        
    }

    public void IsPressed(){
         reference.Child("users")
                .Child(userId)
                .Child("press")
                .GetValueAsync().ContinueWith(task =>{
                    DataSnapshot snapshot = task.Result;
                    flag = (bool)snapshot.Value;
                });
    }

    public void UpdateDatabase(){
        reference.Child("users").Child(userId).Child("press").SetValueAsync(false);
    }

    //read text and calculate length
    public void readtext(string textnumber){
        if(textnumber == "1"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\1.txt";
        }
        else if(textnumber == "2"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\2.txt";
        }
        else if(textnumber == "3"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\3.txt";
        }
        else if(textnumber == "4"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\4.txt";
        }
        else if(textnumber == "5"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\5.txt";
        }
        else if(textnumber == "6"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\6.txt";
        }
        else if(textnumber == "7"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\7.txt";
        }
        else if(textnumber == "8"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\8.txt";
        }
        else if(textnumber == "9"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\9.txt";
        }
        else if(textnumber == "10"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\10.txt";
        }



         //讀檔
            StreamReader str = new StreamReader(filepath);
            text = str.ReadToEnd();
            // Debug.Log(text);
            str.Close();
        
        // 計算字串長度的靜態方法
            
            tempLen = text.Length;

            Debug.Log(filepath);
            Debug.Log(tempLen);
    }

    private Vector3 GetFacePosition(int faceIndex)
    {
        // 根據面的索引返回中心點的位置
            switch (faceIndex)
            {
                case 0: // Front
                    return transform.TransformPoint(Vector3.forward * transform.localScale.z / 2);
                case 1: // Back
                    return transform.TransformPoint(Vector3.back * transform.localScale.z / 2);
                case 2: // Left
                    return transform.TransformPoint(Vector3.left * transform.localScale.x / 2);
                case 3: // Right
                    return transform.TransformPoint(Vector3.right * transform.localScale.x / 2);
                case 4: // Up
                    return transform.TransformPoint(Vector3.down * transform.localScale.y / 2);
                case 5: // Down
                    return transform.TransformPoint(Vector3.up * transform.localScale.y / 2);
                default:
                    return Vector3.zero;
            }
    }

    private Vector3 GetFaceNormal(int faceIndex)
    {
        // 根據面的索引返回法線
            switch (faceIndex)
            {
                case 0: // Front
                    return transform.forward;
                case 1: // Back
                    return -transform.forward;
                case 2: // Left
                    return -transform.right;
                case 3: // Right
                    return transform.right;
                case 4: // Up
                    return transform.up;
                case 5: // Down
                    return -transform.up;
                default:
                    return Vector3.zero;
            }
     }

    void GenerateCube(){

            for(int t = 0; t < tempLen/5; t++)
            {
                //製造方塊
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                cube.transform.position = new Vector3(0, 30, 0);
                //sound.playSound();
                Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                Collider collider = cube.GetComponent<Collider>();
                cube.AddComponent<first_cube>();

                if (physicMaterial != null)
                {
                    // 添加物理材質到物體的碰撞器上
                        
                        if (collider != null)
                        {
                            collider.material = physicMaterial;
                        }
                        else
                        {
                            Debug.LogWarning("物體上找不到碰撞器 (Collider)，無法添加物理材質。");
                        }
                }
                else
                {
                    Debug.LogWarning("未指定物理材質。");
                }



                try
                {
                    // 遍歷 Cube 的六個面
                        for (int i = 0; i < 6; i++)
                        {
                            // 創建子物件
                                // GameObject textObject = new GameObject("TextMeshPro_" + i);
                                // textObject.transform.parent = transform; // 將子物件設為 Cube 的子物件
                                GameObject textObject = new GameObject("TextMeshPro_" + i);
                                textObject.transform.parent = cube.transform;

                            // 添加 TextMeshPro 組件
                                textMeshPro = textObject.AddComponent<TextMeshPro>();

                            // 設置文本內容
                                string textstring = new string(text[t].ToString());
                                textMeshPro.text = textstring;

                                textMeshPro.alignment = TextAlignmentOptions.Center;
                                textMeshPro.fontSize = transform.localScale.x * 25f ; // 根據字串長度調整字型大小

                            // 獲取面的位置和法線
                                Vector3 facePosition = GetFacePosition(i);
                                Vector3 faceNormal = GetFaceNormal(i);

                            // 設置文本位置
                                textObject.transform.position = facePosition;
                                textMeshPro.rectTransform.localPosition = faceNormal * -0.51f; // 將文本稍微推離面，確保不會被遮擋

                            // 設置文本朝向
                                textObject.transform.forward = faceNormal;

                            // 設置顏色
                                textMeshPro.color = textColor;

                            // 設置字型
                                textMeshPro.font = font;
                            }   
                }

                catch (Exception e)
                {
                    Debug.LogError("讀檔發生錯誤：" + e.Message);
                }
            }
    }

    

}
