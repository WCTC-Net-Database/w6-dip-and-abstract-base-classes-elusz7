﻿using W6_assignment_template.Interfaces;
using W6_assignment_template.Commands;
using W6_assignment_template.Models;
using System.Text.Json.Serialization;

namespace W6_assignment_template.Entities
{
    public class Goblin : MonsterBase
    {
        private string Type;
        public Goblin() { }
        public Goblin(string name, int level, int hp, string treasure) 
            : base(name, level, hp, treasure)
        {
        }

        public override void UniqueBehavior()
        {
            throw new NotImplementedException();
        }

        [JsonPropertyName("Type")]
        public string TypeString
        {
            get => Type;
            set
            {
                Type = typeof(Goblin).Name;
            }
        }
    }
}
