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
        // 先設為沒打到物件
        Vector3 aimWorldPos = Vector3.zero;

        #region 子彈射線判斷
        /// <summary>
        /// 新增射線做判斷
        /// </summary>
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if(Physics.Raycast(ray, out RaycastHit rh, 999f, this.layerMask))
        {
            // aimWorldPos 瞄準時的世界座標
            aimWorldPos = rh.point;
        }
        else
        {
            // 設計想像中被打到的點
            aimWorldPos = ray.direction * 100;
        }
        #endregion

        /// <summary>
        /// 瞄準
        /// </summary>
        if (this._sai.aim)
        {
            this.shootCamGameObj.SetActive(true);
            this.crossGameObj.SetActive(true);
            this._anim.SetLayerWeight(1, Mathf.Lerp(this._anim.GetLayerWeight(1), 1f, Time.deltaTime * 10));

            #region 修正y軸瞄準時角色動作bug
            Vector3 temp = aimWorldPos;
            temp.y = transform.position.y;
            #endregion

            // 計算完後用normalized取得單位向量
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
