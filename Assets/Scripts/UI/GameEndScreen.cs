using System;
using UnityEngine;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject WinBlock;
    [SerializeField] private GameObject CrossView;
    [SerializeField] private GameObject ZeroView;
    [SerializeField] private GameObject DrawBlock;

    private Action onClickRestart;

    public void Show(PlayerSide win, Action onClickRestart)
    {
        WinBlock.SetActive(win != PlayerSide.None);
        CrossView.SetActive(win == PlayerSide.Crosses);
        ZeroView.SetActive(win == PlayerSide.Noughts);
        DrawBlock.SetActive(win == PlayerSide.None);
        Content.SetActive(true);
        this.onClickRestart = onClickRestart;
    }

    public void ButtonRestartGame()
    {
        Content.SetActive(false);
        onClickRestart?.Invoke();
        onClickRestart = null;
    }
}