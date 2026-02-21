using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private float transitionScreentime = 1.0f;
    public IEnumerator TransitionScreen_UI()
    {
        yield return new WaitForSeconds(transitionScreentime);
    }
}
