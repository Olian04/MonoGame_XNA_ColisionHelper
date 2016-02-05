using Microsoft.Xna.Framework;

namespace colisionTest
{
    enum boundingType {AABB, AIDBC}
    interface CollisionBox
    {
        boundingType getBoundinType();

        void setPosition(Vector2 newValue);
        void alterPositionAdition(Vector2 adition);
        Rectangle getBoundingBox();
        Vector2 getCenter();
        Vector2 getSize();

        bool Intersects(CollisionBox target);
        bool isLeft(CollisionBox target);
        bool isRight(CollisionBox target);
        bool isAbove(CollisionBox target);
        bool isBelow(CollisionBox target);
        double degreeTo(CollisionBox target);
        double radiantTo(CollisionBox target);

    }
}
