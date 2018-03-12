using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {
	
	public void ApplyToMapTile( GameObject tile ){
		MeshFilter[] mf = tile.GetComponentsInChildren<MeshFilter>();
		int nMeshes = mf.Length;
		CombineInstance[] meshes = new CombineInstance[ nMeshes ];
		for( int i = 0; i < nMeshes; i++ ){
			Mesh currMesh = mf[i].mesh;
			meshes[i].mesh = new Mesh();
			meshes[i].mesh.vertices = currMesh.vertices;
			meshes[i].mesh.triangles = currMesh.triangles;
			meshes[i].mesh.uv = currMesh.uv;
			meshes[i].mesh.normals = currMesh.normals;
			meshes[i].mesh.colors = currMesh.colors;
			meshes[i].mesh.tangents = currMesh.tangents;
			meshes[i].transform = mf[i].transform.localToWorldMatrix;
			Debug.Log("Transform: " + meshes[i].transform );

		}
		GameObject test = new GameObject();
		test.name = "TEST";
		test.AddComponent<MeshRenderer>();

		//test.GetComponent<MeshRenderer>().material = tile.GetComponent<MeshRenderer>().material;
		test.GetComponent<MeshRenderer>().enabled = false;
		test.AddComponent<MeshFilter>();
		//test.GetComponent<MeshFilter>().mesh = meshes[1].mesh;
		//test.GetComponent<MeshFilter>().mesh = new Mesh();
		test.GetComponent<MeshFilter>().mesh.CombineMeshes( meshes, true );
		test.AddComponent<NavMeshSourceTag>();

	}


	
}
