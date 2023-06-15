using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PatientManager : MonoBehaviour
{
    public static PatientManager Instance;

    public Models[] Modelmaterials;
    public Transform ModelsContent;
    public Transform UsersContent;

    private GameObject PatientGO;

    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void SetPatientIndex(int Index)
    {

    }

    public void SetPatientModelIndex(int Index)
    {
        MakeModelTransparent( Index);
        MakeModelSolidVisible( Index);
        HighliteSelectedModel(Index,ModelsContent);
    }
    private void HighliteSelectedModel(int index, Transform Content)
    {
        foreach (Transform item in Content)
        {
            item.GetComponent<ModelItem>().HighlightUI.SetActive(false);
        }
        Content.GetChild(index).GetComponent<ModelItem>().HighlightUI.SetActive(true);
    }
    public void MakeModelTransparent(int Index)
    {
        PatientGO = GameObject.FindWithTag("Patient_1");
        for (int i = 0; i <= Index; i++)
        {
            PatientGO.transform.GetChild(Index).gameObject.SetActive(true);
            Component[] MeshRenderers = PatientGO.transform.GetChild(i).GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer ModelMeshRenderer in MeshRenderers)
            {
                ModelMeshRenderer.material = Modelmaterials[0].materials[i].TransparentMaterial;
            }
        }
    }
    private void MakeModelSolidVisible(int Index)
    {
        Component[] MeshRenderers = PatientGO.transform.GetChild(Index).GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer ModelMeshRenderer in MeshRenderers)
        {
            ModelMeshRenderer.material = Modelmaterials[0].materials[Index].DefaultMaterial;
        }
    }
}
