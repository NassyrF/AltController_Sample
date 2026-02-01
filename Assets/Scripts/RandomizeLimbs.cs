using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.U2D.Animation;
using System.Linq;

public class RandomizeLimbs : MonoBehaviour
{
    SpriteResolver r;
    Animator anim;
    string currentCat;
    SpriteLibrary lib;
    SpriteLibraryAsset spriteLib;
    IEnumerable<string> labels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        lib = gameObject.GetComponent<SpriteLibrary>();
        //spriteLib = lib.m_SpriteLibraryAsset;
        anim.enabled = false;

        foreach (Transform child in gameObject.transform)
        {
            r = child.gameObject.GetComponent<SpriteResolver>();
            if(r != null) 
            {
                currentCat = r.GetCategory();
                //print(currentCat); //yay it works here
                labels = spriteLib.GetCategoryLabelNames(currentCat);
                int count = labels.Count();
                int index = Random.Range(0, count);
                string newLabel = labels.ElementAt(index);
                r.SetCategoryAndLabel(currentCat, newLabel);
            }
          
        }

        anim.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
