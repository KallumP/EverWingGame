using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace EverWing_Remake {
    class Monster {
        Point coords;

        int maxhealth;

        //constructor
        public Monster(Point _coords, int difficulty, int _size) {
            coords = _coords;
            health = difficulty * 5;
            maxhealth = health;
            size = _size;
        }

        //reduces the health of the monster
        public void reduceHealth(int toReduce) {

            //takes the damage taken from the health
            health -= toReduce;

            //sets whether the monster should have died after the health change
            if (health <= 0)
                dead = true;
        }

        //makes the monsters move (scaled by the game difficulty when the monster spawned in)
        public void move(int distance) {
            coords.Y += distance;
        }

        //draws out the monster object
        public void draw(PaintEventArgs e) {

            //a variable used to store what to show for the health bars
            int healthRatio = size * health / maxhealth;

            //draws out the monster
            e.Graphics.DrawEllipse(Pens.Purple, coords.X - size / 2, coords.Y - size / 2, size, size);

            //draws out the health bar of the monster, draws the box first, then the bar within the box
            e.Graphics.DrawRectangle(Pens.Black, coords.X - size / 2, coords.Y + size, size, 5);
            e.Graphics.FillRectangle(Brushes.Red, coords.X - size / 2, coords.Y + size, healthRatio, 5);

        }



        //properties----------------------------------------------------------
        public int health { get; set; }
        public bool dead { get; set; }
        public int size { get; set; }
        public Point Coords {
            get {
                return coords;
            }
        }
    }
}
