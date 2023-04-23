using UnityEngine;
using Zenject;

public class NewGameButton : MonoBehaviour
{
    [Inject] private GameController gameController;

    public void ButtonNewGame()
    {
        gameController.NewGame();
    }
}