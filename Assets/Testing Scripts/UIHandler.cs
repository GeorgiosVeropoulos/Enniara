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
    public GameObject Triara;
    public AudioSource music;
    
    public bool musicPlaying = true;

    public TextMeshProUGUI currentPlayerText;
    public TextMeshProUGUI redPawnsLeftText;
	public TextMeshProUGUI greenPawnsLeftText;

    // Start is called before the first frame update
    void Start()
    {
		LeanTween.scale(Triara, new Vector2(0, 0), 0).setIgnoreTimeScale(true);
		musicOff.SetActive(false);
        pauseMenu.SetActive(false);
        LeanTween.scale(pauseMenu, new Vector2(0, 0), 0);
        currentPlayerText.text = "Red";
        currentPlayerText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriaraPopUp(float xyz)
    {
        LeanTween.scale(Triara, new Vector3(xyz, xyz, xyz), 0.3f).setIgnoreTimeScale(true);
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
    public void GreenPawnsLeft()
    {
		greenPawnsLeftText.text = gameController.numberOfGreenPawns.ToString(); 
    }
	public void RedPawnsLeft()
	{
		redPawnsLeftText.text = gameController.numberOfRedPawns.ToString();
	}
}
