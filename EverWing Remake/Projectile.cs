using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace EverWing_Remake {
    class Projectile {
        Point coords;
        int speed = 10;


        //constructor
        public Projectile(int _x, int _y) {
            coords = new Point(_x, _y);
        }

        //makes the projectile move down
        public void move() {
            coords.Y -= speed;
        }

        //returns whether to kill the projectile
        public bool checkToRemove() {

            //checks for the y boundary
            if (coords.Y < 0)
                return true;
            
            //returns false if the object is above the y boundary
            return false;
        }

        //draws out the projectiles
        public void draw(PaintEventArgs e) {
            e.Graphics.DrawEllipse(Pens.Green, coords.X - size / 2, coords.Y - size / 2, size, size);
        }



        //properties----------------------------------------------------------
        public int size { get; set; } = 15;
        public int damage { get; set; } = 5;

        public Point Coords {
            get {
                return coords;
            }
        }
    }
}
