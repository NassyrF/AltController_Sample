using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class NameGenerator : MonoBehaviour
{
    public static Dictionary<int, List<string>> nameSyllables = new Dictionary<int, List<string>>();

    [SerializeField] TextAsset _nameListCSV;

    public List<string> Syllable1 = new List<string>(); 
    public List<string> Syllable2 = new List<string>(); 
    public List<string> Syllable3 = new List<string>();

    void Awake()
    {
        ParseNames();
    }

    void ParseNames()
    {
        nameSyllables.Clear();

        nameSyllables.Add(0, Syllable1);
        nameSyllables.Add(1, Syllable2);
        nameSyllables.Add(2, Syllable3);

        string[] lines = _nameListCSV.text.Replace("\r", "").Split("\n");

        for (int i = 1; i < lines.Length; i++)
		{
			string[] values = lines[i].Split(",");
            for (int n = 0; n < values.Length; n++)
            {
                if (values[n] == "") {continue;}//doesnt add to list if blank
                nameSyllables[n].Add(values[n]);
            }

           
		}
    }

    public static string GenerateRandomName()
    {
        int chance2 = Random.Range(1,4);
        //Debug.Log(chance2);
        int syllables = chance2 < 2 ? 2 : 3;

        string name = "";

        for (int i = 0; i < syllables; i++)
        {
            int syl = Random.Range(0, nameSyllables[i].Count-1);
            name += nameSyllables[i][syl];
        }

        return name;
    }

}
