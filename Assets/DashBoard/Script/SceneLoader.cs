using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string boatScene;
    public string scrableScene;
    public string carScene;
    public string pianoScene;
    public string snakeLadderScene;
    public string puzzleScene;
    public string chessScene;

    public void LoadBoatScene()
    {
        SceneManager.LoadScene(boatScene);
    }
    public void LoadScrableScene()
    {
        SceneManager.LoadScene(scrableScene);
    }
    public void LoadCarScene()
    {
        SceneManager.LoadScene(carScene);
    }
    public void LoadPianoScene()
    {
        SceneManager.LoadScene(pianoScene);
    }
    public void LoadSnakeladderScene()
    {
        SceneManager.LoadScene(snakeLadderScene);
    }
    public void PuzzleScene()
    {
        SceneManager.LoadScene(puzzleScene);
    }
    public void ChessScene()
    {
        SceneManager.LoadScene(chessScene);
    }
}
