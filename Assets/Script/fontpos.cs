using UnityEngine;
using TMPro;

public class fontpos : MonoBehaviour
{
    public string labelText = "Your Text Here"; // 输入的文字
    public TMP_FontAsset font;
    public Color textColor = Color.red;
    public TextMeshPro textMeshPro;
    private void Start()
    {
        // 遍历Cube的六个面
        for (int i = 0; i < 6; i++)
        {
            // 创建子对象
            GameObject textObject = new GameObject("TextMeshPro_" + i);
            textObject.transform.parent = transform; // 将子对象设为Cube的子对象

            // 添加TextMeshPro组件
            textMeshPro = textObject.AddComponent<TextMeshPro>();
            
            // 设置文本内容
            textMeshPro.text = labelText;
            textMeshPro.alignment = TextAlignmentOptions.Center;
            textMeshPro.fontSize = transform.localScale.x *8f;
            

            // 获取面的位置和法线
            Vector3 facePosition = GetFacePosition(i);
            Vector3 faceNormal = GetFaceNormal(i);

            // 设置文本位置
            textObject.transform.position = facePosition;
            textMeshPro.rectTransform.localPosition = faceNormal * -0.51f; // 将文本稍微推离面，确保不会被遮挡

            // 设置文本朝向
            textObject.transform.forward = faceNormal;

            //color
            textMeshPro.color = textColor;

            //font
            textMeshPro.font = font;
        } 
    }

    // 获取Cube的六个面中心点的位置
    private Vector3 GetFacePosition(int faceIndex)
    {
        // 根据面的索引返回中心点的位置
        switch (faceIndex)
        {
            case 0: // Front
            Debug.Log("face index");
                return transform.TransformPoint(Vector3.forward * transform.localScale.z/2);
            case 1: // Back
                return transform.TransformPoint(Vector3.back * transform.localScale.z/2 );
            case 2: // Left
                return transform.TransformPoint(Vector3.left * transform.localScale.x/2 );
            case 3: // Right
                return transform.TransformPoint(Vector3.right * transform.localScale.x/2 );
            case 4: // Up
                return transform.TransformPoint(Vector3.down * transform.localScale.y/2 );
            case 5: // Down
                return transform.TransformPoint(Vector3.up* transform.localScale.y/2 );
            default:
                return Vector3.zero;
        }
    }

    // 获取Cube的六个面的法线
    private Vector3 GetFaceNormal(int faceIndex)
    {
        // 根据面的索引返回法线
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
