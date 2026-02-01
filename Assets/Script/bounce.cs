using UnityEngine;

public class bounce : MonoBehaviour
{
    public PhysicMaterial physicMaterial; // 在Inspector視窗中指定物理材質

    void Start()
    {
        // 檢查是否指定了物理材質
        if (physicMaterial != null)
        {
            // 添加物理材質到物體的碰撞器上
            Collider collider = GetComponent<Collider>();
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
    }
}
