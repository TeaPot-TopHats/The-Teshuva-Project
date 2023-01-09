using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTest : MonoBehaviour
{
	
	void Start()
	{
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshCollider>().sharedMesh = mesh;
		
		float fov = 90f;
		Vector3 origin = transform.position;
		int rayCount = 2;
		float angle = 0f;
		float angleIncrease = fov / rayCount;
		float viewDistance = 5f;
		
		Vector3[] vertices = new Vector3[rayCount + 1 + 1];
		Vector2[] uv = new Vector2[vertices.Length];
		int[] triangles = new int[rayCount * 3];
		
		vertices[0] = origin;
		
		int vertexIndex = 1;
		int triangleIndex = 0;
		for (int i = 0; i < rayCount; i++)
		{
			// Code monkey crap code
		}
		
		vertices[0] = Vector3.zero;
		vertices[1] = new Vector3(5, 0);
		vertices[2] = new Vector3(0, -5);
		
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;
	}


	void Update()
	{
		
	}
	
	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
