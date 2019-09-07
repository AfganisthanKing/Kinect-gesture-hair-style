using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureSwipe : MonoBehaviour
{
    private CubeGestureListener CubeGestureListener;
    public Sprite[] BackgroundImages;
    public int i = 0;
    private SpriteRenderer SpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        CubeGestureListener = CubeGestureListener.Instance;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeGestureListener.IsSwipeRight())
        {
            i++;
            SpriteRenderer.sprite = BackgroundImages[i];
        }
        if (CubeGestureListener.IsSwipeLeft())
        {
            i--;
            SpriteRenderer.sprite = BackgroundImages[i];
        }
        if (CubeGestureListener.IsSwipeUp())
        {

        }
    }
}
