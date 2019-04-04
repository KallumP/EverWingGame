using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace EverWing_Remake {
    class PlayerInfo {
        int coins;
        int health;
        int damage;

        public PlayerInfo() {

            //opens up the player information file
            StreamReader sr = new StreamReader(Properties.Resources.PlayerInfo);

            //gets the information to create a player
            coins = sr.Read();
            health = sr.Read();
            damage = sr.Read();

            //closes the file
            sr.Close();
        }

        public void saveGame() {

            //opens up the player information file
            StreamWriter sw = new StreamWriter(Properties.Resources.PlayerInfo);

            //saves the information about the player to the file
            sw.WriteLine(coins);
            sw.WriteLine(health);
            sw.WriteLine(damage);

            //closes the file
            sw.Close();
        }


    }
}
