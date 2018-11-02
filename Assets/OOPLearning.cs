using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPLearning : MonoBehaviour
{
    void Start()
    {
        // value: int, float, double, bool, Vector3, Vector2, Rect, Bounds
        // referece : string, GameObject, Components, MonoBehaviour, RigidBody, MeshRenderer, Material, Mesh

        var animals = new List<Animal>();
        animals.Add(new Dog());
        animals.Add(new Cow());
        animals.Add(new Human());
        animals.Add(new Cat());

        var dog = new Dog();
        dog.Legs -= 1;
        dog.Legs -= 1;
        dog.Legs -= 1;
        dog.Legs -= 1;
        dog.Legs -= 1;

        Debug.Log(dog.Legs);

        //foreach (var animal in animals)
        //    Debug.Log(animal.Sound);

        var sum = MyMath.Add(10, 5);
        var sine = Mathf.Sin(30);
        var myDog = Animal.MakeDog();
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
    public Cat() : base(4, "Miao")
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