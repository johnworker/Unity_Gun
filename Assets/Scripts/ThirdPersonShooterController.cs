using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooterController : MonoBehaviour
{
    public GameObject shootCamGameObj;
    public GameObject crossGameObj;
    public LayerMask layerMask;
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private StarterAssetsInputs _sai;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        this._sai = this.GetComponent<StarterAssetsInputs>();
        this._anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���]���S���쪫��
        Vector3 aimWorldPos = Vector3.zero;

        #region �l�u�g�u�P�_
        /// <summary>
        /// �s�W�g�u���P�_
        /// </summary>
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if(Physics.Raycast(ray, out RaycastHit rh, 999f, this.layerMask))
        {
            // aimWorldPos �˷Ǯɪ��@�ɮy��
            aimWorldPos = rh.point;
        }
        else
        {
            // �]�p�Q�����Q���쪺�I
            aimWorldPos = ray.direction * 100;
        }
        #endregion

        /// <summary>
        /// �˷�
        /// </summary>
        if (this._sai.aim)
        {
            this.shootCamGameObj.SetActive(true);
            this.crossGameObj.SetActive(true);
            this._anim.SetLayerWeight(1, Mathf.Lerp(this._anim.GetLayerWeight(1), 1f, Time.deltaTime * 10));

            #region �ץ�y�b�˷Ǯɨ���ʧ@bug
            Vector3 temp = aimWorldPos;
            temp.y = transform.position.y;
            #endregion

            // �p�⧹���normalized���o���V�q
            Vector3 aimDirection = (temp - transform.position).normalized;


            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 50);

            if (this._sai.shoot)
            {
                Vector3 bulletDirection = (aimWorldPos - this.bulletSpawnTransform.position).normalized;
                GameObject go = Instantiate(this.bulletPrefab, this.bulletSpawnTransform.position, Quaternion.LookRotation(bulletDirection, Vector3.up));
                go.name = "Bullet";
                go.SetActive(true);
                this._sai.shoot = false;
            }
        }
        else
        {
            this.shootCamGameObj.SetActive(false);
            this.crossGameObj.SetActive(false);
            this._anim.SetLayerWeight(1, Mathf.Lerp(this._anim.GetLayerWeight(1), 0f, Time.deltaTime * 10));
        }
    }
}
