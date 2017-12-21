using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureWrapManipulation : MonoBehaviour {

	// Use this for initialization
	//uses all the vectors to take the image and assign in to the mesh
	//use at your own discretion
	void Start () {
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Vector2[] UVs = new Vector2[mesh.vertices.Length];

		//Front side of platform: 1-4
		//top: 5-8
		//Back: 9-10
		//bottom: 13-16
		//left: 17-20
		//right: 20-23
		for (int i = 1; i <= 23; i++) {
			switch (i) {
			case 2:
				UVs [2] = new Vector2 (0.333f, 0.0f);
				break;
			case 3:
				UVs[3] = new Vector2(0.0f,0.333f);
				break;
			case 4:
				UVs[4] = new Vector2(0.333f,0.333f);
				break;
			case 9:
				UVs[9] = new Vector2(0.5f,0.5f);
				break;
			case 10:
				UVs[10] = new Vector2(1f,1f);
				break;
			case 11:
				UVs[11] = new Vector2(0.5f,1f);
				break;
			case 12:
				UVs[12] = new Vector2(1f,0.5f);
				break;
			default:
				UVs [i] = new Vector2 (0.0f, 0.0f);
				break;
			}
		}

		mesh.uv = UVs;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
