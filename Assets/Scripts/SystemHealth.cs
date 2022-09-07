using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace Leo
{
    public class SystemHealth : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("畫布傷害物件")]
        private GameObject goDamage;
        [SerializeField, Header("圖片血量")]
        private Image imgHp;
        [SerializeField, Header("怪物資料")]
        private DataEnemy dataEnemy;
       // [SerializeField, Header("敵人動畫控制器")]
       // private Animator aniEnemy;

        private float hp;
        private string parDamage = "觸發受傷";
        #endregion

        private void Awake()
        {
            hp = dataEnemy.hp;
        }

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
           // aniEnemy.SetTrigger(parDamage);
            Vector3 pos = transform.position + Vector3.up;

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            print("死亡");
        }
    }

}
