using UnityEngine;
using UnityEngine.UI;

public class ReplicateImage : MonoBehaviour
{
    public Color newColor = Color.red;  
    [SerializeField] private Image originalImage;  
    [SerializeField] private Image shadowImage;  

    void Start()
    {
       
        if (originalImage != null)
        {
            // Criando componente porque se já estiver no objeto, ele não funciona por algum motivo. Não tem porque mexer nisso.
            if (shadowImage == null)
            {
                shadowImage = gameObject.AddComponent<Image>();
                shadowImage.color = new Color(0, 0, 0, 0);
            }
        }
        else
        {
            Debug.LogError("No Image component found on the original object.");
        }
    }

    void Update()
    {
        if(DialogueManager.instance.dialogueIsPlaying)
        {
        
        
        if (originalImage != null && shadowImage != null)
        {
           
            shadowImage.sprite = originalImage.sprite;  
            shadowImage.material = originalImage.material;  
            shadowImage.color = newColor;  
    
            shadowImage.rectTransform.localPosition = originalImage.rectTransform.localPosition;
        }
    }
    }
}
