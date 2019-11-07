using System;
using System.Linq;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public Transform blobTransform;
    public float size;
    public int segments;
    public int smoothing;
    public Vector3 offset;

    private Vector3[] _vertexOffsets;
    private Vector3[] _vertices;

    private MeshFilter _mf;
    private Mesh _mesh;

    private void Start()
    {
        _mf = GetComponent<MeshFilter>();
        _mf.transform.position = blobTransform.position;
        _vertices = new Vector3[segments + 1];

        GenerateVertexOffsets();
        CreateMesh();
    }

    private void Update()
    {
        _mf.transform.position = blobTransform.position + offset;
        UpdateMesh();
    }

    private void CreateMesh()
    {
        _mesh = new Mesh();
        _mf.mesh = _mesh;
        
        GenerateVertices();
        GenerateTriangles();
    }

    private void GenerateVertices()
    {
        _vertices[0] = Vector3.zero;

        for (var i = 1; i < segments + 1; i++)
        {
            _vertices[i] = _vertexOffsets[i - 1];
        }

        _mesh.vertices = _vertices;
    }

    private void GenerateVertexOffsets()
    {
        _vertexOffsets = new Vector3[segments];
        for (var i = 0; i < segments; i++)
        {
            var angle = i * 2 * Mathf.PI / segments;

            var x = size * Mathf.Cos(angle);
            var y = size * Mathf.Sin(angle);
            
            _vertexOffsets[i] = new Vector3(x, y,0);
        }
    }

    private void GenerateTriangles()
    {
        var triangles = new int[segments * 3];
        
        for (var i = 0; i < segments; i++)
        {
            triangles[i * 3]     = 0;
            triangles[i * 3 + 1] = (i + 1) % segments + 1;
            triangles[i * 3 + 2] = (i + 2) % segments + 1;
        }

        triangles = triangles.Reverse().ToArray();
        _mesh.triangles = triangles;
    }
    
    private void SmoothVertices()
    {
        var newVertices = new Vector3[segments];

        for (var i = 0; i < segments; i++)
        {
            newVertices[i] = Vector3.zero;
            for (var j = -smoothing; j <= smoothing; j++)
            {
                var index = i + j;
                if (index < 0) index += segments;
                index = index % segments + 1;
                
                newVertices[i] += _vertices[index];
            }

            newVertices[i] /= smoothing * 2 + 1;
        }

        for (var i = 0; i < segments; i++)
        {
            _vertices[i + 1] = newVertices[i];
        }
    }

    private void UpdateMesh()
    {
        for (var i = 1; i < segments + 1; i++)
        {
            var position = _mf.transform.position;
            var hit = Physics2D.Linecast(position, position + _vertexOffsets[i - 1]);

            if (hit.collider != null) { _vertices[i] = hit.point - new Vector2(position.x, position.y); }
            else                      { _vertices[i] = _vertexOffsets[i - 1]; }
        }
        
        SmoothVertices();
        
        _mf.mesh.vertices = _vertices;
    }
}
