using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField]
    float transitionDuration = 4;
    private bool play = false;
    private RectTransform rectTransform;
    private float transitionElapsedTime = 0;
    private float transitionAmount
    {
        get
        {
            return transitionElapsedTime / transitionDuration;
        }
    }

    [SerializeField]
    public TransitionDirection wantedDirection;
    private TransitionDirection currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentDirection = wantedDirection;
        if (wantedDirection == TransitionDirection.In)
        {
            rectTransform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            rectTransform.localScale = new Vector3(0, 0, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!play) return;
        if (currentDirection == TransitionDirection.In)
        {
            rectTransform.localScale = Vector3.Lerp(
                rectTransform.localScale,
                new Vector3(0, 0, 1),
                transitionAmount
            );
        }
        else
        {
            rectTransform.localScale = Vector3.Lerp(
                rectTransform.localScale,
                new Vector3(2, 2, 1),
                transitionAmount
            );
        }
        transitionElapsedTime += Time.deltaTime;

        if (transitionElapsedTime >= transitionDuration)
        {
            if (currentDirection == TransitionDirection.In)
            {
                rectTransform.localScale = new Vector3(0, 0, 1);
                // gameObject.SetActive(false);
                play = false;
            } else {
                currentDirection = TransitionDirection.In;
                transitionElapsedTime = 0;
            }
        }
    }

    // public void ChangeDirection(string direction)
    // {
    //     switch (direction)
    //     {
    //         case "In":
    //             currentDirection = TransitionDirection.In;
    //             break;
    //         case "Out":
    //             currentDirection = TransitionDirection.Out;
    //             break;
    //         default:
    //             break;
    //     }
    // }

    public void SetDuration(float duration)
    {
        transitionDuration = duration;
    }

    public void Play()
    {
        play = true;
        transitionElapsedTime = 0;
        currentDirection = wantedDirection;
    }
}

public enum TransitionDirection
{
    In,
    Out
};
