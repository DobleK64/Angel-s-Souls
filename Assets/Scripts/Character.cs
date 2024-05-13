using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{

    private string _name;
    private Sprite _sprite;
    protected float damage;
    protected float health;

    public Character() { }
    public Character(string name, float damage, float health, Sprite sprite) // para que todos los hijos del character tengan nombre daño y un sprite  
    {
        this._name = name;
        this.damage = damage;
        _sprite = sprite;
        this.health = health;
    }


    public Sprite GetSprite() // el metodo que aparecera en los hijos para los sprites  
    {
        return _sprite;
    }
    public float GetDamage()  // el metodo que aparecera en los hijos para el daño 
    {
        return damage;
    }

    public string GetName() // el metodo que aparecera en los hijos para el nombre 

    {
        return _name;
    }
    public virtual float Heal() //el metodo que aparecera en los hijos para la vida 

    {

        return health;
    }
    public abstract float Attack();
}
