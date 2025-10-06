using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        GAMEPLAY, PAUSE,
    }

    public GameState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = GameState.GAMEPLAY;
        hasChangedState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.GAMEPLAY)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                state = GameState.PAUSE;
                hasChangedState = true;
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                state = GameState.GAMEPLAY;
                hasChangedState = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (hasChangedState)
        {
            hasChangedState = false;

            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if (state == GameState.PAUSE)
            {
                Time .timeScale = 0.0f;
            }
        }
    }

    private bool hasChangedState;
}
