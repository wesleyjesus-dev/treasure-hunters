namespace TreasureHunters.character
{
    public static class Animations
    {
        public static class WithSword
        {
            public const string Run = "run_with_sword";
            public const string Land = "run_with_land";
            public const string Jump = "jump_with_sword";
            public const string Attack1 = "attack_1";
            public const string Attack2 = "attack_2";
            public const string Attack3 = "attack_3";
        }
    }

    public static class AnimationsExtensions
    {
        public static bool AnimationEndsIs(this AnimatedSprite2d animatedSprite2D, params string[] animations)
        {
            foreach (var animator in animations)
            {
               if (animatedSprite2D.Animation == animator)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
