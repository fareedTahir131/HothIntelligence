using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PatientManager : MonoBehaviour
{
    public ARFaceManager ARFaceManagerScript;

    private GameObject PatientGO;
    private int PatientIndex = 0;
    private int PatientModelIndex = 0;
    public Patient[] Patients;


    public void SetPatientIndex(int Index)
    {
        PatientIndex = Index;
        PatientGO = GameObject.FindWithTag("Patient_1");
        DisableChild(PatientGO);
        PatientGO.transform.GetChild(Index).gameObject.SetActive(true);
        //ARFaceManagerScript.facePrefab = Patients[PatientIndex].Models[PatientModelIndex];
    }
    public void SetPatientModelIndex(int Index)
    {
        PatientModelIndex = Index;
        PatientGO = GameObject.FindWithTag("Patient_1");
        DisableChild(PatientGO);
        PatientGO.transform.GetChild(Index).gameObject.SetActive(true);
        //ARFaceManagerScript.facePrefab = Patients[PatientIndex].Models[PatientModelIndex];
    }
    private void DisableChild(GameObject Parent)
    {
        for (int i = 0; i < Parent.transform.childCount; i++)
        {
            Parent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
