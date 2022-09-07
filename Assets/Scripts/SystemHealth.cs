using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace Leo
{
    public class SystemHealth : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�e���ˮ`����")]
        private GameObject goDamage;
        [SerializeField, Header("�Ϥ���q")]
        private Image imgHp;
        [SerializeField, Header("�Ǫ����")]
        private DataEnemy dataEnemy;
       // [SerializeField, Header("�ĤH�ʵe���")]
       // private Animator aniEnemy;

        private float hp;
        private string parDamage = "Ĳ�o����";
        #endregion

        private void Awake()
        {
            hp = dataEnemy.hp;
        }

        // �I���ƥ�
        // 1. ��Ӫ��󥲶����@�ӱa�� Rigidbody
        // 2. ��Ӫ��󥲶����I���� Collider
        // 3. �O�_���Ŀ� Is Trigger
        // 3-1 ��̳��S���Ŀ� Is Trigger �ϥ� OnCollision
        private void OnCollisionEnter(Collision collision)
        {
            GetDamage();
        }

        /// <summary>
        /// ����
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
        /// ���`
        /// </summary>
        private void Dead()
        {
            print("���`");
        }
    }

}
