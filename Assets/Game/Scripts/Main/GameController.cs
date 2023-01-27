using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameState state;
    public static void Win()
    {
        state = GameState.win;
        DialogueController.SetWin();
        QuestController.CancelAll();
    }

    public static void Lose()
    {
        state = GameState.lose;
        DialogueController.SetLose();
        QuestController.CancelAll();
    }

    public static void StartGame()
    {
        state = GameState.game;
    }

    void Start()
    {
        state = GameState.call;
    }
}

public enum GameState
{
    call,
    game,
    win,
    lose,
}