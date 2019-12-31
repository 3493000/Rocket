using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySFinder : MonoBehaviour {

	void Start () {
        var tempSP = GetComponent<SpriteRenderer>();
        if (tempSP != null)
        {
            string shaderNmae = tempSP.material.shader.name;
            Shader s = Shader.Find(shaderNmae);
            tempSP.material.shader = s;
        }
        var tempRender = GetComponent<Renderer>();
        if (tempRender != null)
        {
            string shaderName = tempRender.material.shader.name;
            Shader ss = Shader.Find(shaderName);
            tempRender.material.shader = ss;
        }
	}
	
}
