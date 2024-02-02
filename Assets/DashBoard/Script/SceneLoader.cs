using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneLoader : MonoBehaviour
{
    public string boatScene;
    public string scrableScene;
    public string carScene;
    public string pianoScene;
    public string snakeLadderScene;
    public string puzzleScene;
    public string chessScene;
    private void Awake()
    {
        Screen.orientation =ScreenOrientation.LandscapeLeft;
    }
    public void LoadBoatScene()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(boatScene);
    }
    public void LoadScrableScene()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(scrableScene);
    }
    public void LoadCarScene()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(carScene);
    }
    public void LoadPianoScene()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(pianoScene);
    }
    public void LoadSnakeladderScene()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(snakeLadderScene);
    }
    public void PuzzleScene()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(puzzleScene);
    }
    public void ChessScene()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene(chessScene);
    }
}
