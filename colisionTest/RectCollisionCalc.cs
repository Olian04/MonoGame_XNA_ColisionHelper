using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace colisionTest
{
    abstract class RectCollisionCalc
    {
        private CollisionBox cb;

        protected void Init(CollisionBox _cb)
        {
            cb = _cb;
        }

        public bool Intersects(CollisionBox target)
        {
            if (cb.getBoundingBox().Intersects(target.getBoundingBox()))
                if (cb.getBoundinType() == target.getBoundinType())
                {
                    if (cb.getBoundinType() == boundingType.AABB)
                        return true;
                    else if (cb.getBoundinType() == boundingType.AIDBC)
                    {
                        return Math.Abs(Vector2.Distance(cb.getCenter(), target.getCenter())) <= (cb.getSize().X + target.getSize().X)/2;
                    }
                }
                else
                {
                }
            return false;
        }

        #region Directional Detection
        public bool isLeft(CollisionBox target)
        {
            Rectangle rect = Rectangle.Intersect(cb.getBoundingBox(), target.getBoundingBox());
            if (this.Intersects(target) ? cb.getBoundingBox().Left == rect.Left : false)
                return rect.Height > rect.Width;
            return false;
        }
        public bool isRight(CollisionBox target)
        {
            Rectangle rect = Rectangle.Intersect(cb.getBoundingBox(), target.getBoundingBox());
            if (this.Intersects(target) ? cb.getBoundingBox().Right == rect.Right : false)
                return rect.Height > rect.Width;
            return false;
        }
        public bool isAbove(CollisionBox target)
        {
            Rectangle rect = Rectangle.Intersect(cb.getBoundingBox(), target.getBoundingBox());
            if (this.Intersects(target) ? cb.getBoundingBox().Top == rect.Top : false)
                return rect.Height < rect.Width;
            return false;
        }
        public bool isBelow(CollisionBox target)
        {
            Rectangle rect = Rectangle.Intersect(cb.getBoundingBox(), target.getBoundingBox());
            if (this.Intersects(target) ? cb.getBoundingBox().Bottom == rect.Bottom : false)
                return rect.Height < rect.Width;
            return false;
        }
        #endregion

        public double degreeTo(CollisionBox target)
        {
            double deg = MathHelper.ToDegrees((float)(Math.Atan2(target.getCenter().X - cb.getCenter().X, target.getCenter().Y - cb.getCenter().Y) - Math.PI / 2));
            return deg < 0 ? deg + 360 : deg > 360 ? deg - 360 : deg;
        }
        public double radiantTo(CollisionBox target)
        {
            double deg = Math.Atan2(target.getCenter().X - cb.getCenter().X, target.getCenter().Y - cb.getCenter().Y ) - Math.PI / 2;
            return deg < 0 ? deg + Math.PI * 2 : deg > Math.PI * 2 ? deg - Math.PI * 2 : deg;
        }
    }
}
