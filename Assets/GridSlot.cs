using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]


public class GridSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public GameObject redGameObject;
    public GameObject greenGameObject;
    public GameObject[] positionsItCanMove;
    public GameControllerMaster gameControllerMaster;

    public GameObject[] firstTriara;
    public GameObject[] secondTriara;

    
    private void Start()
    {
        gameControllerMaster = FindObjectOfType<GameControllerMaster>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggedItem = dropped.GetComponent<DraggableItem>();

            foreach (GameObject obj in draggedItem.placesItCanBeDragged)
            {
                if(obj.name == this.name)
                {

                    
                    draggedItem.parentAfterDrag = transform;
                    draggedItem.afterSlot = transform.gameObject;
                    Debug.Log("Dropped Item");
		            gameControllerMaster.CheckTriara(firstTriara, secondTriara, draggedItem.GetComponent<DraggableItem>().colorofPiece);

                    if(gameControllerMaster.state != GameControllerMaster.State.triara)
						gameControllerMaster.ChangeSide();

                    draggedItem.transform.SetParent(draggedItem.afterSlot.gameObject.transform);
                    draggedItem.image.raycastTarget = true;
                    
				}
				else
                {
                    //Debug.Log("THIS PLACE IS NOT VALID TO DROP");
                }
            }

		}

	}

   

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if(transform.childCount == 0 && gameControllerMaster.state == GameControllerMaster.State.placing)
        {
            if (gameControllerMaster.numberOfRedPawns == 0 && gameControllerMaster.numberOfGreenPawns == 0)
            {
                gameControllerMaster.state = GameControllerMaster.State.playing;
				return;
			}
               
            
            if(gameControllerMaster.side == GameControllerMaster.Side.Red)
            {
				GameObject go = Instantiate(redGameObject) as GameObject;
				go.transform.SetParent(this.transform);
				gameControllerMaster.RedPawnsMinusOne();
				gameControllerMaster.ChangeSide();
			}
            else
            {
				GameObject go = Instantiate(greenGameObject) as GameObject;
				go.transform.SetParent(this.transform);
				gameControllerMaster.GreenPawnsMinusOne();
				gameControllerMaster.ChangeSide();
			}


			

		}
        if(gameControllerMaster.state == GameControllerMaster.State.triara)
        {
            if(gameControllerMaster.redDidTriara == true && 
                this.gameObject.GetComponentInChildren<DraggableItem>().colorofPiece != DraggableItem.ColorofPiece.Red)
            {

                Destroy(this.gameObject.transform.GetChild(0).gameObject);
                gameControllerMaster.redDidTriara = false;
				gameControllerMaster.state = GameControllerMaster.State.playing;
				gameControllerMaster.ChangeSide();
			}
            if(gameControllerMaster.greenDidTriara == true &&
				this.gameObject.GetComponentInChildren<DraggableItem>().colorofPiece != DraggableItem.ColorofPiece.Green)
            {
				Destroy(this.gameObject.transform.GetChild(0).gameObject);
				gameControllerMaster.greenDidTriara = false;
				gameControllerMaster.state = GameControllerMaster.State.playing;
				gameControllerMaster.ChangeSide();
			}

            gameControllerMaster.uihandler.TriaraPopUp(0);
        }

	} 

    
}
