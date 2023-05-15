using System.Collections.Generic;
using Gameplay.Models.Bot;

namespace Gameplay.Services
{
    public class BotsContainer
    {
        public List<BotModel> BotsList { get; } = new List<BotModel>();
    }
}