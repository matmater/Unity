using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorScript : MonoBehaviour {

    public List<Color> colors = new List<Color>();
    private Renderer rend;

	// Use this for initialization
	void Start () {
        
        rend = GetComponent<Renderer>();
        foreach (Material mat in rend.materials)
        {
            colors.Add(mat.GetColor("_Color"));
            mat.color = Color.gray;
        }
    }

    void CorrectColors() {
        int j = 0;
        foreach (Material mat in rend.materials)
        {
            mat.color = colors[j];
            j++;
        }
    }
}
