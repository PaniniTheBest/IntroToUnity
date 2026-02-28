using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private float transitionScreentime = 1.0f;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private SpriteRenderer transitionSprite_UI;

    public void StartTransitionScreen()
    { }
    private IEnumerator TransitionScreen_UI()
    {
        yield return new WaitForSeconds(transitionScreentime);
        
    }
}
