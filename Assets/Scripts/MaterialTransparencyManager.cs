using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTransparencyManager : MonoBehaviour
{
    public GameObject Model;
    public float Transparency = 0.4f;

    Color color;
    Material mat;

    void Start()
    {
        //ChangeTransparency(Model);
    }
    private void ChangeTransparency(GameObject ParentModel)
    {
        Component[] MeshRenderers = ParentModel.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer ModelMeshRenderer in MeshRenderers)
        {
            mat = ModelMeshRenderer.material;
            color = mat.color;
            color.a = Transparency;
            mat.color = color;
            //FaceMat.GetComponent<MeshRenderer>().material.re;
            //Material mat = new Material(Shader.Find("Standard"));
            //mat.SetColor("_Color",new Color(0.5226504f, 0.6526892f, 0.764151f, Transparency));
            mat.SetFloat("_Mode", 3);
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.EnableKeyword("_ALPHABLEND_ON");
            mat.renderQueue = 3000;

            ModelMeshRenderer.material = mat;
        }
    }
}
