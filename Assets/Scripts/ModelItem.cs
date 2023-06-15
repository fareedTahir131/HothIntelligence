using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelItem : MonoBehaviour
{
    public GameObject HighlightUI;
    public void ViewModel(int ModelIndex)
    {
        PatientManager.Instance.SetPatientModelIndex(ModelIndex);
    }
    //public void EnableTransparency(int ModelIndex)
    //{
    //    PatientManager.Instance.MakeModelTransparent(ModelIndex);
    //}
}
