using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private const string SAVING_DATA_KEY = "SAVING_DATA_KEY";
    private GameSavingData gameSavingData = null;

    public GameSavingData GetSavingData()
    {
        if (gameSavingData == null)
        {
            gameSavingData = SaveLoadUtils.LoadObject<GameSavingData>(SAVING_DATA_KEY) ?? new GameSavingData();
        }
        return gameSavingData;
    }

    public void SaveData(PlayerSide playerSide, CellState[] cellStates)
    {
        if (cellStates == null || cellStates.Length != GameController.CellsCount) return;
        gameSavingData.currentTurnSide = playerSide;
        gameSavingData.cellStates = cellStates;
        SaveLoadUtils.SaveObject(SAVING_DATA_KEY, gameSavingData);
    }
}
