using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class LevelModel
    {
        public LinkedListNode<PlayerModel> CurrentPlayer { get; set; }

        public int RandomMoveLenght()
        {
            return Random.Range(1, 6);
        }
    }
}