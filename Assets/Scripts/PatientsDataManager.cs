using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatientsDataManager : MonoBehaviour
{
    public GameObject RenamePopupBG;
    public GameObject RenamePopup;

    public Text[] PatientsNames;
    public InputField RenameInputField;

    public float Wait = 0.6f;
    private int PatientIndex = 0;

    
    public void EnablePatientRenamePopup(int Index)
    {
        PatientIndex = Index;
        RenameInputField.text = PatientsNames[PatientIndex].text;
        RenamePopupBG.SetActive(true);
        AnimationManager.Instance.FadeScreen(RenamePopupBG.GetComponent<CanvasGroup>(),0.5f,1);
        AnimationManager.Instance.ScaleAnimation(RenamePopup,1,0.5f);
        RenameInputField.ActivateInputField();
    }
    public void RenamePatient()
    {
        PatientsNames[PatientIndex].text = RenameInputField.text;
        AnimationManager.Instance.FadeScreen(RenamePopupBG.GetComponent<CanvasGroup>(), 0.5f, 0);
        AnimationManager.Instance.ScaleAnimation(RenamePopup, 0, 0.5f);
    }
    public void CancelRenameOperation()
    {
        AnimationManager.Instance.FadeScreen(RenamePopupBG.GetComponent<CanvasGroup>(), 0.5f, 0);
        AnimationManager.Instance.ScaleAnimation(RenamePopup, 0, 0.5f);
    }

}
