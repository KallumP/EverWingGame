using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace EverWing_Remake {
    class MonsterBatch {
        
        int difficulty = 5;
        public List<Monster> monsters = new List<Monster>();

        public int monsterSize { get; set; } = 50;
        int monsterSpacing = 87;

        //constructor
        public MonsterBatch(int _d) {
            difficulty = _d;
            createMonsters();
        }

        //spawns monsters into the batch
        void createMonsters() {

            //loops five times
            for (int i = 0; i < 5; i++) {

                //creates a monster with the right coordinates per iteration
                monsters.Add(new Monster(new Point(monsterSize / 2 + i * monsterSpacing, -monsterSize), difficulty, monsterSize));
            }
        }

        //makes the batch move down the screen
        public void move() {

            //makes each monster in the batch move
            foreach (Monster m in monsters)
                m.move(difficulty - 2);
        }

        //draws the batch of monsters
        public void draw(PaintEventArgs e) {

            //draws each monster out
            foreach (Monster m in monsters)
                m.draw(e);
        }



        //properties----------------------------------------------------------
        //public int yLoc { get; } = 0;
    }
}
