using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace EverWing_Remake {
    class Player {
        Point coords;

        int fireRate;


        //constructor 
        public Player(int xLoc, int yLoc, int _interval) {

            //sets the starting coordinates of the player
            coords = new Point(xLoc, yLoc);
            
            fireRate = _interval * 5;

            Size = 50;
        }

        //checks to see if enough time has passed to let the player fire
        public bool checkToFire(int interval) {

            //adds one to the fire counter
            fireCounter += interval;

            //returns true if the right amount of time has passed
            if (fireCounter >= fireRate) {

                //sets the counter back to zero, ready to check firing again
                fireCounter = 0;
                

                return true;
            }

            //returns false if the player has to wait longer to fire
            return false;
        }
        
        //draws out the player
        public void draw(PaintEventArgs e) {
            e.Graphics.DrawEllipse(Pens.Blue, coords.X -  Size / 2, coords.Y -  Size / 2,  Size,  Size);
        }



        //properties----------------------------------------------------------
        public int Score { get; set; }
        public int Size { get; }
        int damage { get; set; } = 10;
        public int fireCounter { get; set; }

        public Point Coords {
            get {
                return coords;
            }
            set {
                coords.X = value.X;
                //sets the x coordinate of the player
            }
        }
    }
}
