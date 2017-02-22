using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace reimagined_lampu
{
    public class Circle : IEquatable<Circle>
    {
        public Vector2 Center { get; protected set; }
        public float Radius { get; protected set; }


        public Circle():this(new Vector2(0,0), 0) { }
        public Circle(float posX, float posY, float radius) : this(new Vector2(posX, posY), radius) { }
        public Circle(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public void Move(float dx, float dy) { Move(new Vector2(dx,dy));}

        public void Move(Vector2 dpos)
        {
            Center += dpos;
        }

        public bool IntersectsWith(Circle other)
        {
            var distance = Math.Sqrt(Math.Pow(Center.X - other.Center.X,2) + Math.Pow(Center.Y - other.Center.Y,2));
            return distance < Radius + other.Radius;
        }

        public static bool IntersectsWith(Circle circle1, Circle circle2)
        {
            return circle1.IntersectsWith(circle2);
        }

        public bool Equals(Circle other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Center.Equals(other.Center) && Radius.Equals(other.Radius);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Circle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Center.GetHashCode() * 397) ^ Radius.GetHashCode();
            }
        }
    }
}
