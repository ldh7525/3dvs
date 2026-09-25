using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    public RunContext _context { get; private set; }


    public void LoadRun(RunContext context)
    {
        _context = context;
        // SceneManager.LoadScene()   
    }

    public void LoadMenu()
    {
        // SceneManager.LoadScene()   
    }
}
