using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string side = "X";


    public string textToMove;
	#region Lists of Move Positions for Each Position

	private int[] position0canMove = { 1, 7, 9};
    private int[] position1canMove = { 0, 2};
    private int[] position2canMove = { 1, 3, 11};
	private int[] position3canMove = { 2, 4};
	private int[] position4canMove = { 3, 5 , 13};
	private int[] position5canMove = { 4, 6};
	private int[] position6canMove = { 5, 7, 15};
	private int[] position7canMove = { 0, 6};


	#endregion

	public int[] positionsItCanMove;
    public GameObject[] positions;

	public TextMeshProUGUI[] positionsText;
	public int player1pawns = 9;
    public int player2pawns = 9;
    public bool isPositionPawnsPhase = true;
	public bool canMoveIt = false;
	public bool canDeleteEnemyPawn = false;
    public GameObject selected;

	// Start is called before the first frame update
	void Start()
    {//1,7,9
		Debug.Log(positions[1].name);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSide()
    {
        if (side == "X")
            side = "O";
        else
            side = "X";
    }



    // WE HAVE IMPLEMENTED 0 POSITION AND 1 POSITION
    // WE NEED TO DO IT 22 MORE TIMES? NO FUCKING WAY
    public void MoveToPosition(string thisname)
    {
        if(selected.name == "Button")
        {
			switch (thisname)
			{
				
				case "Button (1)":
					positions[1].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
				case "Button (7)":
					positions[7].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
				case "Button (9)":
					positions[9].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
			}
		}
        if(selected.name == "Button (1)")
        {
			switch (thisname)
			{
				case "Button":
					positions[0].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
				case "Button (2)":
					positions[2].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
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
					positions[1].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
				case "Button (3)":
					positions[3].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;
				case "Button (11)":
					positions[11].GetComponentInChildren<TextMeshProUGUI>().text = textToMove;
					canMoveIt = false;
					break;

			}
		}
		
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
		}
		foreach (int position in positionsItCanMove) //position0canMove
		{
			if (positions[position].GetComponentInChildren<TextMeshProUGUI>().text == string.Empty)
			{
				canMoveIt = true;
				break;
			}
		}
	}


	public void Triliza()
	{
		if (positionsText[1].text == positionsText[2].text && positionsText[2].text == positionsText[3].text)
		{
			Debug.Log("TRILIZA");
			canDeleteEnemyPawn = true;

		}
	}
}
