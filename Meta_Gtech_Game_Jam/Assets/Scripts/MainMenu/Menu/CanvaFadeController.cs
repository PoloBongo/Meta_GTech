using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvaFadeController : MonoBehaviour
{

    [SerializeField] private float fadeDuration = 1f;

    [SerializeField] private GameObject panel;

    private Image panelImage; // R�f�rence � l'image du panneau

    private void Awake()
    {
        // R�cup�rer le composant Image sur le GameObject
        panelImage = panel.GetComponent<Image>();

        if (panelImage == null)
        {
            Debug.LogError("Aucun composant Image trouv� sur le panel !");
        }
    }

    public void FadeOutAndDisable()
    {
        if (panelImage != null)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = panelImage.color; // Couleur initiale

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0f, elapsedTime / fadeDuration);
            panelImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Assurez-vous que l'alpha est � 0
        panelImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // D�sactivez le panneau
        panel.SetActive(false);
    }
}