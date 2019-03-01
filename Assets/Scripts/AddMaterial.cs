using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaterial : MonoBehaviour {
    RenderTexture videoStreamRenderTexture;
    Material sphereMaterial;

    // Use this for initialization
    void Start () {
        // create a new render texture to display the video 
        videoStreamRenderTexture = new RenderTexture(2160, 1440, 32, RenderTextureFormat.ARGB32);

        videoStreamRenderTexture.Create();

        // assign the render texture to the object material 
        sphereMaterial = gameObject.GetComponent<Renderer>().sharedMaterial;

        addMaterial();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addMaterial() {
        sphereMaterial.mainTexture = videoStreamRenderTexture;
    }
}
