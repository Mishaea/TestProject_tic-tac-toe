using UnityEngine;

public class GameField : MonoBehaviour
{
#if UNITY_EDITOR
    [ContextMenu(nameof(FillCells))]
    private void FillCells()
    {
        Cells = GetComponentsInChildren<GameFieldCell>();
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].SetCellIndex(i);
            UnityEditor.EditorUtility.SetDirty(Cells[i]);
        }
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    [field: SerializeField] public GameFieldCell[] Cells { get; private set; }
}
