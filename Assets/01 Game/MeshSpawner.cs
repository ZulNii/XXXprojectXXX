using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSpawner : MonoBehaviour
{
    public Mesh mesh;
    public GameObject CubePrefab;

    void Start()
    {
        Vector3[] verts = mesh.vertices;
        for (int i = 0; i < verts.Length; i++)
        {
            Instantiate(CubePrefab, verts[i] + transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}