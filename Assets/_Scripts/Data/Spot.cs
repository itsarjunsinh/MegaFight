using UnityEngine;

namespace _Scripts.Data
{
    public class Spot
    {
        public string Name { get; }
        public Transform Location { get; }
        
        public Spot(string name, Transform location)
        {
            Name = name;
            Location = location;
        }
    }
}