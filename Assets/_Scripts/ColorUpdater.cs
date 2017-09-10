using UnityEngine;
using UnityEngine.UI;

public class ColorUpdater : MonoBehaviour {
    public Image dropdownSprite;
    public Renderer tokenRend;

    public void OnColorDropdownChanged(Text colorText)
    {
        if (colorText.text != "None")
        {
            Color c = colorText.text.ToColor();
            dropdownSprite.color = c;
            tokenRend.material.color = c;
        }
        else
        {
            dropdownSprite.color = Color.white;
            tokenRend.material.color = Color.white;
        }    
    }
}

public static class ColorExtensions
{
    public static Color ToColor(this string color)
    {
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }
}