using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spellbook : MonoBehaviour {

    //Setup the list of Spells
    List<Spell> SpellList = new List<Spell>();
    

    public void AddNewSpell(Spell splNew)
    {
        int intCurrCount = GetSpellCount(splNew.intLevel);
        switch (splNew.intLevel)
        {
            case 0: if (intCurrCount < GetComponentInParent<Player>().intCantripMax) { SpellList.Add(splNew); } break;
            case 1: if (intCurrCount < GetComponentInParent<Player>().intL1SpellMax) { SpellList.Add(splNew); } break;
            case 2: if (intCurrCount < GetComponentInParent<Player>().intL2SpellMax) { SpellList.Add(splNew); } break;
            case 3: if (intCurrCount < GetComponentInParent<Player>().intL3SpellMax) { SpellList.Add(splNew); } break;
            case 4: if (intCurrCount < GetComponentInParent<Player>().intL4SpellMax) { SpellList.Add(splNew); } break;
            case 5: if (intCurrCount < GetComponentInParent<Player>().intL5SpellMax) { SpellList.Add(splNew); } break;
        }
    }//End AddNewSpell Method
    


    public int GetSpellCount(int intSpellLevel)
    {
        int intCount = 0;
        foreach (var spl in SpellList)
        {
            if(spl.intLevel == intSpellLevel) { intCount++; }
        }
        return intCount;
    }//End GetSpellCount Method

}//End Spellbook Class
