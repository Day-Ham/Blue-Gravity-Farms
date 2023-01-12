using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float duration = 1;

    [SerializeField] private string SceneName;
    [SerializeField] bool TransitionIN = true;
    // Start is called before the first frame update
    void Start()
    {
        if (TransitionIN)
        {
            transform.localScale= Vector2.one * 100;
            transform.DOScale(0, duration);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextScene()
    {
        transform.DOScale(Vector3.one * 100, duration).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneName);
        });
    }

    public void TransitionInto()
    {
        transform.DOScale(Vector3.zero, duration);
    }
}
