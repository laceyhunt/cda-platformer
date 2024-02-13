using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class clickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   [SerializeField] private Image image;
   [SerializeField] private Sprite up, pressed;
   //[SerializeField] private AudioClip compressClip, uncompressClip;
   //[SerializeField] private AudioSource audioSource;
   [SerializeField] private TextMeshProUGUI playText;
   [SerializeField] private Vector3 moveOffset;

   public void onPointerDown(PointerEventData eventData)
   {
        image.sprite = pressed;
        //audioSource.PlayOneSHot(compressClip);
        if(playText != NULL)
        {
            playText.rectTransform.localPosition += moveOffset;
        }
   }
   public void onPointerUp(PointerEventData eventData)
   {
        image.sprite = up;
        //audioSource.PlayOneSHot(uncompressClip);
        if(playText != NULL)
        {
            playText.rectTransform.localPosition -= moveOffset;
        }
   }
}
