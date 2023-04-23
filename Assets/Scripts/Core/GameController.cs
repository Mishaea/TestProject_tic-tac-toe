using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public const int CellsCount = 9;

    private PlayerSide currentTurnSide;
    private CellState[] cellStates = new CellState[CellsCount];

    [Inject] private GameField gameField;
    [Inject] private SaveLoadManager saveLoadManager;
    [Inject] private UIManager uiManager;

    public void NewGame() => RestartGame();

    private void Awake()
    {
        SubscribeToCells();
        ApplySavingData(saveLoadManager.GetSavingData());
    }

    private void SubscribeToCells()
    {
        foreach (var item in gameField.Cells)
        {
            item.OnClickCell += OnClickCell;
        }
    }

    private void OnClickCell(GameFieldCell cell)
    {
        if (!cell) return;
        if (currentTurnSide == PlayerSide.None) return;
        if (cell.CellIndex < 0 || cell.CellIndex >= cellStates.Length) return;
        if (cellStates[cell.CellIndex] != CellState.None) return;

        if (currentTurnSide == PlayerSide.Crosses)
        {
            cellStates[cell.CellIndex] = CellState.Cross;
            cell.ChangeStateView(CellState.Cross);
            currentTurnSide = PlayerSide.Noughts;
        }
        else
        {
            cellStates[cell.CellIndex] = CellState.Zero;
            cell.ChangeStateView(CellState.Zero);
            currentTurnSide = PlayerSide.Crosses;
        }
        saveLoadManager.SaveData(currentTurnSide, cellStates);
        GoalChecker.CheckGoalCondition(cellStates, OnWin);
    }

    private void OnWin(CellState cellState)
    {
        saveLoadManager.SaveData(PlayerSide.Crosses, new CellState[CellsCount]);
        currentTurnSide = PlayerSide.None;
        if (cellState == CellState.None)
        {
            uiManager.ShowGameEndScreen(PlayerSide.None, RestartGame);
        }
        else
        {
            uiManager.ShowGameEndScreen(cellState == CellState.Cross ? PlayerSide.Crosses : PlayerSide.Noughts, RestartGame);
        }
    }

    private void RestartGame()
    {
        foreach (var item in gameField.Cells)
        {
            item.ChangeStateView(CellState.None);
        }
        cellStates = new CellState[CellsCount];
        currentTurnSide = PlayerSide.Crosses;
        saveLoadManager.SaveData(currentTurnSide, cellStates);
    }

    private void ApplySavingData(GameSavingData gameSavingData)
    {
        cellStates = gameSavingData.cellStates;
        if (cellStates == null || cellStates.Length != CellsCount) cellStates = new CellState[CellsCount];
        currentTurnSide = gameSavingData.currentTurnSide;
        foreach (var item in gameField.Cells)
        {
            if (item.CellIndex >= 0 && item.CellIndex < cellStates.Length)
                item.ChangeStateView(cellStates[item.CellIndex]);
        }
    }
}
