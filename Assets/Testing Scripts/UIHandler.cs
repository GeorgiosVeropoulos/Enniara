using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
    public GameControllerMaster gameController;
    public GameObject pauseMenu;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject StateGameObject;
    public AudioSource music;
    public TextMeshProUGUI InfoAboutMovesAndCaptures;

    public bool musicPlaying = true;

    public TextMeshProUGUI currentPlayerText;
    public TextMeshProUGUI redPawnsLeftTextAndCaptured;
	public TextMeshProUGUI greenPawnsLeftTextAndCaptured;

    // Start is called before the first frame update
    void Start()
    {
        InfoAboutMovesAndCaptures.text = "Moves Left:";
		LeanTween.scale(StateGameObject, new Vector2(0, 0), 0).setIgnoreTimeScale(true);
		musicOff.SetActive(false);
        pauseMenu.SetActive(false);
        LeanTween.scale(pauseMenu, new Vector2(0, 0), 0);
        currentPlayerText.text = "Red";
        currentPlayerText.color = Color.red;
    }

    public void ChangeInformationText() {
        InfoAboutMovesAndCaptures.text = "Score:";
    }
    public void StatePopUp(float xyz)
    {
        LeanTween.scale(StateGameObject, new Vector3(xyz, xyz, xyz), 0.3f).setIgnoreTimeScale(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        LeanTween.scale(pauseMenu, new Vector3(1f, 1f, 1f), 0.7f).setIgnoreTimeScale(true);
		Time.timeScale = 0;
	}
    public void UnPause()
    {
		LeanTween.scale(pauseMenu, new Vector3(0f, 0f, 0f), 0.7f).setIgnoreTimeScale(true);
		Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void PauseAndUnPauseMusic()
    {
        if (!musicPlaying)
        {
			music.UnPause();
			musicOn.SetActive(true);
			musicOff.SetActive(false);
            musicPlaying = true;
            return;
		}
		music.Pause();
		musicOff.SetActive(true);
		musicOn.SetActive(false);
		musicPlaying = false;
		return;

	}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CurrentPlayerIsRed()
    {
        currentPlayerText.text = "Red";
        currentPlayerText.color = Color.red;
    }
	public void CurrentPlayerIsGreen()
	{
		currentPlayerText.text = "Green";
		currentPlayerText.color = Color.green;
	}
    public void GreenPawnsCounter()
    {
        if(gameController.state == GameControllerMaster.State.placing) {
		    greenPawnsLeftTextAndCaptured.text = gameController.numberOfGreenPawns.ToString();
		}
        if(gameController.state == GameControllerMaster.State.playing || gameController.state == GameControllerMaster.State.triara) {
			greenPawnsLeftTextAndCaptured.text = gameController.numberOfPawnsGreenCaptured.ToString();
		}

	}
	public void RedPawnsCounter()
	{
	
		if (gameController.state == GameControllerMaster.State.placing) {
			redPawnsLeftTextAndCaptured.text = gameController.numberOfRedPawns.ToString();
		}
		if (gameController.state == GameControllerMaster.State.playing || gameController.state == GameControllerMaster.State.triara) {
			redPawnsLeftTextAndCaptured.text = gameController.numberOfPawnsRedCaptured.ToString();
		}
	}



}
