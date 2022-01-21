using UnityEngine;

public class MasterGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameManager;

    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("GameController"))
        {
            Instantiate(_gameManager);
        }
    }
}
