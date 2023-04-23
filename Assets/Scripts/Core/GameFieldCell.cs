using System;
using UnityEngine;

public class GameFieldCell : MonoBehaviour
{
    public event Action<GameFieldCell> OnClickCell;

    [field: SerializeField] public int CellIndex { get; private set; }

    [SerializeField] private GameObject CrossView;
    [SerializeField] private GameObject ZeroView;

#if UNITY_EDITOR
    public void SetCellIndex(int index) => CellIndex = index;
#endif

    public void ButtonOnClick()
    {
        OnClickCell?.Invoke(this);
    }

    public void ChangeStateView(CellState newState)
    {
        CrossView.SetActive(newState == CellState.Cross);
        ZeroView.SetActive(newState == CellState.Zero);
    }
}
