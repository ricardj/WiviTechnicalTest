using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGUI : MonoBehaviour
{
    public CanvasGroup landingPanel;

    public void  HideLanding()
    {
        landingPanel.DOFade(0, 0.3f);
    }
}
