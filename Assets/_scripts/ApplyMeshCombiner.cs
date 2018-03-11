using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMeshCombiner : MonoBehaviour {

	void Start () {
		MeshCombiner mc = GameObject.FindGameObjectWithTag( "MeshCombiner" ).GetComponent<MeshCombiner>();
		mc.ApplyToMapTile( gameObject.transform.parent.gameObject );
	}

}
