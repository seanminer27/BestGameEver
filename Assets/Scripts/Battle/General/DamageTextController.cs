﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DamageTextObjects {

    public class DamageTextController : MonoBehaviour {

        public TextMesh damageTextMesh;

        [HideInInspector]
        public int damageDisplayed;

        public float lifetime, riseDuration, fadeDuration, riseDistance;
        private float riseElapsedTime, fadeElapsedTime;

        
        private RectTransform rectTransform;
        private Vector2 textStartPosition, textEndPosition;
        private Color textStartColor, textEndColor;


        void Start() {

            rectTransform = GetComponent<RectTransform>();

            textStartPosition = rectTransform.anchoredPosition;
            textEndPosition = new Vector2(textStartPosition.x, (textStartPosition.y + riseDistance));

            textStartColor = damageTextMesh.color;
            textEndColor = new Color(textStartColor.r, textStartColor.g, textStartColor.b, 0f);

            StartCoroutine(RiseText());
            StartCoroutine(FadeText());

            Destroy(gameObject, lifetime);

        } //end Start() 

        


        IEnumerator RiseText() {

            while(riseElapsedTime < riseDuration) {
                float t = riseElapsedTime / riseDuration;
                rectTransform.anchoredPosition = Vector2.Lerp(textStartPosition, textEndPosition, t);
                riseElapsedTime += Time.deltaTime;
                yield return null;
            }

        } //end RiseText()

        IEnumerator FadeText() {

            while(fadeElapsedTime < fadeDuration) {
                float t = fadeElapsedTime / fadeDuration;
                damageTextMesh.color = Color.Lerp(textStartColor, textEndColor, t);
                fadeElapsedTime += Time.deltaTime;
                yield return null;
            }

        } //end RiseText()

    } //end DamageTextController

} //end namespace