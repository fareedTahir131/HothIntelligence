using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientsDataManager : MonoBehaviour
{
    public GameObject RenamePopup;

    public Text[] PatientsNames;
    public InputField RenameInputField;

    private int PatientIndex = 0;

    public void EnablePatientRenamePopup(int Index)
    {
        RenamePopup.SetActive(true);
        PatientIndex = Index;
        RenameInputField.text = PatientsNames[PatientIndex].text;
    }
    public void RenamePatient()
    {
        RenamePopup.SetActive(false);
        PatientsNames[PatientIndex].text = RenameInputField.text;
        RenameInputField.text = "";
    }
}
