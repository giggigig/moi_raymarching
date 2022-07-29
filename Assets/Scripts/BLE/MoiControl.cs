using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoiControl : MonoBehaviour
{
    private BLE bleMgr;

    public Light dirLight;


    // Start is called before the first frame update
    void Start()
    {
        bleMgr = BLE.instance;
    }

    void Update()
    {
    //    switch (bleMgr.bluetoothOn)
    //    {
    //        case true:
    //            {
    //                float _intensity = float.Parse(bleMgr.message) / 500;

    //                dirLight.intensity = _intensity * 2.0f;
    //                break;
    //            }
    //    }
    }
}
