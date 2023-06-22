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

    public Slider FaceTransparencySlider;
    public Slider SkullTransparencySlider;
    public Slider BrainTransparencySlider;

    public GameObject FaceDetection;
    public GameObject PatientsScreen;

    public Toggle ModelLockToggle;
    public Toggle[] Toggles;

    public float DefaultTransparencyValue = 0.5f;
    private GameObject PatientGO;

    private Color color;

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

    private void Start()
    {
        SetDefaultTransparency();
        ResetScrollValue();
        ResetToggle(true);
    }
    public void SetPatientIndex(int Index)
    {

    }
    public void PatientsScreenManager(float value)
    {
        AnimationManager.Instance.SlideUI(PatientsScreen, value, 0.5f);
    }
    public void LockModel(bool value)
    {
        PatientGO = GameObject.FindWithTag("Patient_1");
        PatientGO.GetComponent<ARFace>().destroyOnRemoval = value;
    }
    public void SetPatientModelIndex(int Index)
    {
        if (Toggles[Index].isOn)
        {
            MakeModelTransparent(Index);
            MakeModelSolidVisible(Index);
        }
        HighliteSelectedModel(Index, ModelsContent);
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
            //ModelMeshRenderer.material = Modelmaterials[0].materials[Index].DefaultMaterial;
            ModelMeshRenderer.material = Modelmaterials[0].materials[Index].TransparentMaterial;
        }
    }
    public void ToggleLockManager()
    {
        if (ModelLockToggle.isOn)
        {
            LockModel(true);
            FaceDetection.SetActive(true);
        }
        else
        {
            LockModel(false);
            FaceDetection.SetActive(false);
        }
    }
    private void ResetToggle(bool value)
    {
        foreach (Toggle toggle in Toggles)
        {
            toggle.isOn = value;
        }
    }
    public void ToggleManager(int Index)
    {
        if (Toggles[Index].isOn)
        {
            DisableModel(Index, true);
        }
        else
        {
            DisableModel(Index,false);
        }
    }
    private void DisableModel(int ModelIndex,bool value)
    {
        try
        {
            PatientGO = GameObject.FindWithTag("Patient_1");
            PatientGO.transform.GetChild(ModelIndex).gameObject.SetActive(value);
        }
        catch (System.Exception ex)
        {
            Debug.Log("No Model Found");
        }
        
    }
    public void ApplyFaceCustomizedTransparency()
    {
        color = Modelmaterials[0].materials[0].TransparentMaterial.color;
        color.a = FaceTransparencySlider.value;
        Modelmaterials[0].materials[0].TransparentMaterial.color = color;
    }
    public void ApplySkullCustomizedTransparency()
    {
        color = Modelmaterials[0].materials[1].TransparentMaterial.color;
        color.a = SkullTransparencySlider.value;
        Modelmaterials[0].materials[1].TransparentMaterial.color = color;
    }
    public void ApplyBrainCustomizedTransparency()
    {
        color = Modelmaterials[0].materials[2].TransparentMaterial.color;
        color.a = BrainTransparencySlider.value;
        Modelmaterials[0].materials[2].TransparentMaterial.color = color;
    }
    private void SetDefaultTransparency()
    {
        for (int i = 0; i < Modelmaterials.Length; i++)
        {
            for (int j = 0; j < Modelmaterials[i].materials.Length; j++)
            {
                color = Modelmaterials[i].materials[j].TransparentMaterial.color;
                color.a = DefaultTransparencyValue;
                Modelmaterials[i].materials[j].TransparentMaterial.color = color;
            }
        }
    }
    private void ResetScrollValue()
    {
        FaceTransparencySlider.value = DefaultTransparencyValue;
        SkullTransparencySlider.value = DefaultTransparencyValue;
        BrainTransparencySlider.value = DefaultTransparencyValue;
    }
}
