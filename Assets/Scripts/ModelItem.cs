using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelItem : MonoBehaviour
{
    public GameObject HighlightUI;
    public int TransparencyModelIndex;
    public void ViewModel(int ModelIndex)
    {
        PatientManager.Instance.SetPatientModelIndex(ModelIndex);
    }
    
}
