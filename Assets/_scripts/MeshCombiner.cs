// Modified from Erik Nordeau's Mesh Combiner 
// http://www.habrador.com/tutorials/unity-mesh-combining-tutorial/3-combine-meshes-colors/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {
	Mesh meshHolder;
	// This takes a map tile and combines its mesh with
	// its merged building child. THIS MUST BE CHANGED IF
	// THE BUILDING STACK IS CHANGED TO A NONMERGING
	// BUILDING STACK
	// This is currently a destructive process. It can be changed if needed
	public void ApplyToMapTile( GameObject tile ){
		Debug.Log( "Applying to " + tile.name );
		CombineInstance[] meshes = new CombineInstance[3];
		
		// grab tile mesh
		MeshFilter tmf = tile.GetComponent<MeshFilter>();
		
		meshes[0].mesh = tmf.mesh;
		meshes[0].transform = tmf.transform.localToWorldMatrix;

		// grab building mesh
		MeshFilter[] bmf = tile.GetComponentsInChildren<MeshFilter>( true );

		meshes[1].mesh = bmf[0].mesh;
		meshes[1].transform = bmf[0].transform.localToWorldMatrix;
		meshes[2].mesh = bmf[1].mesh;
		meshes[2].transform = bmf[1].transform.localToWorldMatrix;

		// Then deactive the building
		foreach( Transform child in tile.transform ){
			if( child.gameObject.name == "building" ){
				child.gameObject.SetActive( false );
			}
		}

		meshHolder = new Mesh();
		meshHolder.CombineMeshes( meshes, true );
		tile.GetComponent<MeshFilter>().mesh = meshHolder;

	}
	
}
