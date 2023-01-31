using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

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
		uihandler.GreenPawnsLeft();
	}
	public void RedPawnsMinusOne()
	{
		numberOfRedPawns--;
        uihandler.RedPawnsLeft();
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
				uihandler.TriaraPopUp(1.1f);
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


