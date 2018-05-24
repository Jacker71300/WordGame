using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingTextTest : MonoBehaviour {
    /*public float speed = 1.0f;
    public enum Sides
    {
        Left,
        Right,
        Top,
        Bottom
    }
    public Sides side;

    private Vector2 inside;
    private Vector2 outside;

    void Start()
    {
        switch(side) {
        case side.Top:
                GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        case side.Bottom:
                GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        case side.Left:
                GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        case side.Right:
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }
    void Update()
    {
        if ()
    }*/
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
    public float speed = 50.0f;

    /// Inside is assumed to be the start position of the RectTransform.
    private Vector2 end;

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
        end = trans.position;
        switch (side)
        {
            case Sides.Top:
                CalculateOutside();
                trans.position = Vector2.up * distance;
                break;
            case Sides.Bottom:
                trans.position = Vector2.down * distance;
                break;
            case Sides.Left:
                trans.position = Vector2.left * distance;
                break;
            case Sides.Right:
                trans.position = Vector2.right * distance;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        CalculateOutside();
        Vector2 test = trans.position;
        //rectTransform.position = Vector2.Lerp(outside, inside, speed);
        if (end != test)
        {
            switch (side)
            {
                case Sides.Top:
                    GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
                    break;
                case Sides.Bottom:
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    break;
                case Sides.Left:
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                    break;
                case Sides.Right:
                    GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                    break;
                default:
                    break;
            }
        }
    }

    void CalculateOutside()
    {
        var position = end;
        var size = canvas.scaleFactor * trans.rect.size;
        var pivot = trans.pivot;
        var canvasSize = canvas.pixelRect.size;

        switch (side)
        {
            case Sides.Top:
                var distanceToTop = canvasSize.y - position.y;
                outside = end + new Vector2(0f, distanceToTop + size.y * (pivot.y));
                distance = distanceToTop;
                break;
            case Sides.Bottom:
                var distanceToBottom = position.y;
                outside = end + new Vector2(0f, -distanceToBottom - size.y * (1 - pivot.y));
                distance = distanceToBottom;
                break;
            case Sides.Left:
                var distanceToLeft = position.x;
                outside = end + new Vector2(-distanceToLeft - size.x * (1 - pivot.x), 0f);
                distance = distanceToLeft;
                break;
            case Sides.Right:
                var distanceToRight = canvasSize.x - position.x;
                outside = end + new Vector2(distanceToRight + size.x * (pivot.x), 0f);
                distance = distanceToRight;
                break;
            default:
                outside = Vector2.zero;
                break;
        }
    }
}
