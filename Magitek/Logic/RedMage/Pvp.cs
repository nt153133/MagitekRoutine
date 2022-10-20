﻿using ff14bot;
using ff14bot.Managers;
using Magitek.Extensions;
using Magitek.Models.RedMage;
using Magitek.Utilities;
using Auras = Magitek.Utilities.Auras;
using System.Linq;
using System.Threading.Tasks;
using RedMageRoutine = Magitek.Utilities.Routines.RedMage;

namespace Magitek.Logic.RedMage
{
    internal static class Pvp
    {
        public static bool OutsideComboRange => (Core.Me.CurrentTarget == null || Core.Me.CurrentTarget == Core.Me) ? false : Core.Me.Distance(Core.Me.CurrentTarget) > 3.4 + Core.Me.CombatReach + Core.Me.CurrentTarget.CombatReach;

        public static async Task<bool> VerstonePvp()
        {

            if(!Spells.VerstonePvp.CanCast())
                return false;

            if (MovementManager.IsMoving)
                return false;

            if(Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.VerstonePvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> CorpsacorpsPvp()
        {

            if (!Spells.CorpsacorpsPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.CorpsacorpsPvp)
                return false;

            if(OutsideComboRange)
                return false;

            if (RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement))
                return false;

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.CorpsacorpsPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> DisplacementPvp()
        {

            if (!Spells.DisplacementPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.DisplacementPvp)
                return false;

            if (RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement))
                return false;

            if (!Core.Me.HasAura(Auras.VermilionRadiance))
                return false;

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.DisplacementPvp.Cast(Core.Me.CurrentTarget);
        }


        public static async Task<bool> MagickBarrierPvp()
        {

            if (!Spells.MagickBarrierPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedOGCD)
                return false;

            if (RedMageSettings.Instance.UsedOGCD && RedMageSettings.Instance.UsedMagickBarrier && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.MagickBarrierPvp.Cast(Core.Me);
        }

        public static async Task<bool> FazzlePvp()
        {

            if (!Spells.FazzlePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedOGCD)
                return false;

            if (RedMageSettings.Instance.UsedOGCD && RedMageSettings.Instance.UsedFazzle && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.FazzlePvp.Cast(Core.Me);
        }

        public static async Task<bool> ResolutionWhitePvp()
        {

            if (!Spells.ResolutionWhitePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedResolution)
                return false;

            if (RedMageSettings.Instance.UsedResolution && RedMageSettings.Instance.UsedResolutionWhite && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.ResolutionWhitePvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> ResolutionBlackPvp()
        {

            if (!Spells.ResolutionBlackPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedResolution)
                return false;

            if (RedMageSettings.Instance.UsedResolution && RedMageSettings.Instance.UsedResolutionBlack && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.ResolutionBlackPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedRiposteWhitePvp()
        {

            if (!Spells.EnchantedRiposteWhitePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerHoly && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedRiposteWhitePvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedZwerchhauWhitePvp()
        {

            if (!Spells.EnchantedZwerchhauWhitePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerHoly && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedZwerchhauWhitePvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedRedoublementWhitePvp()
        {

            if (!Spells.EnchantedRedoublementWhitePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerHoly && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedRedoublementWhitePvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> VerHolyPvp()
        {

            if (!Spells.VerHolyPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerHoly && Core.Me.HasAura(Auras.BlackShift))
                return await Spells.WhiteShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.VerHolyPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedRiposteBlackPvp()
        {

            if (!Spells.EnchantedRiposteBlackPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerflare && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedRiposteBlackPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedZwerchhauBlackPvp()
        {

            if (!Spells.EnchantedZwerchhauBlackPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerflare && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedZwerchhauBlackPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> EnchantedRedoublementBlackPvp()
        {

            if (!Spells.EnchantedRedoublementBlackPvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (OutsideComboRange)
                return false;


            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerflare && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.EnchantedRedoublementBlackPvp.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> VerFlarePvp()
        {

            if (!Spells.VerFlarePvp.CanCast())
                return false;

            if (!RedMageSettings.Instance.UsedMeleeCombo)
                return false;

            if (RedMageSettings.Instance.UsedMeleeCombo && RedMageSettings.Instance.UsedVerflare && Core.Me.HasAura(Auras.WhiteShift))
                return await Spells.BlackShiftPvp.Cast(Core.Me);

            if (Core.Me.HasAura(Auras.Guard))
                return false;

            return await Spells.VerFlarePvp.Cast(Core.Me.CurrentTarget);
        }


    }
}
