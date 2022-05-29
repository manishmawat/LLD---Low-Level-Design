using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        private string character;
        public string Character
        {
            get
            {
                return character;
            }
        }

        public class PlayerBuilder
        {
            private Player player;
            public PlayerBuilder()
            {
                player = new Player();
            }

            public PlayerBuilder setName(string name)
            {
                player.name = name;
                return this;
            }

            public PlayerBuilder setCharacter(string character)
            {
                player.character = character;
                return this;
            }

            public Player Build()
            {
                return player;
            }
        }
    }
}
