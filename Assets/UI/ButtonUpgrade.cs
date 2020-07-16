using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator ButtonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        ButtonAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonAnimator.SetBool("Show", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonAnimator.SetBool("Show", false);
    }
}
