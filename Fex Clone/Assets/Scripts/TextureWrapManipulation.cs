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

		//Front side of platform
		UVs[1] = new Vector2(0.0f,0.0f);
		UVs[2] = new Vector2(0.333f,0.0f);
		UVs[3] = new Vector2(0.0f,0.333f);
		UVs[4] = new Vector2(0.333f,0.333f);

		//top
		UVs[5] = new Vector2(0.0f,0.0f);
		UVs[6] = new Vector2(0.0f,0.0f);
		UVs[7] = new Vector2(0.0f,0.0f);
		UVs[8] = new Vector2(0.0f,0.0f);

		//Back
		UVs[9] = new Vector2(0.5f,0.5f);
		UVs[10] = new Vector2(1f,1f);
		UVs[11] = new Vector2(0.5f,1f);
		UVs[12] = new Vector2(1f,0.5f);

		//bottom
		UVs[13] = new Vector2(0.0f,0.0f);
		UVs[14] = new Vector2(0.0f,0.0f);
		UVs[15] = new Vector2(0.0f,0.0f);
		UVs[16] = new Vector2(0.0f,0.0f);

		//left
		UVs[17] = new Vector2(0.0f,0.0f);
		UVs[18] = new Vector2(0.0f,0.0f);
		UVs[19] = new Vector2(0.0f,0.0f);
		UVs[20] = new Vector2(0.0f,0.0f);

		//right
		UVs[20] = new Vector2(0.0f,0.0f);
		UVs[21] = new Vector2(0.0f,0.0f);
		UVs[22] = new Vector2(0.0f,0.0f);
		UVs[23] = new Vector2(0.0f,0.0f);

		mesh.uv = UVs;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
