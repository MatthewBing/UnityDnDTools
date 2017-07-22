using System;
using UnityEngine;

public class DeleteMe : MonoBehaviour {

    public enum Races
    {
        Dwarf,
        Human
    }

    public enum Classes
    {
        Barb,
        Archer
    }

    public T GenerateRace<T>(T type) where T : IConvertible
    {
        Array values = Enum.GetValues(typeof(T));
        System.Random rnd = new System.Random();
        return (T)values.GetValue(rnd.Next(values.Length));
    }

    public static T GetRandomValue<T>()
    {
        System.Random rnd = new System.Random();
        T[] values = (T[])(Enum.GetValues(typeof(T)));
        return values[rnd.Next(0, values.Length)];
    }

    private void Start()
    {
        string race = GetRandomValue<Races>().ToString();
        Debug.Log(race);
    }
}
