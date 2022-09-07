using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leo
{
    [CreateAssetMenu(menuName ="Leo/Data Enemy", fileName ="Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;

        [Header("�ˮ`"), Range(0, 10000)]
        public float damage;

    }

}
