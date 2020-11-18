using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private const float destroyTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
