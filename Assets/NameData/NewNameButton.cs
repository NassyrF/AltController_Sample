using TMPro;
using UnityEngine;

public class NewNameButton : MonoBehaviour
{
    public TextMeshProUGUI textBox;

    public void changeName()
    {
        textBox.text = NameGenerator.GenerateRandomName();
    }
}
