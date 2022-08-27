using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooterController : MonoBehaviour
{
    public GameObject shootCamGameObj;

    private StarterAssetsInputs _sai;
    // Start is called before the first frame update
    void Start()
    {
        this._sai = this.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this._sai.aim)
        {
            this.shootCamGameObj.SetActive(true);
        }
        else
        {
            this.shootCamGameObj.SetActive(false);
        }
    }
}
