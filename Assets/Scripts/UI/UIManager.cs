using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameEndScreen GameEndScreen;

    public void ShowGameEndScreen(PlayerSide win, Action onClickRestart)
    {
        GameEndScreen.Show(win, onClickRestart);
    }
}