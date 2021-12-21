﻿using ff14bot;
using ff14bot.Managers;
using Magitek.Extensions;
using Magitek.Utilities;
using System.Threading.Tasks;
using Magitek.Models.Reaper;

namespace Magitek.Logic.Reaper
{
    internal static class Utility
    {

        public static async Task<bool> TrueNorth()
        {
            if (ReaperSettings.Instance.EnemyIsOmni || !ReaperSettings.Instance.UseTrueNorth) return false;

            if (ActionResourceManager.Reaper.SoulGauge < 40)
                return false;
            if (ActionResourceManager.Reaper.ShroudGauge >= 40)
                return false;

            if (Core.Me.HasAura(Auras.EnhancedGibbet))
            {
                if (Core.Me.CurrentTarget.IsFlanking)
                    return false;

                return await Spells.TrueNorth.CastAura(Core.Me, Auras.TrueNorth);

            }

            if (Core.Me.HasAura(Auras.EnhancedGallows))
            {
                if (Core.Me.CurrentTarget.IsBehind)
                    return false;

                return await Spells.TrueNorth.CastAura(Core.Me, Auras.TrueNorth); ;
            }

            return false;
        }

        public static async Task<bool> Soulsow()
        {

            if (!ReaperSettings.Instance.UseSoulsow)
                return false;

            if (Core.Me.HasAura(Auras.Soulsow))
                return false;

            if (Core.Me.InCombat && Core.Me.HasTarget)
                return false;

            return await Spells.Soulsow.CastAura(Core.Me, Auras.Soulsow);

        }

    }
}