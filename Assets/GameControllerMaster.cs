using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;
using TMPro;

public class GameControllerMaster : MonoBehaviour
{

    public enum State
    {
        placing,
        playing,
        triara
    }
    public enum Side
    {
        Red,
        Green
    }

    public State state;
    public Side side;

    public UIHandler uihandler;


    public int numberOfRedPawns = 9;
    public int numberOfGreenPawns = 9;

    public int numberOfPawnsRedCaptured = 0;
    public int numberOfPawnsGreenCaptured = 0;

    public bool canKill = true;

    public GameObject[] positionsOfButtons;

    public bool redDidTriara;
    public bool greenDidTriara;
    


	// Start is called before the first frame update
	void Start()
    {
        state = State.placing;
        side = Side.Red;
        
    }

   

    public void ChangeSide()
    {
        if (side == Side.Red)
        {
			side = Side.Green;
            uihandler.CurrentPlayerIsGreen();
		}
        else
        {
			side = Side.Red;
			uihandler.CurrentPlayerIsRed();
		}

	}
	public void GreenPawnsMinusOne()
	{
		numberOfGreenPawns--;
		uihandler.GreenPawnsCounter();
	}
	public void RedPawnsMinusOne()
	{
		numberOfRedPawns--;
        uihandler.RedPawnsCounter();
	}
    public void PawnsCapturedByGreen() {
        numberOfPawnsGreenCaptured++;
        uihandler.GreenPawnsCounter();
    }
    public void PawnsCapturedByRed() {
        numberOfPawnsRedCaptured++;
        uihandler.RedPawnsCounter();
    }

    public void CheckWinner() {
        if(numberOfPawnsRedCaptured == 9) {
			uihandler.StateGameObject.GetComponent<TextMeshProUGUI>().fontSize = 200;
			uihandler.StateGameObject.GetComponent<TextMeshProUGUI>().text = "RED WINS";
			uihandler.StatePopUp(1);
        }
        if (numberOfPawnsGreenCaptured == 9) {
            uihandler.StateGameObject.GetComponent<TextMeshProUGUI>().fontSize = 200;
			uihandler.StateGameObject.GetComponent<TextMeshProUGUI>().text = "GREEN WINS";
			uihandler.StatePopUp(1);
		}
    }

    public void CheckToChangeToPlaying() {
		if (numberOfRedPawns == 0 && numberOfGreenPawns == 0)
		{
			state = GameControllerMaster.State.playing;
            uihandler.ChangeInformationText();
			return;
		}
	}

	public void CheckTriara(GameObject[] firstTriara, GameObject[] secondTriara, DraggableItem.ColorofPiece color)
	{
        GameObject[][] temp = new GameObject[][] { firstTriara, secondTriara };
        foreach (GameObject[] t in temp)
        {
			int Triliza = 1;
			foreach (GameObject g in t)
            {
                if(g.transform.childCount > 0 && g.GetComponentInChildren<DraggableItem>().colorofPiece == color)
                {
                    Debug.Log(g.name + "has children " + g.transform.GetChild(0).name);
                    Triliza++;
                    
                    
                }
               
            }
			if (Triliza == 3)
			{
				state = GameControllerMaster.State.triara;
				uihandler.StatePopUp(1.1f);
				//Debug.Log("TRILIZA");
				if (color.ToString() == "Red")
				{
					Debug.Log("RED DID TRILIZA");
					redDidTriara = true;
				}
				else
				{
					Debug.Log("GREEN DID TRILIZA");
					greenDidTriara = true;

				}
			}
		}
		
        
	}
}


