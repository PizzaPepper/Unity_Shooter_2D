using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("General")]
    public float FireRange = 200;
    public GameObject bulletHolePrefab;

    [Header("Shoot Parameters")]
    public LayerMask hittableLayers;


    private Transform cameraPlayerTransform;

    void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;    
    }


    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, FireRange, hittableLayers))
            {
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab,hit.point + hit.normal * 0.001f,Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);
            }

        }
    }
}
