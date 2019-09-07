using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChange : MonoBehaviour
{
    public CubeGestureListener CubeGestureListener;
    public GameObject[] Cloths;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        CubeGestureListener = CubeGestureListener.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeGestureListener.IsSwipeRight())
        {
            i--;
            Cloths[i].SetActive(true);
            Cloths[i + 1].SetActive(false);
        }
        if (CubeGestureListener.IsSwipeLeft())
        {
            i++;
            Cloths[i].SetActive(true);
            Cloths[i - 1].SetActive(false);
        }
        i = Mathf.Clamp(i, 0, Cloths.Length-1);
    }
}
