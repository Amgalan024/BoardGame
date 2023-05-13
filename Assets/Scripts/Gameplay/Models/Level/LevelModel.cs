using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Models
{
    public class LevelModel
    {
        public event Action TurnChanged;
        public LinkedListNode<PlayerModel> CurrentPlayer { get; private set; }

        private readonly LinkedList<PlayerModel> _activePlayers = new LinkedList<PlayerModel>();

        public void SetActivePlayers(List<PlayerModel> playerModels)
        {
            foreach (var playerModel in playerModels)
            {
                _activePlayers.AddLast(playerModel);
            }

            CurrentPlayer = _activePlayers.First;
        }

        public int RandomMoveLenght()
        {
            return Random.Range(1, 6);
        }

        public void ChangeTurn()
        {
            if (_activePlayers.Count(p => p.IsActive) <= 1)
            {
                return;
            }

            if (CurrentPlayer.Next != null)
            {
                CurrentPlayer = CurrentPlayer.Next;
                TurnChanged?.Invoke();
            }
            else
            {
                CurrentPlayer = CurrentPlayer.List.First;
                TurnChanged?.Invoke();
            }

            if (!CurrentPlayer.Value.IsActive)
            {
                ChangeTurn();
            }
        }
    }
}