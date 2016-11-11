﻿using Mechanics.Enumerations;
using System;
using UnityEngine;

namespace Mechanics.Objects.Abilities
{
    public class BlackHoleMechanic : DamageMechanic
    {
        private float lastUsage;
        private bool isRunning;

        public BlackHoleMechanic(Character self) : base(self)
        {
            this.lastUsage = Time.time;
            this.isRunning = false;
            this.damageInterval = DamageRange;
        }

        public static float HitRange { get { return MECHANICS.TABLES.AOE.HITRANGE.MEDIUM; } }
        public static float Cooldown { get { return MECHANICS.TABLES.AOE.COOLDOWN.MEDIUM; } }
        public static float Duration { get { return MECHANICS.TABLES.AOE.DURATION.MEDIUM; } }
        public static Interval DamageRange { get { return MECHANICS.TABLES.AOE.DAMAGE.MEDIUM; } }

        public override bool CanApply()
        {
            return (Cooldown * this.self[Stats.ALACRITY]) < Time.time - this.lastUsage;
        }

        public override void Execute(Character target, float factor)
        {
            if (!this.isRunning)
            {
                this.lastUsage = Time.time;
                this.isRunning = true;
            }
            if (target != null)
            {
                base.Execute(target, factor);
            }
        }

        public override void End()
        {
            this.isRunning = false;
        }
    }
}