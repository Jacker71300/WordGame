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
        //Instantiates variables with corresponding Components
        trans = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        
        //Takes in the position of the object to be used as a place to stop
        finalPos = trans.localPosition;
        finalX = finalPos.x;
        finalY = finalPos.y;

        //Kicks the object off the screen to the side that gamemaker chooses
        //Also takes in the position of the object at that state for later
        switch (side)
        {
            case Sides.Top:
                CalculateDistance();
                //Kicks object offscreen
                trans.localPosition = Vector2.up * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentY = currentPos.y;
                break;
            case Sides.Bottom:
                CalculateDistance();
                //Kicks object offscreen
                trans.localPosition = Vector2.down * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentY = currentPos.y;
                break;
            case Sides.Left:
                CalculateDistance();
                //Kicks object offscreen
                trans.localPosition = Vector2.left * ((distance * 3) / 4);
                currentPos = trans.localPosition;
                currentX = currentPos.x;
                break;
            case Sides.Right:
                CalculateDistance();
                //Kicks object offscreen
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
    }

    void Update()
    {
        CalculateDistance();
        //Test Variables (May or may not be in final product)
        //Used to help calculate how far object is traveled and when to stop
		float distanceSoFar = 0.0f;
		float distanceByStep = 0.0f;
		int count = 0;

        //Moves letters across the screen until they reach position needed
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
        //This side is different so I can test different methods to get letters to stop moving
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

    //Calculates the distance of the object to the chosen side
    void CalculateDistance()
    {
        //Variables
        var position = finalPos;
        var size = canvas.scaleFactor * trans.rect.size;
        var canvasSize = canvas.pixelRect.size;

        //Finds of object to each side
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