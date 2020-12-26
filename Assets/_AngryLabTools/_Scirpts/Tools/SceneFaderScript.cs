using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AngryLab
{
    public class SceneFaderScript : MonoBehaviour
    {
        [SerializeField] private float _fadeTime;
        [SerializeField] private bool _startFadeOut = false;
        [SerializeField] private Image _fadePanel;
        [SerializeField] private Color _currentColor = Color.black;
        [SerializeField] private UnityEvent FadeOutEvent;
        [SerializeField] private UnityEvent FadeInEvent;


        private bool _isFading = false;

        // Use this for initialization
        private void Start()
        {
            if (_startFadeOut) _currentColor.a = 1;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_startFadeOut && !_isFading)
            {
                _isFading = true;
                StartCoroutine(FadeOut());
            }
        }

        public void Fade_Out()
        {
            _currentColor.a = 1;
            StartCoroutine(FadeOut());
        }

        public void Fade_In()
        {
            _currentColor.a = 0;
            StartCoroutine(FadeIn());
        }


        //Black fades out
        IEnumerator FadeOut()
        {
            while (_currentColor.a > 0)
            {
                float alphaChange = Time.deltaTime / _fadeTime;
                alphaChange = Time.deltaTime / _fadeTime;
                _currentColor.a -= alphaChange;
                _fadePanel.color = _currentColor;
                yield return new WaitForSeconds(Mathf.Abs(alphaChange));
            }

            if (FadeOutEvent != null)
            {
                FadeOutEvent.Invoke();
            }

            _isFading = _startFadeOut = false;
            yield return null;
        }

        //Black shows up
        IEnumerator FadeIn()
        {
            while (_currentColor.a < 1)
            {
                float alphaChange = Time.deltaTime / _fadeTime;
                _currentColor.a += alphaChange;
                _fadePanel.color = _currentColor;
                yield return new WaitForSeconds(Mathf.Abs(alphaChange));
            }

            if (FadeInEvent != null)
            {
                FadeInEvent.Invoke();
            }

            yield return null;
        }
    }
}