using DG.Tweening;
using System;
using UnityEngine;

public class EndGameGUI : MonoBehaviour
{
    public CanvasGroup endGamePanel;
    public CanvasGroup endGameWinPanel;
    internal void ShowEndGame()
    {
        endGamePanel.gameObject.SetActive(true);
        endGamePanel.DOFade(1, 0.3f);
    }

    public void ShowEndGameWin()
    {
        endGameWinPanel.gameObject.SetActive(true);
        endGameWinPanel.DOFade(1, 0.3f);
    }
}
