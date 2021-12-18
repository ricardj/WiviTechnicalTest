using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class GameplayGUI : MonoBehaviour
{

    public GameObject lowerPanel;
    public LivesPanelController livesPanelController;
    public TimePanelController timePanelController;
    public FoodPanelController foodPanelController;
    public StagePanelController stagePanelController;

    public CanvasGroup restartButton;

    public void Start()
    {
        lowerPanel.gameObject.SetActive(false);

        restartButton.gameObject.SetActive(false);
    }

    public void ShowLowerPanelAndActivate()
    {
        //ShowRestartButton();
        lowerPanel.gameObject.SetActive(true);
        lowerPanel.gameObject.transform.DOMoveY(-500, 0.3f).From();

        livesPanelController.SetLives(3);
        foodPanelController.SetFoodAndScore(0, 100);
        timePanelController.StartTimer();
    }

    public void DeactivateLowerPanel()
    {
        timePanelController.StopTimer();
    }

    private void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
        restartButton.DOFade(0, 0.3f).From();
    }
}
