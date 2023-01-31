using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour ,IBeginDragHandler, IDragHandler, IEndDragHandler ,IPointerDownHandler
{

    public Image image;
	[HideInInspector]
	public Transform parentAfterDrag;

    public GameObject[] placesItCanBeDragged;

    public GridSlot gridSlot;
	public GameControllerMaster gameControllerMaster;

	public GameObject lastSlot;
	public GameObject afterSlot;
	public enum ColorofPiece
	{
		Red,
		Green
	}
	public ColorofPiece colorofPiece;
	public void Awake()
	{
		gridSlot = transform.GetComponentInParent<GridSlot>();
		
	}

	private void Start()
	{
		
		gameControllerMaster = FindObjectOfType<GameControllerMaster>();
		if (this.name.Contains("Red"))
		{
			colorofPiece = ColorofPiece.Red;
		}
		else if (this.name.Contains("Green"))
		{
			colorofPiece = ColorofPiece.Green;
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
    {
        if(gameControllerMaster.state != GameControllerMaster.State.playing)
            return;

		lastSlot = this.transform.parent.GameObject();

		//Debug.Log("BEGIN DRAG");
		parentAfterDrag = transform.parent;
		transform.SetParent(transform.root);
		transform.SetAsLastSibling();
		image.raycastTarget = false;

	}

    public void OnDrag(PointerEventData eventData)
    {
		if (gameControllerMaster.state != GameControllerMaster.State.playing)
			return;
		if (colorofPiece == ColorofPiece.Red && gameControllerMaster.side != GameControllerMaster.Side.Red)
			return;
		if (colorofPiece == ColorofPiece.Green && gameControllerMaster.side != GameControllerMaster.Side.Green)
			return;
		//Debug.Log("DRAGGING");
        transform.position = eventData.position;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
		if (gameControllerMaster.state != GameControllerMaster.State.playing)
			return;
		
		transform.SetParent(parentAfterDrag);

		afterSlot = parentAfterDrag.gameObject;
	
		image.raycastTarget = true;


	}

    public void OnPointerDown(PointerEventData eventData)
    {
		gridSlot = transform.GetComponentInParent<GridSlot>();
		placesItCanBeDragged = gridSlot.positionsItCanMove;
		
		
	}
}
