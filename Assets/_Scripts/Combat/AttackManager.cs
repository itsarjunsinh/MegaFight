public class AttackManager
{
        public interface IAttack
        {
                string name { get; }
                float damage { get; }
                string animationTag { get; }
        }
        
        public interface IAttackCharacter
        {
                AttackManager.IAttack attack1 { get; }
                AttackManager.IAttack attack2 { get; }
                void StartAttack1();
                void StartAttack2();
        }
        
        public class AttackEarthquake : IAttack
        {
                public string name { get; } = "Squash";
                public string animationTag { get; } = "JumpAttack";
                public float damage { get; } = 45;
        }
        
        public class AttackMegabeam : IAttack
        {
                public string name { get; } = "Megabeam";
                public string animationTag { get; } = "MagicAttack";
                public float damage { get; } = 40;
        }
        
        public class AttackSlash : IAttack
        {
                public string name { get; } = "Slash";
                public string animationTag { get; } = "SwipeAttack";
                public float damage { get; } = 25;
        }
        
        public class AttackSuperKick : IAttack
        {
                public string name { get; } = "Super Kick";
                public string animationTag { get; } = "KickAttack";
                public float damage { get; } = 20;
        }
}