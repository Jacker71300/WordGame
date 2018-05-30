using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTextTest : MonoBehaviour {

    public enum Sides
    {
        Left,
        Right,
        Top,
        Bottom
    }
    //The side from where the rect transform should fly in.
    public Sides side;

    //Speed of the object's movement
    public float speed = 100.0f;

    //Position and coordinates of where it should stop and
    //where the object is as it's moving.
    private Vector2 finalPos;
    private float finalX;
    private float finalY;
    private Vector2 currentPos;
    private float currentX;
    private float currentY;

    //Distance from object to the side it should fly in from.
    private float distance;

    //Reference to the rect transform component.
    private RectTransform trans;
    //Reference to the canvas component this RectTransform is placed on.
    private Canvas canvas;

    void Start()
    {
        trans = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        finalPos = trans.localPosition;
        finalX = finalPos.x;
        finalY = finalPos.y;
        switch (side)
        {
            case Sides.Top:
                CalculateDistance();
                trans.localPosition = Vector2.up * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentY = currentPos.y;
                break;
            case Sides.Bottom:
                CalculateDistance();
                trans.localPosition = Vector2.down * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentY = currentPos.y;
                break;
            case Sides.Left:
                CalculateDistance();
                trans.localPosition = Vector2.left * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentX = currentPos.x;
                break;
            case Sides.Right:
                CalculateDistance();
                trans.localPosition = Vector2.right * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentX = currentPos.x;
                break;
            default:
                currentPos = trans.localPosition;
                currentX = currentPos.x;
                currentY = currentPos.y;
                break;
        }
        /*
        switch (side)
        {
            case Sides.Top:
                CalculateOutside();
                while (currentPos != outside)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * 1000000000;
                    currentPos = trans.position;
                }
                break;
            case Sides.Bottom:
                CalculateOutside();
                while (currentPos != outside)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.down * 1000000000;
                    currentPos = outside;
                }
                break;
            case Sides.Left:
                CalculateOutside();
                while (currentPos != outside)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.left * 1000000000;
                    currentPos = outside;
                }
                break;
            case Sides.Right:
                CalculateOutside();
                //while (currentPos != outside)
                //{
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 18439999900000000000;
                //currentPos = trans.position;
                //}
                break;
            default:
                break;
        }*/
    }

    void Update()
    {
        CalculateDistance();
        //rectTransform.position = Vector2.Lerp(outside, inside, speed);
        //if (finalPos != currentPos)
        //{
		float distanceSoFar = 0.0f;
		float distanceByStep = 0.0f;
		int count = 0;
        switch (side)
        {
		case Sides.Top:
			if (finalY != currentY) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed;
				currentPos = trans.position;
				currentY = currentPos.y;
			} else
				speed = 0.0f;
                    break;
		case Sides.Bottom:
			if (finalY != currentY) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
				currentPos = trans.position;
				currentY = currentPos.y;
			} else
				speed = 0.0f;
                break;
		case Sides.Left:
			if (finalX != currentX) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
				currentPos = trans.position;
				currentX = currentPos.x;
			} else
				speed = 0.0f;
                break;
		case Sides.Right:
			if (finalX != (finalX + distanceSoFar) || count == 0) {
				GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;
				currentPos = trans.position;
				currentX = currentPos.x;
				if (count == 0) {
					count++;
					distanceByStep = currentX;
				}
				distanceByStep = distanceByStep - currentX;
				distanceSoFar = distanceByStep + distanceSoFar;
			} else
				speed = 0.0f;
                break;
            default:
                break;
        }
    }

    void CalculateDistance()
    {
        var position = finalPos;
        var size = canvas.scaleFactor * trans.rect.size;
        var canvasSize = canvas.pixelRect.size;

        switch (side)
        {
            case Sides.Top:
                distance = canvasSize.y - position.y;
                break;
            case Sides.Bottom:
                distance = position.y;
                break;
            case Sides.Left:
                distance = position.x;
                break;
            case Sides.Right:
                distance = canvasSize.x - position.x;
                break;
            default:
                break;
        }
    }
}