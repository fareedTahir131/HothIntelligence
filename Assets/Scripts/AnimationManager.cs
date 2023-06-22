using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;

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

    public void SlideUI(GameObject Screen, float value, float Duration)
    {
        Screen.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, value, 0), Duration).SetEase(Ease.InOutBack);
    }
    public void ScaleAnimation(GameObject Screen,float Scale, float Duration)
    {
        Screen.GetComponent<RectTransform>().DOScale(new Vector3(Scale, Scale, Scale),Duration).SetEase(Ease.OutBack);
    }
    public void FadeScreen(CanvasGroup Screen, float FadeTime,float Visibility)
    {
        if (Visibility>0)
        {
            Debug.Log("Enabled");
            Screen.gameObject.SetActive(true);
            Screen.DOFade(Visibility, FadeTime);
        }
        else
        {
            Screen.DOFade(Visibility, FadeTime);
            StartCoroutine(WaitToDisable(Screen.gameObject, false, FadeTime));
        }
    }
    IEnumerator WaitToDisable(GameObject Screen, bool value, float Duration)
    {
        yield return new WaitForSeconds(Duration);
        Screen.SetActive(value);
    }
}
