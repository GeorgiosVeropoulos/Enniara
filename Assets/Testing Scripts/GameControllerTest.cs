using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerTest : MonoBehaviour
{
	
	public Sprite spriteSide;

	public string textToMove;
	#region Lists of Move Positions for Each Position

	private int[] position0canMove = { 1, 7 };
	private int[] position1canMove = { 0, 2 };
	private int[] position2canMove = { 1, 3 };
	private int[] position3canMove = { 2, 4, 13 };
	private int[] position4canMove = { 3, 5 };
	private int[] position5canMove = { 4, 6, 15 };
	private int[] position6canMove = { 5, 7 };
	private int[] position7canMove = { 0, 6, 9 };
	private int[] position8canMove = { 9, 15 };
	private int[] position9canMove = { 7, 8, 10, 18 };
	private int[] position10canMove = { 9, 11 };
	private int[] position11canMove = { 1, 10, 12, 20 };
	private int[] position12canMove = { 11, 13 };
	private int[] position13canMove = { 3, 12, 14, 22 };
	private int[] position14canMove = { 13, 15 };
	private int[] position15canMove = { 5, 8, 14, 16 };
	private int[] position16canMove = { 15, 17, 23};
	private int[] position17canMove = { 16, 18};
	private int[] position18canMove = { 9, 17, 19};
	private int[] position19canMove = { 18, 20};
	private int[] position20canMove = { 11, 19, 21};
	private int[] position21canMove = { 20, 22};
	private int[] position22canMove = { 13, 21, 23};
	private int[] position23canMove = { 16, 22};


	#endregion

	#region Other Variables
	public int[] positionsItCanMove;
    public GameObject[] positions;

	public int[] positionsRedCanMoveAfterTriliza;
	public int[] positionsGreenCanMoveAfterTriliza;

	public Button[] positionsColor;
	public int player1pawns = 9;
    public int player2pawns = 9;
    public bool isPositionPawnsPhase = true;
	public bool canMoveIt = false;
	public bool trilizaHappenedRed = false;
	public bool trilizaHappenedGreen = false;
	
	public bool changeSide = false;
    public GameObject selected;
	

	public Sprite RedPlayer;
	public Sprite GreenPlayer;
	public Sprite EmptyButton;
	public Sprite SpriteToMove;
	
	public int killedPawnsByPlayer1;
	public int killedPawnsByPlayer2;

	public bool player1candelete;
	public bool player2candelete;

	public UIHandler uiHandler;

	#endregion

	private void Awake()
	{
		spriteSide = RedPlayer;
	}

	public void SetSide()
    {
        if (spriteSide == RedPlayer)
		{
			spriteSide = GreenPlayer;
			//uiHandler.informationText.text = "Green Player Turn";
		}
		else
		{
			spriteSide = RedPlayer;
			//uiHandler.informationText.text = "Red Player Turn";
		}
			
	}


    public void MoveToPosition(string thisname)
    {
        if(selected.name == "Button")
        {
			switch (thisname)
			{
				case "Button (1)":
					positions[1].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false;
					changeSide = true;
					break;
				case "Button (7)":
					positions[7].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false;
					changeSide = true;
					break;
				
			}
		}
        if(selected.name == "Button (1)")
        {
			switch (thisname)
			{
				case "Button":
					positions[0].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false;
					changeSide = true;
					break;

				case "Button (2)":
					positions[2].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				default:
					break;
			}
		}
		if(selected.name == "Button (2)")
		{
			switch (thisname)
			{
				case "Button (1)":
					positions[1].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (3)":
					positions[3].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				

			}
		}
		if (selected.name == "Button (3)")
		{
			switch (thisname)
			{
				case "Button (2)":
					positions[2].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (4)":
					positions[4].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (13)":
					positions[13].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (4)")
		{
			switch (thisname)
			{
				case "Button (3)":
					positions[3].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (5)":
					positions[5].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (5)")
		{
			switch (thisname)
			{
				case "Button (4)":
					positions[4].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (6)":
					positions[6].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (15)":
					positions[15].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;

			}
		}
		if (selected.name == "Button (6)")
		{
			switch (thisname)
			{
				case "Button (5)":
					positions[5].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (7)":
					positions[7].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (7)")
		{
			switch (thisname)
			{
				case "Button":
					positions[0].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (6)":
					positions[6].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (9)":
					positions[9].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (8)")
		{
			switch (thisname)
			{
				case "Button (9)":
					positions[9].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (15)":
					positions[15].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (9)")
		{
			switch (thisname)
			{
				case "Button (7)":
					positions[7].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (8)":
					positions[8].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (10)":
					positions[10].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (18)":
					positions[18].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (10)")
		{
			switch (thisname)
			{
				case "Button (9)":
					positions[9].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (11)":
					positions[11].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (11)")
		{
			switch (thisname)
			{
				case "Button (1)":
					positions[1].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (10)":
					positions[10].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (12)":
					positions[12].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (20)":
					positions[20].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (12)")
		{
			switch (thisname)
			{
				case "Button (11)":
					positions[11].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (13)":
					positions[13].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (13)")
		{
			switch (thisname)
			{
				case "Button (3)":
					positions[3].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (12)":
					positions[12].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (14)":
					positions[14].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (22)":
					positions[22].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (14)")
		{
			switch (thisname)
			{
				case "Button (13)":
					positions[9].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (15)":
					positions[15].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (15)")
		{
			switch (thisname)
			{
				case "Button (5)":
					positions[5].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (8)":
					positions[8].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (14)":
					positions[14].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (22)":
					positions[22].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (16)")
		{
			switch (thisname)
			{
				case "Button (15)":
					positions[15].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (17)":
					positions[17].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (23)":
					positions[23].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (17)")
		{
			switch (thisname)
			{
				case "Button (16)":
					positions[16].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (18)":
					positions[18].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;


			}
		}
		if (selected.name == "Button (18)")
		{
			switch (thisname)
			{
				case "Button (9)":
					positions[9].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (17)":
					positions[17].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (19)":
					positions[19].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;

			}
		}
		if (selected.name == "Button (19)")
		{
			switch (thisname)
			{
				case "Button (18)":
					positions[18].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (20)":
					positions[20].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;

			}
		}
		if (selected.name == "Button (20)")
		{
			switch (thisname)
			{
				case "Button (11)":
					positions[11].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (19)":
					positions[19].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (21)":
					positions[21].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
			}
		}
		if (selected.name == "Button (21)")
		{
			switch (thisname)
			{
				case "Button (20)":
					positions[20].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (22)":
					positions[22].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				
			}
		}
		if (selected.name == "Button (22)")
		{
			switch (thisname)
			{
				case "Button (13)":
					positions[13].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (21)":
					positions[21].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (23)":
					positions[23].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
			}
		}
		if (selected.name == "Button (23)")
		{
			switch (thisname)
			{
				case "Button (16)":
					positions[16].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
				case "Button (22)":
					positions[22].GetComponent<Button>().image.sprite = SpriteToMove;
					canMoveIt = false; changeSide = true;
					break;
			}
		}

		//SetSide();
	}

    public void CheckPositionItCanMove(string startingPosition)
    {
		
		switch (startingPosition)
        {
            case "Button":
                positionsItCanMove = position0canMove;
                break;
            case "Button (1)":
                positionsItCanMove = position1canMove;
                break;
			case "Button (2)":
				positionsItCanMove = position2canMove;
				break;
			case "Button (3)":
				positionsItCanMove = position3canMove;
				break;
			case "Button (4)":
				positionsItCanMove = position4canMove;
				break;
			case "Button (5)":
				positionsItCanMove = position5canMove;
				break;
			case "Button (6)":
				positionsItCanMove = position6canMove;
				break;
			case "Button (7)":
				positionsItCanMove = position7canMove;
				break;
			case "Button (8)":
				positionsItCanMove = position8canMove;
				break;
			case "Button (9)":
				positionsItCanMove = position9canMove;
				break;
			case "Button (10)":
				positionsItCanMove = position10canMove;
				break;
			case "Button (11)":
				positionsItCanMove = position11canMove;
				break;
			case "Button (12)":
				positionsItCanMove = position12canMove;
				break;
			case "Button (13)":
				positionsItCanMove = position13canMove;
				break;
			case "Button (14)":
				positionsItCanMove = position14canMove;
				break;
			case "Button (15)":
				positionsItCanMove = position15canMove;
				break;
			case "Button (16)":
				positionsItCanMove = position16canMove;
				break;
			case "Button (17)":
				positionsItCanMove = position17canMove;
				break;
			case "Button (18)":
				positionsItCanMove = position18canMove;
				break;
			case "Button (19)":
				positionsItCanMove = position19canMove;
				break;
			case "Button (20)":
				positionsItCanMove = position20canMove;
				break;
			case "Button (21)":
				positionsItCanMove = position21canMove;
				break;
			case "Button (22)":
				positionsItCanMove = position22canMove;
				break;
			case "Button (23)":
				positionsItCanMove = position23canMove;
				break;
		}
		foreach (int position in positionsItCanMove)
		{
			if (positions[position].GetComponent<Button>().image.sprite == EmptyButton)
			{
				canMoveIt = true;
				break;
			}
		}
	}

	public void Triliza()
	{
		if (positionsColor[0].image.sprite == spriteSide &&
			positionsColor[1].image.sprite == spriteSide &&
			positionsColor[2].image.sprite == spriteSide)
		{
			TrilizaDecider(0,1,2);
		}
		if (positionsColor[2].image.sprite == spriteSide &&
			positionsColor[3].image.sprite == spriteSide &&
			positionsColor[4].image.sprite == spriteSide)
		{
			TrilizaDecider(2,3,4);
		}
		if (positionsColor[4].image.sprite == spriteSide &&
			positionsColor[5].image.sprite == spriteSide &&
			positionsColor[6].image.sprite == spriteSide)
		{
			TrilizaDecider(4,5,6);
		}
		if (positionsColor[6].image.sprite == spriteSide &&
			positionsColor[7].image.sprite == spriteSide &&
			positionsColor[0].image.sprite == spriteSide)
		{
			TrilizaDecider(6,7,0);
		}
		if (positionsColor[10].image.sprite == spriteSide &&
			positionsColor[11].image.sprite == spriteSide &&
			positionsColor[12].image.sprite == spriteSide)
		{
			TrilizaDecider(10,11,12);
		}
		if (positionsColor[19].image.sprite == spriteSide &&
			positionsColor[20].image.sprite == spriteSide &&
			positionsColor[21].image.sprite == spriteSide)
		{
			TrilizaDecider(19,20,21);
		}
		if (positionsColor[17].image.sprite == spriteSide &&
			positionsColor[16].image.sprite == spriteSide &&
			positionsColor[23].image.sprite == spriteSide)
		{
			TrilizaDecider(17,16,23);
		}
		if (positionsColor[8].image.sprite == spriteSide &&
			positionsColor[15].image.sprite == spriteSide &&
			positionsColor[14].image.sprite == spriteSide)
		{
			TrilizaDecider(8,15,14);
		}
		if (positionsColor[8].image.sprite == spriteSide &&
			positionsColor[9].image.sprite == spriteSide &&
			positionsColor[10].image.sprite == spriteSide)
		{
			TrilizaDecider(8,9,10);
		}
		if (positionsColor[17].image.sprite == spriteSide &&
			positionsColor[18].image.sprite == spriteSide &&
			positionsColor[19].image.sprite == spriteSide)
		{
			TrilizaDecider(17,18,19);
		}
		if (positionsColor[1].image.sprite == spriteSide &&
			positionsColor[11].image.sprite == spriteSide &&
			positionsColor[20].image.sprite == spriteSide)
		{
			TrilizaDecider(1,11,20);
		}
		if (positionsColor[16].image.sprite == spriteSide &&
			positionsColor[15].image.sprite == spriteSide &&
			positionsColor[5].image.sprite == spriteSide)
		{
			TrilizaDecider(16,15,5);
		}
		if (positionsColor[21].image.sprite == spriteSide &&
			positionsColor[22].image.sprite == spriteSide &&
			positionsColor[23].image.sprite == spriteSide)
		{
			TrilizaDecider(21,22,23);
		}
		if (positionsColor[12].image.sprite == spriteSide &&
			positionsColor[13].image.sprite == spriteSide &&
			positionsColor[14].image.sprite == spriteSide)
		{
			TrilizaDecider(12,13,14);
		}
		if (positionsColor[7].image.sprite == spriteSide &&
			positionsColor[9].image.sprite == spriteSide &&
			positionsColor[18].image.sprite == spriteSide)
		{
			TrilizaDecider(7,9,18);
		}
		if (positionsColor[22].image.sprite == spriteSide &&
			positionsColor[13].image.sprite == spriteSide &&
			positionsColor[3].image.sprite == spriteSide)
		{
			TrilizaDecider(22,13,3);
		}
	}

	public void TrilizaDecider(int first, int second, int third)
	{ 

		if (spriteSide == RedPlayer)
		{
			player1candelete = true;
			trilizaHappenedRed = true;
			positionsRedCanMoveAfterTriliza = new int[] { first, second, third };
			//uiHandler.informationText.text = "TRILIZA FOR RED";
			
		}
		else if (spriteSide == GreenPlayer)
		{
			player2candelete = true;
			trilizaHappenedGreen = true;
			positionsGreenCanMoveAfterTriliza = new int[] { first, second, third };
			//uiHandler.informationText.text = "TRILIZA FOR GREEN";
		}
			
	}
}
