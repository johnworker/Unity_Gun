using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooterController : MonoBehaviour
{
    public GameObject shootCamGameObj;
    public GameObject crossGameObj;

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
        if (this._sai.aim)
        {
            this.shootCamGameObj.SetActive(true);
            this.crossGameObj.SetActive(true);
            this._anim.SetLayerWeight(1, Mathf.Lerp(this._anim.GetLayerWeight(1), 1f, Time.deltaTime * 10));
        }
        else
        {
            this.shootCamGameObj.SetActive(false);
            this.crossGameObj.SetActive(false);
            this._anim.SetLayerWeight(1, Mathf.Lerp(this._anim.GetLayerWeight(1), 0f, Time.deltaTime * 10));
        }
    }
}
