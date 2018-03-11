using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNavMeshSourceTag : MonoBehaviour {
	
    void Start(){
        Debug.Log( "Adding NavMeshSourceTag to " + transform.parent.gameObject.name );
        transform.parent.gameObject.AddComponent<NavMeshSourceTag>();
    }
}