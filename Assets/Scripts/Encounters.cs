using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encounters : MonoBehaviour {
    public Material TransitionMaterial;

    private void Start()
    {
        //gameObject.GetComponent<Image>().material.shader = Shader.Find("Unlit/EncounterUIShader");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, TransitionMaterial);
    }
}
