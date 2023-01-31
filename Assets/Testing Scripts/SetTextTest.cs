using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SetTextTest : MonoBehaviour , IPointerClickHandler
{
	public Image img;
    public GameControllerTest gameController;
	public GameObject oldPosition;
	

    void Start()
    {
		this.img.sprite = gameController.EmptyButton;

	}

    // Update is called once per frame
    void Update()
    {
		
	}

    public void PositionPawnsPhase()
    {

		if (gameController.player1pawns == 0 && gameController.player2pawns == 0)
		{
			gameController.isPositionPawnsPhase = false;
			return;
		}
		if (gameController.player1pawns > 0 && 
			gameController.spriteSide == gameController.RedPlayer && img.sprite == gameController.EmptyButton)
		{
			img.sprite = gameController.RedPlayer;
			gameController.player1pawns--;
			gameController.SetSide();
		}
		else if (gameController.player2pawns > 0 && 
			gameController.spriteSide == gameController.GreenPlayer && img.sprite == gameController.EmptyButton)
		{
			img.sprite = gameController.GreenPlayer;
			gameController.player2pawns--;
			gameController.SetSide();
		}

	}


	public void PickUp()
	{
		if(this.img.sprite == gameController.EmptyButton)
		{
			return;
		}

		if (gameController.spriteSide == gameController.RedPlayer && this.img.sprite == gameController.RedPlayer ||
			gameController.spriteSide == gameController.GreenPlayer && this.img.sprite == gameController.GreenPlayer)
		{
			gameController.selected = this.gameObject;
			gameController.SpriteToMove = img.sprite;
			gameController.CheckPositionItCanMove(this.gameObject.name);
		}
	}

	

	public void OnPointerClick(PointerEventData eventData)
	{

		if (gameController.trilizaHappenedRed && 
			gameController.player1candelete == false &&
			gameController.spriteSide == gameController.RedPlayer)
		{
			foreach (int position in gameController.positionsRedCanMoveAfterTriliza)
			{
				if (this.gameObject.name != gameController.positions[position].name)
				{
					Debug.Log(gameController.positionsRedCanMoveAfterTriliza);
					Debug.Log(this.gameObject.name);
					Debug.Log(gameController.positions[position].name);
					Debug.Log("Clicked Wrong Button");
					return;
				}
				else
				{
					Debug.Log(this.gameObject.name + "CORRECT");
					Debug.Log(gameController.positions[position].name + "CORRECT");
					Debug.Log("Clicked Correct button");
					gameController.trilizaHappenedRed = false;
				}
			}
			
		}
		if (gameController.trilizaHappenedGreen &&
			gameController.player2candelete == false &&
			gameController.spriteSide == gameController.GreenPlayer)
		{
			foreach (int position in gameController.positionsGreenCanMoveAfterTriliza)
			{
				if (this.gameObject.name != gameController.positions[position].name)
				{
					return;
				}
				else
				{
					gameController.trilizaHappenedGreen = false;
				}
			}
		}


		if (gameController.player2candelete && this.img.sprite == gameController.RedPlayer)
		{
			gameController.killedPawnsByPlayer2++;
			gameController.player2candelete = false;
			this.img.sprite = gameController.EmptyButton;
			gameController.SetSide();
			return;
		}
		else if (gameController.player1candelete == gameController.RedPlayer && this.img.sprite == gameController.GreenPlayer)
		{
			gameController.killedPawnsByPlayer1++;
			gameController.player1candelete = false;
			this.img.sprite = gameController.EmptyButton;
			gameController.SetSide();
			return;
		}

		PositionPawnsPhase();
		if(gameController.canMoveIt == false)
		{
			PickUp();
			oldPosition = gameController.selected;
		}
		else
		{
			gameController.selected.GetComponent<Button>().image.sprite = gameController.EmptyButton;
			if (gameController.selected == oldPosition)
			{
				Debug.Log("CANCEL MOVE CALLED");
				this.img.sprite = gameController.SpriteToMove;
				gameController.canMoveIt = true;
				return;
			}
			gameController.MoveToPosition(this.gameObject.name);
			gameController.Triliza();
			if (gameController.player1candelete == true || gameController.player2candelete == true)
				return;
			else
				gameController.SetSide();

		}

	}
}
