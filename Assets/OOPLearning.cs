using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPLearning : MonoBehaviour
{
    void Start()
    {
        //var list = new List<int>();
        //for (int i = 0; i < 100; i++)
        //{
        //    list.Add(i * 10);
        //}

        //var number = list[90];

        //foreach (var num in list)
        //    if (num == 100) 

        var sounds = new Dictionary<string, Animal>();
        sounds.Add("Bark", new Dog());
        sounds.Add("Miao", new Cat());
        sounds.Add("Hello", new Human());

        var animal = sounds["Miao"];
        Debug.Log(animal.Sound);

    }
}

static class MyMath
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}


abstract class Animal
{

    public static Animal MakeDog()
    {
        return new Dog();
    }

    int _legs;
    string _sound;

    public int Legs
    {
        get
        {
            return _legs;
        }
        set
        {
            if (value < 0)
                _legs = 0;
            else
                _legs = value;
        }
    }

    public string Sound
    {
        get
        {
            return _sound;
        }
        set
        {
            if (value == null) return;
            _sound = value;
        }
    }

    public Animal(int legs, string sound)
    {
        _legs = legs;
        _sound = sound;
    }

    //public string MakeSound()
    //{
    //    return _sound;
    //}
}

class Dog : Animal
{
    public Dog() : base(4, "Bark")
    {

    }

    public void Fetch()
    {

    }
}

class Cat : Animal
{
    public Cat() : base(4, "Miaooooo")
    {

    }
}

class Human : Animal
{
    public Human() : base(2, "Hello")
    {

    }
}

class Cow : Animal
{
    public Cow() : base(2, "Moo")
    {

    }
}