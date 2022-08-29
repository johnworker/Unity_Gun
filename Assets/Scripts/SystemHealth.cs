using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SystemHealth : MonoBehaviour
{
    #region 資料
    [SerializeField, Header("畫布傷害物件")]
    private GameObject goDamage;
    [SerializeField, Header("圖片血量")]
    private Image imgHp;
    [SerializeField, Header("文字血量")]
    private TextMeshProUGUI textHp;
    [SerializeField, Header("敵人動畫控制器")]
    private Animator aniEnemy;

    private float hp;
    private string parDamage = "觸發受傷";
    #endregion

    // 碰撞事件
    // 1. 兩個物件必須有一個帶有 Rigidbody
    // 2. 兩個物件必須有碰撞器 Collider
    // 3. 是否有勾選 Is Trigger
    // 3-1 兩者都沒有勾選 Is Trigger 使用 OnCollision
    private void OnCollisionEnter(Collision collision)
    {
        GetDamage();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    private void GetDamage()
    {
        float getDamage = 50;
        hp -= getDamage;
        textHp.text = hp.ToString();
        aniEnemy.SetTrigger(parDamage);
        Vector3 pos = transform.position + Vector3.up;

    }

    /// <summary>
    /// 死亡
    /// </summary>
}
