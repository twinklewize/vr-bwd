using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_controller : MonoBehaviour
{
    private Quest brushQuest = Quest.notActive;
    private Quest glassesQuest = Quest.notActive;
    private CurrentInteraction interaction = CurrentInteraction.none;
    private GameState state = GameState.call;

    public void Win()
    {
        state = GameState.win;
        brushQuest = Quest.notActive;
        glassesQuest = Quest.notActive;
    }

    public void Lose()
    {
        state = GameState.lose;
        brushQuest = Quest.notActive;
        glassesQuest = Quest.notActive;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

enum GameState
{
    call,
    game,
    win,
    lose,
}


enum Quest{
    notActive,
    started,
    picked,
    finished
}

enum CurrentInteraction
{
    none,

    artist,

    mother,
    homekeeper,
    detective,
    courier,

    brush,
    glasses,

    cans,
    stepladder,
    painting,
}