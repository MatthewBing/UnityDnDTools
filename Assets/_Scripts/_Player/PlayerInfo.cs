using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{




    public enum Races
    {
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborne,
        Gnome,
        HalfElf,
        HalfOrc,
        Tiefling,
    }

    public enum Classes
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rouge,
        Sorcerer,
        Warlock,
        Wizard
    }

    public enum Alignment
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        Neutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }

    public enum Languages
    {
        Common,
        Dwarvish,
        Elvish,
        Giant,
        Gnomish,
        Goblin,
        HalfLing,
        Orc,
        Draconic
    }

    public enum Backgrounds
    {
        Acolyte,
        Charlatan,
        Criminal,
        Entertainer,
        FolkHero,
        GuildArtisan,
        Hermit,
        Noble,
        Outlander,
        Sage,
        Sailor,
        Soldier,
        Urchin
    }

    public enum Skills
    {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }

    List<string> PersonalityTraits = new List<string>
    {
        "I quote (or misquote) sacred texts and proverbs in almost every situation.",
        "Sarcasm and insults are my weapon of choice",
        "I am always calm, no matter what the situation. I never raise my voice or let my emotions show.",
        "I would rather make a new friend than a new enemy.",
        "I don't pay attention to the risks in a situation. Never tell me the odds.",
        "I blow up at the slightest insult.",
        "I'll settle for nothing less than perfection.",
        "I get bitter if I'm not the center of attention.",
        "I'm a hopeless romantic, always searching for that 'special someone",
        "Thinking is for other people, I prefer action.",
        "I get bored easily. When am I going to get on with my destiny?",
        "I misuse long words in an attempt to sound smarter.",
        "I am oblivious to etiquitte and social expectations.",
        "I connect everything that happens to me to a grand, cosmic plan.",
        "I feel tremendous sympathy for all who suffer.",
        "I'm a snob who looks down on those that can't appreciate fine art.",
        "I don't part with my money easily and will haggle tirelessly to get the best deal possible.",
        "I like to talk at length about my profession.",
        "My favor once lost is lost forever.",
        "If you do me an injury, I will crush you, ruin your name, and salt your fields.",
        "I don't like to get my hands dirty, and I won't be caught dead in unsuitable accomidations.",
        "I... speak... slowly... when talking... to idiots... which... is almost... everyone.",
        "I am horribly, horribly awkward in social situations.",
        "I'm convinced that people are always trying to steal my secrets.",
        "My language is as foul as an otyugh nest.",
        "To me, a tavern brawl is a great way to get to know a new city.",
        "I like a job well done, especially if I can convince someone else to do it.",
        "I stretch the truth for the sake of a good story.",
        "I have a crude sense of humor",
        "I enjoy being strong and like breaking things.",
        "I've lost too many friends, and I'm slow to make new ones.",
        "I can stare down a hell hound without flinching.",
        "I ask a lot of questions.",
        "I eat like a pig and have bad manners.",
        "I don't like to bathe.",
        "I bluntly say what other people are hinting at or hiding.",
        "I think anyone who is nice to me is hiding evil intent."
    };

    public Text raceText;
    public Text genderText;
    public Text classText;
    public Text alignmentText;
    public Text languageText;
    public Text backgroundText;
    public Text skillsText;
    public Text personality1Text;
    public Text personality2Text;
    public Text STRText;
    public Text AGIText;
    public Text CONText;
    public Text INTText;
    public Text WISText;
    public Text CHATest;

    private void Start()
    {
        Player player = GeneratePlayer();
        raceText.text += " " + player.race;
        genderText.text += " " + player.gender;
        classText.text += " " + player.Pclass;
        alignmentText.text += " " + player.alignment;
        languageText.text += " " + player.languages;
        backgroundText.text += " " + player.background;
        skillsText.text += " " + player.skill1 + " " + player.skill2;
        personality1Text.text += " " + player.personalityTrait1;
        personality2Text.text += " " + player.personalityTrait2;
        STRText.text += " " + player.STR;
        AGIText.text += " " + player.AGI;
        CONText.text += " " + player.CON;
        INTText.text += " " + player.INT;
        WISText.text += " " + player.WIS;
        CHATest.text += " " + player.CHA;
    }

    public Player GeneratePlayer()
    {
        Player tempPlayer = new Player();
        tempPlayer.race = GetRandomValue<Races>();
        tempPlayer.gender = GenerateGender();
        tempPlayer.Pclass = GetRandomValue<Classes>();
        tempPlayer.alignment = GetRandomValue<Alignment>();
        tempPlayer.languages = GetRandomValue<Languages>();
        tempPlayer.background = GetRandomValue<Backgrounds>();
        tempPlayer.skill1 = GetRandomValue<Skills>();
        tempPlayer.skill2 = GetRandomValue<Skills>();
        while (tempPlayer.skill1 == tempPlayer.skill2)
        {
            tempPlayer.skill2 = GetRandomValue<Skills>();
        }
        string personality1, personality2;
        GeneratePersonalityTraits(out personality1, out personality2);
        tempPlayer.personalityTrait1 = personality1;
        tempPlayer.personalityTrait2 = personality2;
        tempPlayer.STR = GenerateStat();
        tempPlayer.AGI = GenerateStat();
        tempPlayer.CON = GenerateStat();
        tempPlayer.INT = GenerateStat();
        tempPlayer.WIS = GenerateStat();
        tempPlayer.CHA = GenerateStat();
        return tempPlayer;
    }

    public static T GetRandomValue<T>()
    {
        System.Random rnd = new System.Random();
        T[] values = (T[])(Enum.GetValues(typeof(T)));
        return values[rnd.Next(0, values.Length)];
    }

    public void GeneratePersonalityTraits(out string personality1, out string personality2)
    {
        System.Random rnd = new System.Random();
        int randomOne = rnd.Next(0, PersonalityTraits.Count);
        int randomTwo = rnd.Next(0, PersonalityTraits.Count);
        while (randomOne == randomTwo)
        {
            randomTwo = rnd.Next(0, PersonalityTraits.Count);
        }
        personality1 = PersonalityTraits[randomOne];
        personality2 = PersonalityTraits[randomTwo];
    }

    public int GenerateStat()
    {
        int[] rolls = new int[4];
        rolls[0] = UnityEngine.Random.Range(1, 7);
        rolls[1] = UnityEngine.Random.Range(1, 7);
        rolls[2] = UnityEngine.Random.Range(1, 7);
        rolls[3] = UnityEngine.Random.Range(1, 7);

        Array.Sort(rolls);
        Array.Reverse(rolls);
        Debug.Log(rolls[0] + " " + rolls[1] + " " + rolls[2] + " " + rolls[3]);
        return rolls[0] + rolls[1] + rolls[2];
    }

    public string GenerateGender()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
            return "Male";
        else
            return "Female";
    }
    
}//End PlayerInfo Class



