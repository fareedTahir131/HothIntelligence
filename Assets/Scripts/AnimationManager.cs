using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public float Duration = 0.4f;
    public GameObject PatientsScreen;

    public void SkinSlideManager(float Value)
    {
        SlideUI(PatientsScreen, Value);
    }
    private void SlideUI(GameObject Screen, float value)
    {
        Screen.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, value, 0), Duration).SetEase(Ease.InOutBack);
    }
}
