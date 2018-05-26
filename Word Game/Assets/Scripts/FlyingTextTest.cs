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

    /// The side from where the rect transform should fly in.
    public Sides side;

    /// The transition factor (from 0 to 1) between inside and outside.
    //[Range(0, 1)]
    //public float transition;
    public float speed = 100.0f;

    /// Inside is assumed to be the start position of the RectTransform.
    private Vector2 finalPos;
    private float finalX;
    private float finalY;
    private Vector2 currentPos;
    private float currentX;
    private float currentY;

    /// Outside is the position
    /// where the rect transform is completely outside of its canvas on the given side.
    private Vector2 outside;
    private float distance;

    /// Reference to the rect transform component.
    private RectTransform trans;
    /// Reference to the canvas component this RectTransform is placed on.
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
        switch (side)
        {
            case Sides.Top:
                if (finalY != currentY) {
                    GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
                    currentPos = trans.position;
                    currentY = currentPos.y;
                }
                    break;
            case Sides.Bottom:
                if (finalY != currentY)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    currentPos = trans.position;
                    currentY = currentPos.y;
                }
                break;
            case Sides.Left:
                if (finalX != currentX)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                    currentPos = trans.position;
                    currentX = currentPos.x;
                }
                break;
            case Sides.Right:
                if (finalX != currentX)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                    currentPos = trans.position;
                    currentX = currentPos.x;
                }
                break;
            default:
                break;
        }
        //}
    }

    void CalculateDistance()
    {
        var position = finalPos;
        var size = canvas.scaleFactor * trans.rect.size;
        //var pivot = trans.pivot;
        var canvasSize = canvas.pixelRect.size;

        switch (side)
        {
            case Sides.Top:
                distance = canvasSize.y - position.y;
                //outside = finalPos + new Vector2(0f, distanceToTop + size.y * (pivot.y));
                //outside = finalPos + new Vector2(0f, distanceToTop + size.y);
                break;
            case Sides.Bottom:
                distance = position.y;
                //outside = finalPos + new Vector2(0f, -distanceToBottom - size.y * (1 - pivot.y));
                //outside = finalPos + new Vector2(0f, -distanceToBottom - size.y);
                break;
            case Sides.Left:
                distance = position.x;
                //outside = finalPos + new Vector2(-distanceToLeft - size.x * (1 - pivot.x), 0f);
                //outside = finalPos + new Vector2(-distanceToLeft - size.x, 0f);
                break;
            case Sides.Right:
                distance = canvasSize.x - position.x;
                //outside = finalPos + new Vector2(distanceToRight + size.x * (pivot.x), 0f);
                //outside = finalPos + new Vector2(distanceToRight + size.x, 0f);
                break;
            default:
                //outside = Vector2.zero;
                break;
        }
    }
}