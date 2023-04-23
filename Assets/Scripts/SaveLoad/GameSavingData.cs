
[System.Serializable]
public class GameSavingData
{
    public PlayerSide currentTurnSide = PlayerSide.Crosses;
    public CellState[] cellStates = new CellState[GameController.CellsCount];
}