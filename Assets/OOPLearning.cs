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
       
        foreach(var animal in animals)
        Debug.Log(animal.MakeSound());

    }
}


class Animal
{
    int _legs;
    string _sound;

    public Animal(int legs, string sound)
    {
        _legs = legs;
        _sound = sound;
    }

    public string MakeSound()
    {
        return _sound;
    }
}

class Dog : Animal
{
    public Dog() : base(4,"Bark")
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