public class Player
{
    //Declare various Variables pertaining to Player details
    public int intExperience { get; set; }
    public PlayerInfo.Races race;
    public string gender;
    public PlayerInfo.Classes Pclass;
    public PlayerInfo.Alignment alignment;
    public PlayerInfo.Languages languages;
    public PlayerInfo.Backgrounds background;
    public PlayerInfo.Skills skill1;
    public PlayerInfo.Skills skill2;
    public string personalityTrait1;
    public string personalityTrait2;
    public int STR;
    public int AGI;
    public int CON;
    public int INT;
    public int WIS;
    public int CHA;
    public Spellbook splbkMyBook;

    //Declare Maximum Allowed Spell Counts for each Spell level
    public int intCantripMax { get; set; }
    public int intL1SpellMax { get; set; }
    public int intL2SpellMax { get; set; }
    public int intL3SpellMax { get; set; }
    public int intL4SpellMax { get; set; }
    public int intL5SpellMax { get; set; }

    public void ChangeMaxSpellCounts(int intCantrip = 0, int intL1 = 0, int intL2 = 0, int intL3 = 0, int intL4 = 0, int intL5 = 0)
    {
        intCantripMax += intCantrip;
        intL1SpellMax += intL1;
        intL2SpellMax += intL2;
        intL3SpellMax += intL3;
        intL4SpellMax += intL4;
        intL5SpellMax += intL5;
    }//End ChangeMaxSpellCounts Method


}//End Player Class