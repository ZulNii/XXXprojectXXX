using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushkaController : MonoBehaviour
{
    [SerializeField] private Transform bulletParent;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform sphere;
    private Vector3 mousePosition;
    private float force;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var friendList = GameManager.Instance.GetPlayerLifeScoreObjectList();
            if(friendList.Count==0) return;
            
            var lastObj = friendList[friendList.Count - 1];
            friendList.Remove(lastObj);
            Destroy(lastObj);
            GameManager.Instance.UpdateBoltList();
            
            
            var pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //var renderer = hit.transform.GetComponent<Renderer>();
               // renderer.material.color = Color.blue;
                var distance = Vector3.Distance(bulletParent.position, hit.transform.position);
                sphere.transform.LookAt(hit.point);
                force += distance;
            }
            Fire();
        }
    }

    private void Fire()
    {
        var position = bulletParent.position;
        var bullet = Instantiate(bulletPrefab, position, sphere.transform.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * (force * 100));
        force = 0;
    }
}