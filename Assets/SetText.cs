using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class SetText : MonoBehaviour , IPointerClickHandler
{
    public TextMeshProUGUI buttonText;
    public GameController gameController;
	
	

   void Awake()
	{
		
	}

    void Start()
    {


	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionPawnsPhase()
    {

		Debug.Log(this.gameObject.name);
		if (gameController.player1pawns == 0 && gameController.player2pawns == 0)
		{
			return;
		}
		if (gameController.player1pawns > 0 && gameController.side == "X" && buttonText.text == string.Empty)
		{
			this.buttonText.text = gameController.side;
			gameController.player1pawns--;
			gameController.SetSide();
		}
		else if (gameController.player2pawns > 0 && gameController.side == "O" && buttonText.text == string.Empty)
		{
			this.buttonText.text = gameController.side;
			gameController.player2pawns--;
			gameController.SetSide();
		}
		
    }

    public void ClickToMove()
    {


		if (gameController.side == "X" && buttonText.text == "X" ||
			gameController.side == "O" && buttonText.text == "O")
		{
			gameController.selected = this.gameObject;
			gameController.textToMove = this.buttonText.text;
			gameController.CheckPositionItCanMove(this.gameObject.name);

			if(gameController.canMoveIt == true)
				this.buttonText.text = string.Empty;

			Debug.Log("Click TO MOVE REACHED");
		}


	}
	
	public void CancelMove()
	{
		if(gameController.selected.gameObject.name == this.gameObject.name && gameController.canMoveIt == true)
		{
			Debug.Log("CANCEL MOVE CALLED");
			this.buttonText.text = gameController.side;
			gameController.canMoveIt = false;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		//PositionPawnsPhase();
		if (gameController.canMoveIt == false)
		{
			ClickToMove();
		}
		else
		{
				CancelMove();
				gameController.MoveToPosition(this.name.ToString());
		}
		
		gameController.Triliza();
		

	}
}
