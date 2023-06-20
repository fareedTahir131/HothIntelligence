using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFaceDetected : MonoBehaviour
{
    private bool IsModelFound = false;
    void Start()
    {
        CheckEnabledModel();
    }
    private void CheckEnabledModel()
    {
        for (int i = 0; i < PatientManager.Instance.Toggles.Length; i++)
        {
            if (PatientManager.Instance.Toggles[i].isOn)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                IsModelFound = true;
                break;
            }
        }
        if (!IsModelFound)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
