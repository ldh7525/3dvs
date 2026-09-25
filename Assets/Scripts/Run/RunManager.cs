
using UnityEngine;

public class RunManager<Singleton>
{
    [SerializeField] private Player _player;

    private void Start()
    {
        RunSetup();
    }

    private void RunSetup()
    {
        RunContext context = GameManager.Instance._context;

        _player.Setup();
    }

    
}