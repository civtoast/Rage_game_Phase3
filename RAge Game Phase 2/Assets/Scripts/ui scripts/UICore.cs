using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICore : MonoBehaviour {

	public Button close;

	public virtual void Init()
	{
		//Don't yet know what this will do
	}

	protected virtual void Start () {
		close.onClick.AddListener(Close);
	}

	protected void Close()
	{
        print("Close");
        //Destroy(gameObject);
        StartCoroutine(FadeOut());
	}

    protected void ShowPanel()
    {
        StartCoroutine(FadeUp());
    }

    IEnumerator FadeUp()
    {
        for (float i = 0; i < 1; i += Time.deltaTime * 2)
        {
            GetComponent<CanvasGroup>().alpha = i;
            yield return null;
        }

        GetComponent<CanvasGroup>().alpha = 1;

    }

    IEnumerator FadeOut()
    {
        for (float i = 1; i > 0; i -= Time.deltaTime * 2)
        {
            GetComponent<CanvasGroup>().alpha = i;
            yield return null;
        }

        Destroy(gameObject);

    }

	
}
