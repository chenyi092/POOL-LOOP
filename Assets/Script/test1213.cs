using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Firebase;
using Firebase.Database;


public class test1213 : MonoBehaviour
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
    bool flag_textnumber = true;
    string filepath;
    string text;
    int tempLen;

    void Start()
    {
        //firebase setting
        userId = SystemInfo.deviceUniqueIdentifier;
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        if(flag_textnumber == true){
            //read data from firebase
            InvokeRepeating("IsUpdateValue", 0f, 2f);
        }
            
        


            for(int t = 0; t < tempLen/5; t++)
            {
                //製造方塊
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(2f, 2f, 2f);
                cube.transform.position = new Vector3(0, 30,-10);
                Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
                Collider collider = cube.GetComponent<Collider>();
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
                                textMeshPro.fontSize = transform.localScale.x * 30f ; // 根據字串長度調整字型大小

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

    //read firebase data
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

    void IsUpdateValue(){

        if(textnumber != ""){
                CancelInvoke("IsUpdateValue");
                readtext(textnumber);
                Debug.Log(textnumber);
            }
        
        else{ReadDatabase();}
        
    }

    public void readtext(string textnumber){
        if(textnumber == "1"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\1.txt";
        }
        else if(textnumber == "2"){
            filepath = @"C:\Users\cheny\OneDrive\桌面\2.txt";
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

    // 獲取 Cube 的六個面中心點的位置
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

    // 獲取 Cube 的六個面的法線
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
        
                
    
}
