using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Audio_Manager.Instance.PlayUIAudio("Button");
    }
    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
