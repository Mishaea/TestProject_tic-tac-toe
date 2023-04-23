using System;
using System.Linq;

public class GoalChecker
{
    public static void CheckGoalCondition(CellState[] cellStates, Action<CellState> onWin)
    {
        if (cellStates == null || cellStates.Length != GameController.CellsCount) return;
        if (cellStates[0] != CellState.None && cellStates[0] == cellStates[1] && cellStates[0] == cellStates[2]) onWin?.Invoke(cellStates[0]);
        else if (cellStates[3] != CellState.None && cellStates[3] == cellStates[4] && cellStates[3] == cellStates[5]) onWin?.Invoke(cellStates[3]);
        else if (cellStates[6] != CellState.None && cellStates[6] == cellStates[7] && cellStates[6] == cellStates[8]) onWin?.Invoke(cellStates[6]);
        else if (cellStates[0] != CellState.None && cellStates[0] == cellStates[3] && cellStates[0] == cellStates[6]) onWin?.Invoke(cellStates[0]);
        else if (cellStates[1] != CellState.None && cellStates[1] == cellStates[4] && cellStates[1] == cellStates[7]) onWin?.Invoke(cellStates[1]);
        else if (cellStates[2] != CellState.None && cellStates[2] == cellStates[5] && cellStates[2] == cellStates[8]) onWin?.Invoke(cellStates[2]);
        else if (cellStates[0] != CellState.None && cellStates[0] == cellStates[4] && cellStates[0] == cellStates[8]) onWin?.Invoke(cellStates[0]);
        else if (cellStates[2] != CellState.None && cellStates[2] == cellStates[4] && cellStates[2] == cellStates[6]) onWin?.Invoke(cellStates[2]);
        else if (cellStates.All(item => item != CellState.None)) onWin?.Invoke(CellState.None);
    }
}