using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Custom_Button : MonoBehaviour
{
    protected Text buttonText;
    [SerializeField] bool customShape = false;

	protected virtual void Awake()
	{
        if (customShape)
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = .25f;
        }

        buttonText = transform.GetChild(0).GetComponent<Text>();
	}

    protected virtual void OnMouseOver()
    {

    }
    protected virtual void OnMouseEnter()
    {

    }
    protected virtual void OnMouseExit()
    {

    }
    protected virtual void OnMouseDown()
    {

    }
    protected virtual void OnMouseUp()
    {

    }
    protected virtual void OnMouseUpAsButton()
    {

    }
    protected virtual void OnMouseDrag()
    {

    }
    public void PlayButtonDownAudio()
    {
        Audio_Manager.Instance.PlayAudioClip("Button");
    }
}
